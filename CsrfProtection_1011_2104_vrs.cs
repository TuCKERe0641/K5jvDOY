// 代码生成时间: 2025-10-11 21:04:45
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AntiForgeryExample
{
    // CSRF防护过滤器
    public class CsrfProtectionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            // 获取请求中的CSRF令牌
            string csrfToken = context.HttpContext.Request.Cookies["__RequestVerificationToken"];
            
            // 验证CSRF令牌
            if (string.IsNullOrEmpty(csrfToken) || !context.HttpContext.Request.Headers["Request-Verification-Token"].Equals(csrfToken, StringComparison.OrdinalIgnoreCase))
            {
                // 如果CSRF令牌无效，返回错误响应
                context.Result = new ContentResult
                {
                    StatusCode = 403,
                    Content = "CSRF token validation failed."
                };
                return;
            }
            base.OnActionExecuting(context);
        }
    }

    //控制器
    [ApiController]
    [Route("api/[controller]/[action]