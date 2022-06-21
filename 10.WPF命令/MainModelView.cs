using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _10.WPF命令 {
    internal class MainModelView:ViewModelBase {
        public MyCommand CommandShow { get; set; }
        private string? name;

        public string? Name {
            get { return name; }
            set {
                name = value;
                OnPropertyChanged();
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("name"));
            }
        }


        public MainModelView() {
            // 通过 实现ICommand接口 
            CommandShow = new MyCommand(Show);
            Name = "默认值";
        }

        //public event PropertyChangedEventHandler? PropertyChanged;

        public void Show() {
            // 这里直接修改 ，不会显示到界面上，因为没有同步更新，
            // 为了同步更新 需要实现INotifyPropertyChanged 接口
            Name = "哈哈哈"; 
            MessageBox.Show("点击按钮");
        }
    }
}
