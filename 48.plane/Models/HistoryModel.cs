using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _48.plane.Models
{
    /// <summary>
    /// 历史数据模型,将js的
    /// </summary>
    public class HistoryModel
    {
        [JsonPropertyName("code")]
        public string Code { get; set; }
    }
}
