using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace framework测试
{
    internal class Program
    {
        static void Main(string[] args) {
            // 序列化u对象
            string a = JsonSerializer.Serialize<Person>(new Person { Name = "zaks", Age = 20 });
            Console.WriteLine($"序列化对象Person:{a}");
            Person b = JsonSerializer.Deserialize<Person>(a);
            Console.WriteLine($"反序列化对象Person:{b}");
            Console.ReadLine();
        }
    }

    class Person
    {
        public int Age { get; set; }
        public string Name { get; set; }

    }

}
