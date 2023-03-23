using _44.调用cmd执行命令.ViewModels;
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

namespace _44.调用cmd执行命令 {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public System.Diagnostics.Process Process { get; set; }
        public MainWindow() {
            InitializeComponent();
            //this.Process = new System.Diagnostics.Process();
            //this.Config_Process();


            //使用mvvm模式
            this.DataContext = new MainViewModel();
        }

        /// <summary>
        /// 配置Process
        /// </summary>
        private void Config_Process() {
            this.Process.StartInfo.UseShellExecute = false;            //是否使用操作系统shell启动
            this.Process.StartInfo.RedirectStandardInput = true;       //接受来自调用程序的输入信息
            this.Process.StartInfo.RedirectStandardOutput = true;      //由调用程序获取输出信息
            this.Process.StartInfo.RedirectStandardError = true;       //重定向标准错误输出
            this.Process.StartInfo.CreateNoWindow = true;              //不显示程序窗口
        }

        private void OpenCmd_Click(object sender, RoutedEventArgs e) {
            // 这种方式会打开cmd窗口，在窗口中执行命令
            //  System.Diagnostics.Process.Start("cmd.exe", "/k ipconfig");

            // 方法2 不打开窗口，隐藏式执行 读取到返回的内容 写入到指定位子
            string myCommand = "ipconfig";

            this.Custom_Cmd("cmd.exe", myCommand);

        }

        private void Custom_Cmd(string fileName, string command) {
            //执行前先清空富文本内容
            //this.txt.Document.Blocks.Clear();
            this.Process.StartInfo.FileName = fileName;// 指定打开的应用程序
            this.Process.Start();// 启动执行
            this.Process.StandardInput.WriteLine(command + "&exit");
            this.Process.StandardInput.AutoFlush = true;
            // 将内容输出到 richBox
            // 一行一行的读取 将不需要的信息去掉

            int index = 0;
            bool flag = true;
            string readString = "";
            do {
                readString = this.Process.StandardOutput.ReadLine();
                //  Debug.WriteLine($"索引{index}\n{readString}");
                flag = readString != null;
                index++;
                if(index > 5 && readString != null && readString.Length > 0) {
                    Debug.WriteLine($"索引{index}\n{readString}-长度{readString?.Length}");
                    Run r = new Run(readString);
                    Paragraph paragraph = new Paragraph();
                    paragraph.Inlines.Add(r);
                    // this.txt.Document.Blocks.Add(paragraph);
                }



            } while(flag);


            //Run r = new Run(this.Process.StandardOutput.ReadToEnd());
            //Paragraph paragraph = new Paragraph();
            //paragraph.Inlines.Add(r);
            //this.txt.Document.Blocks.Add(paragraph);
        }

        private void FlushDns_Click(object sender, RoutedEventArgs e) {
            string myCommand = "ipconfig/flushdns";

            this.Custom_Cmd("cmd.exe", myCommand);
        }
    }
}
