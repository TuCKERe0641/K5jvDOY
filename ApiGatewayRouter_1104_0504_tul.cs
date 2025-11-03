// 代码生成时间: 2025-11-04 05:04:58
using System;
using System.Collections.Generic;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

// 定义API网关路由器类
public class ApiGatewayRouter
{
    private readonly ILogger<ApiGatewayRouter> _logger;
    private readonly IHttpClientFactory _clientFactory;
    private readonly Dictionary<string, string> _routes;

    // 构造函数注入ILogger和IHttpClientFactory
    public ApiGatewayRouter(ILogger<ApiGatewayRouter> logger, IHttpClientFactory clientFactory)
    {
        _logger = logger;
        _clientFactory = clientFactory;
        _routes = new Dictionary<string, string>();
    }

    // 添加路由规则
    public void AddRoute(string path, string url)
    {
        _routes.Add(path, url);
    }

    // 删除路由规则
    public void RemoveRoute(string path)
    {
        _routes.Remove(path);
    }

    // 处理请求
    public async Task<HttpResponseMessage> HandleRequestAsync(HttpRequestMessage request)
    {
        try
        {
            // 查找路由规则
            if (_routes.TryGetValue(request.RequestUri.PathAndQuery, out string targetUrl))
            {
                // 使用HttpClientFactory创建HttpClient
                var client = _clientFactory.CreateClient();

                // 发送请求
                var response = await client.GetAsync(targetUrl);
                return response;
            }
            else
            {
                // 未找到路由规则，返回404
                return new HttpResponseMessage(System.Net.HttpStatusCode.NotFound)
                {
                    Content = new StringContent("Route not found")
                };
            }
        }
        catch (Exception ex)
        {
            // 异常处理
            _logger.LogError(ex, "Error handling request");
            return new HttpResponseMessage(System.Net.HttpStatusCode.InternalServerError)
            {
                Content = new StringContent("Internal Server Error")
            };
        }
    }
}

// 配置服务
public static class ApiGatewayRouterServiceCollectionExtensions
{
    public static IServiceCollection AddApiGatewayRouter(this IServiceCollection services)
    {
        services.AddLogging();
        services.AddHttpClient();
        services.AddSingleton<ApiGatewayRouter>();
        return services;
    }
}
