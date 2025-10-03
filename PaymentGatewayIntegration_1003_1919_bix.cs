// 代码生成时间: 2025-10-03 19:19:38
// <copyright file="PaymentGatewayIntegration.cs" company="YourCompany">
//     Copyright (c) YourCompany. All rights reserved.
// </copyright>

using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace YourCompany.PaymentGateway
{
    /// <summary>
    /// Payment gateway integration service responsible for handling payment requests.
    /// </summary>
    public class PaymentGatewayIntegration
    {
        private readonly HttpClient _httpClient;
        private readonly string _paymentGatewayUrl;

        /// <summary>
        /// Initializes a new instance of the <see cref="PaymentGatewayIntegration"/> class.
        /// </summary>
        /// <param name="httpClient">The HTTP client for making requests.</param>
        /// <param name="paymentGatewayUrl">The URL of the payment gateway.</param>
        public PaymentGatewayIntegration(HttpClient httpClient, string paymentGatewayUrl)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _paymentGatewayUrl = paymentGatewayUrl ?? throw new ArgumentNullException(nameof(paymentGatewayUrl));
        }

        /// <summary>
        /// Processes a payment request through the payment gateway.
        /// </summary>
        /// <param name="paymentRequest">The payment request details.</param>
        /// <returns>The payment response from the payment gateway.</returns>
        public async Task<PaymentResponse> ProcessPaymentAsync(PaymentRequest paymentRequest)
        {
            if (paymentRequest == null) throw new ArgumentNullException(nameof(paymentRequest));

            string json = JsonSerializer.Serialize(paymentRequest);
            var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync(_paymentGatewayUrl, content);
                response.EnsureSuccessStatusCode();
                string responseContent = await response.Content.ReadAsStringAsync();
                return JsonSerializer.Deserialize<PaymentResponse>(responseContent);
            }
            catch (HttpRequestException ex)
            {
                // Log error details here.
                // Return a failed payment response with error details.
                return new PaymentResponse {
                    IsSuccessful = false,
                    ErrorMessage = ex.Message
                };
            }
        }
    }

    /// <summary>
    /// Represents a payment request sent to the payment gateway.
    /// </summary>
    public class PaymentRequest
    {
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
        public string Cvv { get; set; }
        public decimal Amount { get; set; }
    }

    /// <summary>
    /// Represents the response received from the payment gateway.
    /// </summary>
    public class PaymentResponse
    {
        public bool IsSuccessful { get; set; }
        public string ErrorMessage { get; set; }
    }
}
