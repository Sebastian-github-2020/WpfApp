using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _48.plane.Tools
{
    public static class Tool
    {
        /// <summary>
        /// 生成UUID
        /// </summary>
        /// <returns></returns>
        public static string MakeUUID() {
            return Guid.NewGuid().ToString();
        }
        /// <summary>
        /// 把uuid和密钥拼接 生成md5值
        /// </summary>
        /// <param name="uuid"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string MakeSign(string uuid, string key) {
            var newText = uuid + key;
            return MakeMd5(MakeMd5(newText));
        }

        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string MakeMd5(string txt) {
            MD5 md5 = MD5.Create();
            byte[] res = md5.ComputeHash(Encoding.Default.GetBytes(txt));
            StringBuilder sb = new StringBuilder();
            for(int i = 0; i < res.Length; i++)
            {
                sb.Append(res[i].ToString("X2"));
            }
            return sb.ToString().ToUpper();
        }


        /// <summary>
        /// 反序列化数据: 字符串->对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="jsonString"></param>
        /// <returns></returns>
        public static T MyDeserialize<T>(string jsonString) {
            T serializerData = JsonSerializer.Deserialize<T>(jsonString);
            return serializerData;
        }

        /// <summary>
        /// 序列化对象：对象->字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string MySerializer<T>(T obj) {
            return JsonSerializer.Serialize<T>(obj);
        }
    }
}
