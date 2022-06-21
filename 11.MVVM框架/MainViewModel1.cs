using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;// viewmodel
using System.Windows.Input; // 绑定命令的
using Microsoft.Toolkit.Mvvm.Messaging; // 消息机制，和 vue里面 $emit很像 ，先注册一个消息类型，然后其他地方 发送一个此类型的消息
using System.Diagnostics;
namespace _11.MVVM框架 {
    /// <summary>
    /// 使用了Microsoft.Toolkit.Mvvm 框架 实现MVVM 
    /// </summary>
    internal class MainViewModel1 : ObservableObject {
        private string? name;
        public MyCommands CommandShow1 { get; set; }
        /// <summary>
        /// 使用 框架 不用再去 自己继承Icommand 了
        /// </summary>
        public ICommand CommandShow2 { get; set; }
        //public MyCommands CommandShow;
        public string? Name1 {
            get => name;
            set => SetProperty(ref name, value);
        }

        public MainViewModel1() {
            Name1 = "默认值";
            CommandShow1 = new MyCommands(Show);
            // 命令 绑定函数
            CommandShow2 = new MyCommands(Show);
            // 注册消息  
            WeakReferenceMessenger.Default.Register<string, string>(this, "show", OnRecive);
        }

        /// <summary>
        /// command 关联的方法
        /// </summary>
        public void Show(string p) {
            //Name1 = "修改后同步更新";
            //MessageBox.Show(p);
            WeakReferenceMessenger.Default.Send<string, string>(p, "show");
        }
        public void OnRecive(object recpient, string message) {
            Trace.Write(recpient);
            MessageBox.Show($"收到的消息:{message}");
        }

    }
}
