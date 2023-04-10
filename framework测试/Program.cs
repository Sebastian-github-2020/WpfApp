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




            NewMethod();
            Console.ReadLine();
        }

        private async static void NewMethod() {
            // 网络请求测试
            //string da = await HttpHelper<string>.RequestGet("https://httpbin.org/get");
            //Console.WriteLine(da);
            var jsonParams = JsonSerializer.Serialize(new { limite = 30, lotteryCode = "YFLHC" });
            //var jsonParams = JsonSerializer.Serialize("{\"name\":\"zaks\"}");
            Console.WriteLine(jsonParams);
            Console.WriteLine("-----------------------");
            var content = new StringContent(jsonParams);
            content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");
            var rawData = await HttpHelper.RequestPost<LotteryModel>("https://5981aa.com/melody/api/v1/lotteryperiods/queryHisPeriodsPage", content);
            //var rawData = await HttpHelper<string>.GetInstance().PostAsync("https://httpbin.org/post", content);
            Console.WriteLine(JsonSerializer.Serialize(rawData, new JsonSerializerOptions() { Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Create(UnicodeRanges.All) }));

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

}
