
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
            // 根绝切换的index请求对应的数据
            Debug.WriteLine(tab.SelectedItem);
            // 根据索引 请求对应code的数据
            MainModel handle = this.DataContext as MainModel;
            handle.GetHistoryData("嘿嘿嘿", tab.SelectedIndex);
        }
    }
}
