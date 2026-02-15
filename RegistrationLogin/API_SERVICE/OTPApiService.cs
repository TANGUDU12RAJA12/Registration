using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
namespace RegistrationLogin
{
    public class OTPApiService
    {
        public static async Task<bool> GenerateOTP(string email)
        {
            var handler = new HttpClientHandler
            {
                SslProtocols = SslProtocols.Tls12,
                CheckCertificateRevocationList = true
            };

            using (HttpClient client = new HttpClient(handler))
            {
                client.Timeout = TimeSpan.FromSeconds(30);

                var payload = new { Email = email };
                var json = JsonConvert.SerializeObject(payload);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response =
                    await client.PostAsync($"http://otpvalidation.runasp.net/api/otp/generate", content);

                return response.IsSuccessStatusCode;
            }
        }
        public static async Task<bool> ValidateOTP(string email, string otp)
        {
            using (HttpClient client = new HttpClient())
            {
                var data = new { Email = email, OTP = otp };
                var json = JsonConvert.SerializeObject(data);

                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync($"http://otpvalidation.runasp.net/api/otp/validate", content);
                return response.IsSuccessStatusCode;
            }
        }
    }
}


//using Newtonsoft.Json;
//using System;
//using System.Net;
//using System.Net.Http;
//using System.Security.Authentication;
//using System.Text;
//using System.Threading.Tasks;

//namespace RegistrationLogin
//{
//    public class OTPApiService
//    {
//        private static HttpClient CreateHttpClient()
//        {
//            // Force TLS 1.2 globally
//            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

//            var handler = new HttpClientHandler
//            {
//                SslProtocols = SslProtocols.Tls12,
//                // Accept any server certificate (for testing/debugging only)
//                ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
//            };

//            // Create client WITHOUT using block
//            var client = new HttpClient(handler)
//            {
//                Timeout = TimeSpan.FromSeconds(30)
//            };

//            // Add common headers
//            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64)");
//            client.DefaultRequestHeaders.Add("Accept", "application/json");

//            return client;
//        }

//        /// <summary>
//        /// Generate OTP for the given email
//        /// </summary>
//        public static async Task<bool> GenerateOTP(string email)
//        {
//            using (var client = CreateHttpClient())
//            {
//                var payload = new { Email = email };
//                var json = JsonConvert.SerializeObject(payload);
//                var content = new StringContent(json, Encoding.UTF8, "application/json");

//                try
//                {
//                    var response = await client.PostAsync("http://otpvalidation.runasp.net/api/otp/generate", content);

//                    if (response.IsSuccessStatusCode)
//                    {
//                        Console.WriteLine("OTP generated successfully.");
//                        return true;
//                    }
//                    else
//                    {
//                        string respContent = await response.Content.ReadAsStringAsync();
//                        Console.WriteLine($"Failed to generate OTP. Status: {response.StatusCode}, Response: {respContent}");
//                        return false;
//                    }
//                }
//                catch (HttpRequestException ex)
//                {
//                    Console.WriteLine("HTTP Request Error: " + ex.Message);
//                    return false;
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine("General Error: " + ex.Message);
//                    return false;
//                }
//            }
//        }

//        /// <summary>
//        /// Validate OTP for the given email
//        /// </summary>
//        public static async Task<bool> ValidateOTP(string email, string otp)
//        {
//            using (var client = CreateHttpClient())
//            {
//                var payload = new { Email = email, OTP = otp };
//                var json = JsonConvert.SerializeObject(payload);
//                var content = new StringContent(json, Encoding.UTF8, "application/json");

//                try
//                {
//                    var response = await client.PostAsync("http://otpvalidation.runasp.net/api/otp/validate", content);

//                    if (response.IsSuccessStatusCode)
//                    {
//                        Console.WriteLine("OTP validated successfully.");
//                        return true;
//                    }
//                    else
//                    {
//                        string respContent = await response.Content.ReadAsStringAsync();
//                        Console.WriteLine($"Failed to validate OTP. Status: {response.StatusCode}, Response: {respContent}");
//                        return false;
//                    }
//                }
//                catch (HttpRequestException ex)
//                {
//                    Console.WriteLine("HTTP Request Error: " + ex.Message);
//                    return false;
//                }
//                catch (Exception ex)
//                {
//                    Console.WriteLine("General Error: " + ex.Message);
//                    return false;
//                }
//            }
//        }
//    }
//}

