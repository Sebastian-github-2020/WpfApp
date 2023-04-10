using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace _48.plane.Models {
    public class LotteryModel {


        /// <summary>
        /// 开奖结果 快3和六合彩都是这个
        /// </summary>
        [JsonPropertyName("drawingNumber")]
        public string DrawingNumber { get; set; }
        /// <summary>
        /// 六合彩的开奖结果 对应的生肖
        /// </summary>
        [JsonPropertyName("lhcDrawingZodiac")]
        public string LhcDrawingZodiac { get; set; }


        [JsonPropertyName("theoryDrawingDate")]
        /// <summary>
        /// 开奖时间
        /// </summary>
        public string TheoryDrawingDate { get; set; }

        //期数
        [JsonPropertyName("periodsNumber")]
        public string PeriodsNumber { get; set; }

    }
}
