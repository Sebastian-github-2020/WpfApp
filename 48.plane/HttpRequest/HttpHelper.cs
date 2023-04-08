using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using _48.plane.Tools;
namespace _48.plane.HttpRequest
{
    /// <summary>
    /// http工具类
    /// </summary>
    public class HttpHelper
    {
        private static readonly HttpClient _httpClient = new HttpClient();
        private static string SecritKey = "9&N4orgck9M!rh2#Wpfyg2Q!teDds8Bl";
        public static HttpClient GetInstance() {
            _httpClient.BaseAddress = new Uri("https://5981aa.com");
            HeaderConfig();

            return _httpClient;
        }


        /// <summary>
        /// get请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task RequestGet(string url) {
            HeaderConfig();
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if(response.IsSuccessStatusCode)
            {
                Debug.Write(response.Content);
            }
        }

        /// <summary>
        /// 配置header uuid 和sign
        /// </summary>
        public static void HeaderConfig() {
            string uuid = Tool.MakeUUID();
            _httpClient.DefaultRequestHeaders.Add("x-auth-uu", uuid);
            _httpClient.DefaultRequestHeaders.Add("x-auth-sign", Tool.MakeSign(uuid, SecritKey));
            _httpClient.DefaultRequestHeaders.Add("Content-Type", "application/json");
        }


    }
}
