using _33.布局作业.ViewModes;
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


namespace _33.布局作业 {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            List<MainViewModel> users = new List<MainViewModel>();
            users.Add(new MainViewModel { NickName = "大猪", AvaPath = "Images/avatar/1.png", Signature = "天下得猪一般肥", LastDay = "32min" });
            users.Add(new MainViewModel { NickName = "二猪", AvaPath = "Images/avatar/2.png", Signature = "大猪不笑二猪肥", LastDay = "one week" });
            users.Add(new MainViewModel { NickName = "三猪", AvaPath = "Images/avatar/3.png", Signature = "猪瘟猪瘟快快走", LastDay = "three day" });
            users.Add(new MainViewModel { NickName = "四猪", AvaPath = "Images/avatar/4.png", Signature = "应该是乌鸦不笑猪黑吧", LastDay = "2min" });
            users.Add(new MainViewModel { NickName = "五猪", AvaPath = "Images/avatar/5.png", Signature = "别人怎么样我不管，反正我满仓", LastDay = "32min" });
            users.Add(new MainViewModel { NickName = "六猪", AvaPath = "Images/avatar/6.png", Signature = "韭菜啊韭菜 一波一波得割", LastDay = "32min" });
            //给列表绑定数据
            this.listItem.ItemsSource = users;
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e) {
            this.DragMove();
        }
        /// <summary>
        /// 最小化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void minBtn_Click(object sender, RoutedEventArgs e) {
            this.WindowState = WindowState.Minimized;
        }
        /// <summary>
        /// 最大化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void maxBtn_Click(object sender, RoutedEventArgs e) {
            Debug.WriteLine(this.WindowState);
            this.WindowState = this.WindowState == WindowState.Normal ? WindowState.Maximized : WindowState.Normal;

        }
        /// <summary>
        /// 关闭窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeBtn_Click(object sender, RoutedEventArgs e) {
            var res = MessageBox.Show("是否确定要关闭窗口", "警告", MessageBoxButton.YesNo);
            if(res == MessageBoxResult.Yes) {
                // 关闭所有线程
                Environment.Exit(Environment.ExitCode);
                //this.Close();
            }

        }
    }
}
