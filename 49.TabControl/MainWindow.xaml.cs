using _49.TabControl.ViewModels;
using System;
using System.Collections.Generic;
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

namespace _49.TabControl {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            this.tabs.SelectedIndex = 0;
            this.DataContext = new {
                Devices = new List<Device> { new Device { Name = "设备1", Title = "标题12" }, new Device { Name = "设备2", Title = "标题22" } }
            };
        }
    }

    class Device : ViewModelBase {
        private string name;

        public string Name {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private string title;

        public string Title {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }


    }

}
