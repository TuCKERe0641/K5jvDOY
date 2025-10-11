// 代码生成时间: 2025-10-12 02:40:23
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CodeHighlighterApp
{
    public class CodeHighlighter
    {
        // 定义语言关键字
        private readonly Dictionary<string, string> _keywords = new Dictionary<string, string>
        {
            { "class", "color: blue;" },
            { "public", "color: green;" },
            { "private", "color: red;" },
            // 更多关键字...
        };

        // 定义注释正则表达式
        private readonly string[] _commentPatterns =
        {
            @"//.*?$", // 单行注释
            @"/\*(.*?)\*/", // 多行注释
        };

        // 代码高亮方法
        public string HighlightCode(string code)
        {
            try
            {
                // 先处理注释
                foreach (var pattern in _commentPatterns)
                {
                    code = Regex.Replace(code, pattern, "<span style='$1'>$0</span>", RegexOptions.Singleline);
                }

                // 处理关键字高亮
                foreach (var keyword in _keywords)
                {
                    string pattern = $@"\b{keyword.Key}\b";
                    code = Regex.Replace(code, pattern, $"<span style='{keyword.Value}'>$0</span>", RegexOptions.IgnoreCase);
                }

                return code;
            }
            catch (Exception ex)
            {
                // 错误处理
                Console.WriteLine($"An error occurred: {ex.Message}");
                return null;
            }
        }
    }

    // 测试代码高亮器
    class Program
    {
        static void Main(string[] args)
        {
            CodeHighlighter highlighter = new CodeHighlighter();
            string codeToHighlight = "class Program {{ public static void Main() {{ Console.WriteLine(\\\