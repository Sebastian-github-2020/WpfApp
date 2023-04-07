
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace _48.plane.ViewModel {
    public class MainModel : ViewModelBase {

        private ObservableCollection<TabContrlViewModel> tabData;

        public ObservableCollection<TabContrlViewModel> TabData {
            get { return tabData; }
            set { tabData = value; }
        }


        /// <summary>
        /// 初始化数据
        /// </summary>
        public MainModel() {
            // 初始化tab的数据
            this.TabData = new ObservableCollection<TabContrlViewModel>();
            this.TabData.Add(new TabContrlViewModel(
                new BitmapImage(new Uri("pack://application:,,,/Images/YFLHC.png")),
                "一分六合彩",
                "YFLHC",
                "测试",
                "1087",
                "30",
                 "00,00,00,02,01,23",
                new ObservableCollection<DataHistory>() {
                    new DataHistory { Except = "1056", OpenDate = "2022-15-12", Result = "00 05 12 36 41 02" },
                    new DataHistory { Except = "1057", OpenDate = "2022-15-12", Result = "00 05 12 36 41 02" }
            }));
            this.TabData.Add(new TabContrlViewModel(
                new BitmapImage(new Uri("pack://application:,,,/Images/AMLHC.png")),
                "澳门六合彩",
                "AMLHC",
                "1058",
                "1057",
                leaveTime: "36",
                "00,00,00,02,01,23",
                new ObservableCollection<DataHistory>() {
                    new DataHistory { Except = "1057", OpenDate = "2022-15-12", Result = "00 05 12 36 41 02" },
                    new DataHistory { Except = "1058", OpenDate = "2022-15-13", Result = "00 05 12 36 41 02" },
                    new DataHistory { Except = "1058", OpenDate = "2022-15-13", Result = "00 05 12 36 41 02" },
                    new DataHistory { Except = "1057", OpenDate = "2022-15-12", Result = "00 05 12 36 41 02" },
                    new DataHistory { Except = "1058", OpenDate = "2022-15-13", Result = "00 05 12 36 41 02" },
                    new DataHistory { Except = "1058", OpenDate = "2022-15-13", Result = "00 05 12 36 41 02" },
                    new DataHistory { Except = "1057", OpenDate = "2022-15-12", Result = "00 05 12 36 41 02" },
                    new DataHistory { Except = "1058", OpenDate = "2022-15-13", Result = "00 05 12 36 41 02" },
                    new DataHistory { Except = "1058", OpenDate = "2022-15-13", Result = "00 05 12 36 41 02" },
                    new DataHistory { Except = "1057", OpenDate = "2022-15-12", Result = "00 05 12 36 41 02" },
                    new DataHistory { Except = "1058", OpenDate = "2022-15-13", Result = "00 05 12 36 41 02" },
                    new DataHistory { Except = "1058", OpenDate = "2022-15-13", Result = "00 05 12 36 41 02" }
            }));
        }

    }
}
