using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace _42.定时关机 {
    public enum WindowOperat {
        SHUTDOWN,//关机
        LOGOUT,//注销
        REBOOT,//重启
        NOOPERATE // 无操作
    }
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public WindowOperat Flag { get; set; }
        //定时器
        private DispatcherTimer Timer { get; }
        //总计的秒数
        public int TotalSeconds { get; set; }
        public MainWindow() {
            InitializeComponent();
            Flag = WindowOperat.NOOPERATE;
            //this.Timer = new DispatcherTimer();
            //this.Timer.Interval = TimeSpan.FromSeconds(1); // 设置工作间隔1秒
            //this.Timer.Tick += timer_Tick;
        }
        /// <summary>
        /// 选择radiobutton
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RadioButton_Click(object sender, RoutedEventArgs e) {
            RadioButton rb = (RadioButton)sender;
            Debug.WriteLine(rb.Name);
            switch(rb.Name) {
                case "shutdown":
                    this.Flag = WindowOperat.SHUTDOWN;
                    break;
                case "logout":
                    this.Flag = WindowOperat.LOGOUT;
                    break;
                case "reboot":
                    this.Flag = WindowOperat.REBOOT;
                    break;
                default:
                    this.Flag = WindowOperat.NOOPERATE;
                    break;

            }
        }
        /// <summary>
        /// 确认执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void confirmBtn_Click(object sender, RoutedEventArgs e) {
            //判定是否选择了操作
            if(this.Flag == WindowOperat.NOOPERATE) {
                MessageBox.Show("请先选择一个操作");
                return;
            }
            //1. 获取时分秒
            int hour = Convert.ToInt32(this.hour.Text) * 3600;
            int minutes = Convert.ToInt32(this.minutes.Text) * 60;
            int seconds = Convert.ToInt32(this.seconds.Text);
            // 总共秒数
            this.TotalSeconds = hour + minutes + seconds;
            if(this.TotalSeconds <= 0) {
                MessageBox.Show("请输入正确的时间");
                return;
            }

            switch(this.Flag) {
                case WindowOperat.SHUTDOWN:
                    Debug.WriteLine("关机");
                    System.Diagnostics.Process.Start("shutdown.exe", $"-s -t {this.TotalSeconds}");
                    break;
                case WindowOperat.LOGOUT:
                    Debug.WriteLine("注销");
                    System.Diagnostics.Process.Start("shutdown.exe", $"-r -t {this.TotalSeconds}");
                    break;
                case WindowOperat.REBOOT:
                    Debug.WriteLine("重启");
                    System.Diagnostics.Process.Start("shutdown.exe", $"-l -t {this.TotalSeconds}");
                    break;
                case WindowOperat.NOOPERATE:
                    break;
                default:
                    break;
            }

            //// 开启定时器
            //this.Timer.Start();
            //this.showTime.Content = $"剩余时间{this.TotalSeconds.ToString()}秒";
        }

        /// <summary>
        /// 定时器 每个间隔执行 方法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void timer_Tick(object sender, EventArgs e) {
            //lblTime.Content = DateTime.Now.ToString("HH:mm:ss.fff");
            this.TotalSeconds--;
            this.showTime.Content = $"剩余时间{this.TotalSeconds.ToString()}秒";
            if(this.TotalSeconds <= 0) {
                this.Timer.Stop();
                // 执行操作
                switch(this.Flag) {
                    case WindowOperat.SHUTDOWN:
                        Debug.WriteLine("关机");
                        System.Diagnostics.Process.Start("shutdown.exe", "-s -t 0");
                        break;
                    case WindowOperat.LOGOUT:
                        Debug.WriteLine("注销");
                        System.Diagnostics.Process.Start("shutdown.exe", "-r -t 0");
                        break;
                    case WindowOperat.REBOOT:
                        Debug.WriteLine("重启");
                        System.Diagnostics.Process.Start("shutdown.exe", "-l -t 0");
                        break;
                    case WindowOperat.NOOPERATE:
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
