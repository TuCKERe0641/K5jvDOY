// 代码生成时间: 2025-10-01 03:41:25
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DataDesensitizationApp
{
    /// <summary>
    /// Data desensitization tool for masking sensitive information.
    /// </summary>
    public class DataDesensitizationTool
    {
        /// <summary>
        /// Masks sensitive data in a string.
        /// </summary>
        /// <param name="data">The data containing sensitive information.</param>
        /// <returns>A string with sensitive information masked.</returns>
        public string MaskSensitiveData(string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentException("Data cannot be null or empty.", nameof(data));
            }

            // Regular expressions for different types of sensitive data
            var regexPatterns = new Dictionary<string, string>
            {
                { "Email", @"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Z|a-z]{2,}" },
                { "Phone", @"(\+?[0-9]+)?[\-]?[0-9\-]*[\-]?[0-9]*" },
                { "CreditCard", @"[0-9]{4}-[0-9]{4}-[0-9]{4}-[0-9]{4}" }
            };

            foreach (var pattern in regexPatterns)
            {
                // Replace matches with masked pattern
                data = Regex.Replace(data, pattern.Value, m => MaskMatch(m));
            }

            return data;
        }

        /// <summary>
        /// Masks a matched regular expression group.
        /// </summary>
        /// <param name="match">The match to be masked.</param>
        /// <returns>A masked version of the match.</returns>
        private string MaskMatch(Match match)
        {
            // Replace sensitive data with asterisks
            return new string('*', match.Length);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var desensitizer = new DataDesensitizationTool();
                var originalData = "John's email is john.doe@example.com and his credit card is 1234-5678-9101-1121.";
                var maskedData = desensitizer.MaskSensitiveData(originalData);
                Console.WriteLine("Original Data: " + originalData);
                Console.WriteLine("Masked Data: " + maskedData);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}