using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _48.plane.Models
{
    /// <summary>
    /// 响应体里面data的模型
    /// </summary>
    public class ResponseListDataModel<T>
    {
        [JsonPropertyName("currPage")]
        public int CurrPage { get; set; }

        [JsonPropertyName("list")]
        public List<T> List { get; set; }

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [JsonPropertyName("totalPage")]
        public int TotalPage { get; set; }
    }
}
