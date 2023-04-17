using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.MVVM框架.ViewModels {
    public class MainViewModel : ObservableObject {

        private string title = null!;

        public string Title {
            get { return title; }
            set { SetProperty(ref title, value); }
        }

        //命令
        public RelayCommand ButtonClickCommand { get; } = null!;

        public MainViewModel() {
            ButtonClickCommand = new RelayCommand(SendMsg);
            Title = "hello msg";
            // 注册消息监听
            WeakReferenceMessenger.Default.Register<string, string>(this, "windows", ShowMsg);
        }

        void SendMsg() {
            WeakReferenceMessenger.Default.Send(Title, "windows1");
            Debug.WriteLine($"windows发送消息:{Title}");
        }
        // 监听消息
        void ShowMsg(object sender, string msg) {
            Debug.WriteLine($"windows接收消息:{Title}");
            Title = msg;
        }

    }
}
