using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace _44.调用cmd执行命令.ViewModels {
    /// <summary>
    /// viewmodel 继承ViewModelBase
    /// </summary>
    public class MainViewModel : ViewModelBase {
        //接收 按钮事件，传递出按钮的命令，这种好处是只需要一个实现事件，坏处是 界面耦合度高
        public MyCommand CmdCommand { get; set; }
        // Process进程对象
        public Process MyProcess { get; set; }
        //富文本的内容
        private string richTextString;

        public string RichTextString {
            get { return richTextString; }
            set { richTextString = value; OnPropertyChanged(); }
        }

        private List<string> texts;
        public List<string> Texts {
            get { return texts; }
            set { texts = value; OnPropertyChanged(); }
        }


        public MainViewModel() {
            this.CmdCommand = new MyCommand(RunCmd);
            this.ConfigProcess();
            this.Texts = new List<string>();
        }

        public void ConfigProcess() {
            this.MyProcess = new Process();
            //1. 指定运行程序
            this.MyProcess.StartInfo.FileName = "cmd.exe";
            //2. 是否使用操作系统的shell启动（明确打开某个程序就为false,）
            this.MyProcess.StartInfo.UseShellExecute = false;
            //3. 接受来自调用程序的输入信息
            this.MyProcess.StartInfo.RedirectStandardInput = true;
            //4. 重定向标准错误输出
            this.MyProcess.StartInfo.RedirectStandardError = true;
            //5. 不显示程序窗口
            this.MyProcess.StartInfo.CreateNoWindow = true;
            // 6. 由调用程序获取输出信息
            this.MyProcess.StartInfo.RedirectStandardOutput = true;


        }
        /// <summary>
        /// 执行点击按钮 传递的cmd命令
        /// </summary>
        /// <param name="command">命令内容</param>
        public void RunCmd(string command) {
            //1. 启动进程
            this.MyProcess.Start();
            // 2. 执行命令
            this.MyProcess.StandardInput.WriteLine(command + "&exit");
            this.MyProcess.StandardInput.AutoFlush = true; // 刷新缓存区
            // 3. 读取返回的内容
            // 3.1 因为cmd返回的内容前面几行是不必要的 所有要剔除掉，因此选择一行一行的读取,
            StringBuilder sb = new StringBuilder();
            string readTmp = "";
            int index = 0;
            do {
                readTmp = this.MyProcess.StandardOutput.ReadLine(); // 读到最后是null
                if(index > 4 && readTmp != null && readTmp.Length > 0) {
                    sb.AppendLine(readTmp);
                    this.texts.Add(readTmp);
                }
                index++;
            } while(readTmp != null);
            // 赋值给 绑定富文本的变量
            this.RichTextString = sb.ToString();
        }
    }
}
