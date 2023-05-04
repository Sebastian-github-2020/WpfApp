using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using _48.plane.Tools;
using _48.plane.HttpRequest;
using System.Text.Json.Serialization;
using _48.plane.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Unicode;

namespace framework测试 {
    internal class Program {
        static void Main(string[] args) {
            // 序列化u对象
            //string a = JsonSerializer.Serialize<Person>(new Person { Name = "zaks", Age = 20 });
            //Console.WriteLine($"序列化对象Person:{a}");
            //Person b = JsonSerializer.Deserialize<Person>("{\"name\":\"liux\",\"age\":20}");
            //Console.WriteLine($"反序列化对象Person:{b}");




            //NewMethod("SANFK3");
            //NewMethod("HKLHC");
            NewMethod1();
            Console.ReadLine();
        }

        private async static void NewMethod(string code) {
            // 网络请求测试
            //string da = await HttpHelper<string>.RequestGet("https://httpbin.org/get");
            //Console.WriteLine(da);
            var jsonParams = JsonSerializer.Serialize(new { limite = 30, lotteryCode = code });
            //var jsonParams = JsonSerializer.Serialize("{\"name\":\"zaks\"}");
            Console.WriteLine(jsonParams);
            Console.WriteLine("-----------------------");
            var content = new StringContent(jsonParams);
            content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            var rawData = await HttpHelper.RequestPost<LotteryModel>("https://5981aa.com/melody/api/v1/lotteryperiods/queryHisPeriodsPage", content);
            //var rawData = await HttpHelper<string>.GetInstance().PostAsync("https://httpbin.org/post", content);
            Console.WriteLine(JsonSerializer.Serialize(rawData, new JsonSerializerOptions() { Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.All) }));
            Console.WriteLine("-----------------------");
        }

        private async static void NewMethod1() {
            // 网络请求测试
            //string da = await HttpHelper<string>.RequestGet("https://httpbin.org/get");
            //Console.WriteLine(da);
            var jsonParams = JsonSerializer.Serialize(new { friendMemberAccount = "tiezi000", contentType = 1000, content = "应该是可以了", uuid = Guid.NewGuid().ToString() });
            var content = new StringContent(jsonParams);
            content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            string uuid = Tool.MakeUUID();
            using(HttpClient httpClient = new HttpClient()) {
                httpClient.DefaultRequestHeaders.Add("x-auth-uu", uuid);
                httpClient.DefaultRequestHeaders.Add("x-auth-token", "42b813e4-d3c1-4a5d-9f15-cd09715aed93");
                httpClient.DefaultRequestHeaders.Add("x-auth-sign", Tool.MakeSign(uuid, "9&N4orgck9M!rh2#Wpfyg2Q!teDds8Bl"));
                // 添加
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = await httpClient.PostAsync("https://ymhvhblt11-im-tyy.wuguanc.xyz/lark/api/v1/wxP2PChat/sendMsg", content);
                if(response.IsSuccessStatusCode) {
                    string res = await response.Content.ReadAsStringAsync();
                    Console.WriteLine(res);
                }
            }


        }
    }


}

class Person {
    [JsonPropertyName("age")]
    public int Age { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    public override string ToString() {
        return $"Name:{Name},Age:{Age}";
    }

}


