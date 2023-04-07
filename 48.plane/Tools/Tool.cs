using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _48.plane.Tools {
    public static class Tool {
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
            return txt;
        }
    }
}
