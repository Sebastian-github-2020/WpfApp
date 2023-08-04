using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using _48.plane.Models;
using _48.plane.Tools;
namespace _48.plane.HttpRequest {
    /// <summary>
    /// http工具类 封装请求
    /// </summary>
    public class HttpHelper {

        private static string SecritKey = "9&N4orgck9M!rh2#Wpfyg2Q!teDds8Bl";




        /// <summary>
        /// get请求
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<string> RequestGet(string url) {
            using(HttpClient _httpClient = new HttpClient()) {
                HeaderConfig(_httpClient);
                HttpResponseMessage response = await _httpClient.GetAsync(url);
                if(response.IsSuccessStatusCode) {
                    Debug.Write(response.Content);
                    return await response.Content.ReadAsStringAsync();
                } else {
                    return "403";
                }
            }

        }

        /// <summary>
        /// Post 请求
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="url"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        public static async Task<ResponseModel<T>> RequestPost<T>(string url, HttpContent content) {
            #region using方式创建httpclient

            using(HttpClient _httpClient = new HttpClient()) {
                HeaderConfig(_httpClient);
                HttpResponseMessage response = await _httpClient.PostAsync(url, content);
                if(response.IsSuccessStatusCode) {
                    try {
                        // 字符串序列化对象
                        string jsonStr = await response.Content.ReadAsStringAsync();
                        Debug.Write(jsonStr);
                        // 响应模型
                        var responseBody = JsonSerializer.Deserialize<ResponseModel<T>>(jsonStr);
                        //
                        _httpClient.Dispose();
                        return responseBody;
                    } catch(Exception e) {

                        return new ResponseModel<T>() { Code = "400", Data = null, Msg = e.Message };
                    }
                } else { return new ResponseModel<T>() { Code = "400", Data = null, Msg = "请求失败" }; }
            }

            #endregion


        }

        /// <summary>
        /// 配置header uuid 和sign
        /// </summary>
        public static void HeaderConfig(HttpClient httpClient) {
            //_httpClient.BaseAddress = new Uri("https://5981aa.com");
            string uuid = Tool.MakeUUID();
            httpClient.DefaultRequestHeaders.Add("x-auth-uu", uuid);
            httpClient.DefaultRequestHeaders.Add("x-auth-sign", Tool.MakeSign(uuid, SecritKey));

            // 添加
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }


    }
}
