
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using _48.plane.HttpRequest;
using _48.plane.Models;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;

namespace _48.plane.ViewModel {
    public class MainModel : ObservableObject {

        private ObservableCollection<TabContrlViewModel> tabData;

        public ObservableCollection<TabContrlViewModel> TabData {
            get => tabData;
            set => SetProperty(ref tabData, value);
        }


        /// <summary>
        /// 初始化数据
        /// </summary>
        public MainModel() {
            // 初始化tab的数据
            this.TabData = new ObservableCollection<TabContrlViewModel>();


            // 请求历史数据
            _ = InitData();

            #region 手写的假数据
            //this.TabData.Add(new TabContrlViewModel(
            //    new BitmapImage(new Uri("pack://application:,,,/Images/YFLHC.png")),
            //    title: "一分六合彩",
            //    "YFLHC",
            //    "测试",
            //    "1087",
            //    "30",
            //     "00,00,00,02,01,23",
            //    new ObservableCollection<DataHistory>() {
            //        new DataHistory { Except = "1056", OpenDate = "2022-15-12", Result = "00 05 12 36 41 02" },
            //        new DataHistory { Except = "1057", OpenDate = "2022-15-12", Result = "00 05 12 36 41 02" }
            //}));
            //this.TabData.Add(new TabContrlViewModel(
            //    new BitmapImage(new Uri("pack://application:,,,/Images/AMLHC.png")),
            //    "澳门六合彩",
            //    "AMLHC",
            //    "1058",
            //    "1057",
            //    leaveTime: "36",
            //    "00,00,00,02,01,23",
            //    new ObservableCollection<DataHistory>() {
            //        new DataHistory { Except = "1057", OpenDate = "2022-15-12", Result = "00 05 12 36 41 02" },
            //        new DataHistory { Except = "1058", OpenDate = "2022-15-13", Result = "00 05 12 36 41 02" },
            //        new DataHistory { Except = "1058", OpenDate = "2022-15-13", Result = "00 05 12 36 41 02" },
            //        new DataHistory { Except = "1057", OpenDate = "2022-15-12", Result = "00 05 12 36 41 02" },
            //        new DataHistory { Except = "1058", OpenDate = "2022-15-13", Result = "00 05 12 36 41 02" },
            //        new DataHistory { Except = "1058", OpenDate = "2022-15-13", Result = "00 05 12 36 41 02" },
            //        new DataHistory { Except = "1057", OpenDate = "2022-15-12", Result = "00 05 12 36 41 02" },
            //        new DataHistory { Except = "1058", OpenDate = "2022-15-13", Result = "00 05 12 36 41 02" },
            //        new DataHistory { Except = "1058", OpenDate = "2022-15-13", Result = "00 05 12 36 41 02" },
            //        new DataHistory { Except = "1057", OpenDate = "2022-15-12", Result = "00 05 12 36 41 02" },
            //        new DataHistory { Except = "1058", OpenDate = "2022-15-13", Result = "00 05 12 36 41 02" },
            //        new DataHistory { Except = "1058", OpenDate = "2022-15-13", Result = "00 05 12 36 41 02" }
            //}));
            #endregion



        }

        // 请求展示的历史数据
        // 5分快3 5分六合 
        /// <summary>
        /// 请求对应的历史数据
        /// </summary>
        /// <param name="code">代码</param>
        /// <param name="index">索引</param>
        public void GetHistoryData(string code, int index) {
            //switch(index) {
            //    //HttpHelper.RequestPost()
            //}
            Debug.WriteLine($"{code}-{index}");

        }
        /// <summary>
        /// 初始化数据
        /// </summary>
        public async Task InitData() {
            List<TabConfig> TabConfigs = new List<TabConfig>();
            TabConfigs.Add(new TabConfig("五分六合彩", "WFLHC", 1, new BitmapImage(new Uri("pack://application:,,,/Images/AMLHC.png"))));

            TabConfigs.Add(new TabConfig("五分快3", "WFK3", 0, new BitmapImage(new Uri("pack://application:,,,/Images/YFLHC.png"))));
            // 根据列表配置来请求数据
            foreach(TabConfig item in TabConfigs) {
                string jsonParse = JsonSerializer.Serialize(new { limite = 30, lotteryCode = item.Code });
                StringContent content = new StringContent(jsonParse);
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                var response = await HttpHelper.RequestPost<LotteryModel>("https://5981aa.com/melody/api/v1/lotteryperiods/queryHisPeriodsPage", content);
                var history = response.Data.List;
                var currentExpect = history[0].PeriodsNumber.Substring(7);
                var currentResult = item.Code.EndsWith("LHC") ? history[0].LhcDrawingZodiac : history[0].DrawingNumber;
                var previousExpect = history[1].PeriodsNumber.Substring(7);
                var newD = new ObservableCollection<DataHistory>();
                //数据映射
                foreach(LotteryModel his in response.Data.List) {
                    if(item.Code.EndsWith("LHC")) {
                        newD.Add(
                           new DataHistory() { Except = his.PeriodsNumber.Substring(7), OpenDate = his.TheoryDrawingDate, Result = his.LhcDrawingZodiac }
                       );
                    } else {
                        newD.Add(
                       new DataHistory() { Except = his.PeriodsNumber.Substring(7), OpenDate = his.TheoryDrawingDate, Result = his.DrawingNumber }
                   );
                    }

                }

                //填装数据
                this.tabData.Add(new TabContrlViewModel(
                item.Icon,
                item.Title,
                item.Code,
               currentExpect,
                previousExpect,
                leaveTime: "36",
                currentResult,
                newD
                ));

            }
        }

    }

    /// <summary>
    /// tab选项卡 配置
    /// </summary>
    class TabConfig {
        public string Title { get; set; }
        public string Code { get; set; }
        public int Index { get; set; }
        public BitmapImage Icon { get; set; }
        public TabConfig(string title, string code, int index, BitmapImage icon) {
            Title = title;
            Code = code;
            Index = index;
            Icon = icon;
        }
    }
}
