﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using _48.plane.Models;
using _48.plane.Tools;
namespace _48.plane.HttpRequest
{
    /// <summary>
    /// http工具类
    /// </summary>
    public class HttpHelper<T>
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
        public static async Task<string> RequestGet(string url) {
            HeaderConfig();
            HttpResponseMessage response = await _httpClient.GetAsync(url);
            if(response.IsSuccessStatusCode)
            {
                Debug.Write(response.Content);
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return "403";
            }
        }

        public static async Task<ResponseModel<T>> RequestPost(string url, HttpContent content) {
            HeaderConfig();
            HttpResponseMessage response = await _httpClient.PostAsync(url, content);
            if(response.IsSuccessStatusCode)
            {
                // 字符串序列化对象
                string jsonStr = await response.Content.ReadAsStringAsync();
                JsonSerializer.Deserialize<ResponseListDataModel<T>>(jsonStr);

            }
        }

        /// <summary>
        /// 配置header uuid 和sign
        /// </summary>
        public static void HeaderConfig() {
            string uuid = Tool.MakeUUID();
            _httpClient.DefaultRequestHeaders.Add("x-auth-uu", uuid);
            _httpClient.DefaultRequestHeaders.Add("x-auth-sign", Tool.MakeSign(uuid, SecritKey));
            // 添加
            _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }


    }
}
