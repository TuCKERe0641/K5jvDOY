// 代码生成时间: 2025-09-24 16:32:17
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ApiResponseFormatterNamespace
{
    /// <summary>
    /// Provides functionality to format API responses.
    /// </summary>
    public class ApiResponseFormatter
    {
        private readonly JsonSerializerOptions _jsonSerializerOptions;

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponseFormatter"/> class.
        /// </summary>
        public ApiResponseFormatter()
        {
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
        }

        /// <summary>
        /// Formats the response content from the HTTP response message.
        /// </summary>
        /// <typeparam name="T">The type of the response content.</typeparam>
        /// <param name="responseMessage">The HTTP response message.</param>
        /// <returns>A formatted string of the response content.</returns>
        public async Task<string> FormatResponseContentAsync<T>(HttpResponseMessage responseMessage)
        {
            if (responseMessage == null)
                throw new ArgumentNullException(nameof(responseMessage));

            if (!responseMessage.IsSuccessStatusCode)
            {
                return $"Error: {responseMessage.StatusCode}";
            }

            try
            {
                var content = await responseMessage.Content.ReadAsStringAsync();
                var formattedContent = JsonSerializer.Serialize<T>(JsonSerializer.Deserialize<T>(content), _jsonSerializerOptions);
                return formattedContent;
            }
            catch (JsonException ex)
            {
                return $"Failed to format response: {ex.Message}";
            }
        }
    }
}
