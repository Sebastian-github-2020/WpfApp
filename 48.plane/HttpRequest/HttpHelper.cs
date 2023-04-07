using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _48.plane.HttpRequest {
    /// <summary>
    /// http工具类
    /// </summary>
    public class HttpHelper {
        private static readonly HttpClient _httpClient = new HttpClient();
        public static HttpClient GetInstance() {
            _httpClient.BaseAddress = new Uri("https://5981aa.com");
            _httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
            return _httpClient;
        }

        public static async Task RequestGet(string url) {
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if(response.IsSuccessStatusCode) {
                Debug.Write(response.Content);
            }
        }
    }
}
