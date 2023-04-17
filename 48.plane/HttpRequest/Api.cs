using _48.plane.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace _48.plane.HttpRequest {
    /// <summary>
    /// api 
    /// </summary>
    public static class Api {

        public static string token;
        /// <summary>
        /// 查询历史数据
        /// </summary>
        /// <param name="key">对应的code</param>
        /// <param name="limit">请求数量</param>
        public static void GetHistory(string key, string limit) {

        }
        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        public static void Login(string username, string password) {
            using(HttpClient httpClient = new HttpClient()) {
                string uuid = Tool.MakeUUID();
                string SecritKey = "9&N4orgck9M!rh2#Wpfyg2Q!teDds8Bl";
                httpClient.DefaultRequestHeaders.Add("x-auth-uu", uuid);
                httpClient.DefaultRequestHeaders.Add("x-auth-sign", Tool.MakeSign(uuid, SecritKey));
                // 添加
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));


            }
        }
    }
}
