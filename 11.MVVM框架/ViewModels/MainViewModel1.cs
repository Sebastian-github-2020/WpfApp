using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _11.MVVM框架.ViewModels {
    public class MainViewModel1 : ObservableObject {

        private string title = null!;

        public string Title {
            get { return title; }
            set { SetProperty(ref title, value); }
        }
        public RelayCommand ButtonClickCommand { get; } = null!;
        public MainViewModel1() {
            this.Title = "Hello windows1";
            ButtonClickCommand = new RelayCommand(SendMsg);
            // 注册消息监听
            WeakReferenceMessenger.Default.Register<string, string>(this, "windows1", ShowMsg);
        }

        void SendMsg() {

            WeakReferenceMessenger.Default.Send(this.Title, "windows");
            Debug.WriteLine($"windows1发送消息:{this.Title}");
        }
        void ShowMsg(object sender, string msg) {
            Title = msg;
            Debug.WriteLine($"windows1接收消息:{msg}");
        }


    }
}
