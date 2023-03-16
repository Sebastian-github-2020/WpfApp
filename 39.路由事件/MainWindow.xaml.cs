using System;
using System.Collections.Generic;
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

namespace _39.路由事件 {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void btn_Click(object sender, RoutedEventArgs e) {
            Debug.WriteLine($"触发事件者{sender.ToString()}--事件源{e.Source.ToString()}");
            e.Handled = true; // 让冒泡事件 变成捕获事件(隧道路由) 不再向上传递事件了 ，仅在当前元素上响应内容
        }

        private void yesNoClick(object sender, RoutedEventArgs e) {
            Debug.WriteLine($"触发事件者{sender.ToString()}--事件源{e.Source.ToString()}");

        }
    }
}
