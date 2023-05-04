using _48.plane.Models;
using _48.plane.Tools;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows;

namespace _48.plane.HttpRequest {
    /// <summary>
    /// api 
    /// </summary>
    public static class Api {

        private static string SecritKey = "9&N4orgck9M!rh2#Wpfyg2Q!teDds8Bl";
        public static string token;

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        async public static Task<Boolean> Login(string username, string password) {
            using(HttpClient httpClient = new HttpClient()) {
                // 设置header
                HeaderConfig(httpClient);

                // 添加
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                string jsonParse = JsonSerializer.Serialize(new { memberAccount = username, password, zhuakuaiValidate = "" });

                // 设置content 和content-type
                StringContent content = new StringContent(jsonParse);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");


                var response = await httpClient.PostAsync("https://5981aa.com/melody/api/v1/memberuser/login", content);
                if(response.IsSuccessStatusCode) {
                    // 读取返回的内容
                    string res = await response.Content.ReadAsStringAsync();
                    Debug.WriteLine(res);
                    var lrm = JsonSerializer.Deserialize<LoginResponseModel>(res);
                    httpClient.Dispose();
                    if(lrm.Code.Equals("12200")) {
                        Debug.WriteLine("登录成功");
                        // 登录成功 读取header里面的token

                        foreach(var item in response.Headers) {

                            if(item.Key.Equals("x-auth-token")) {
                                string t = item.Value.ToArray()[0];
                                //Debug.WriteLine($"token是{item.Value.ToArray()[0]}");
                                token = t;
                            }
                        }

                        return token.Length == 36;
                    } else {
                        return false;
                    }


                } else { return false; }
            }
        }



        /// <summary>
        /// 配置header uuid 和sign
        /// </summary>
        public static void HeaderConfig(HttpClient httpClient) {
            string uuid = Tool.MakeUUID();
            httpClient.DefaultRequestHeaders.Add("x-auth-uu", uuid);
            httpClient.DefaultRequestHeaders.Add("x-auth-sign", Tool.MakeSign(uuid, SecritKey));

            // 添加
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

        }
    }
}
