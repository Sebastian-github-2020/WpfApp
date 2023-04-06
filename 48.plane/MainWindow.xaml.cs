using _48.plane.Models;
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

            this.DataContext = new {
                Title = "标题",
                Datas = new ObservableCollection<DataHistory>()
                {
                    new DataHistory { Except = "1057", OpenDate = "2022-15-12", Result = "00 05 12 36 41 02" },
                    new DataHistory { Except = "1057", OpenDate = "2022-15-12", Result = "00 05 12 36 41 02" }
                }
            };
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
