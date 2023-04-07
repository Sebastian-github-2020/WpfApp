
using _48.plane.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _48.plane {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            // 准备数据
            //this.DataContext = new List<MainModel> {
            // new MainModel {
            //    Title = "一分六合彩",
            //    LotteryCode = "YFLHC",
            //    Icon= new BitmapImage(new Uri("pack://application:,,,/Images/YFLHC.png")),
            //     DataList = new ObservableCollection<DataHistory>()
            //   {
            //        new DataHistory { Except = "1057", OpenDate = "2022-15-12", Result = "00 05 12 36 41 02" },
            //        new DataHistory { Except = "1057", OpenDate = "2022-15-12", Result = "00 05 12 36 41 02" }
            //    }

            //},
            // new MainModel {
            //    Title = "澳门六合彩",
            //    LotteryCode = "AMLHC",
            //     Icon= new BitmapImage(new Uri("pack://application:,,,/Images/AMLHC.png")),
            //    DataList = new ObservableCollection<DataHistory>()
            //   {
            //        new DataHistory { Except = "1057", OpenDate = "2022-15-12", Result = "00 05 12 36 41 02" },
            //        new DataHistory { Except = "1057", OpenDate = "2022-15-12", Result = "00 05 12 36 41 02" }
            //    }

            //}
            //};

            //初始化数据
            this.DataContext = new MainModel();

            // 默认选中0
            this.TabCon.SelectedIndex = 0;

        }
        /// <summary>
        /// 切换tab
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TabCon_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            TabControl tab = (TabControl)sender;
        }
    }
}
