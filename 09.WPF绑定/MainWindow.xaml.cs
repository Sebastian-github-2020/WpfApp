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

namespace _09.WPF绑定 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
            // 绑定数据到上下文 xaml中可以 绑定这个属性
            this.DataContext = new Person() {
                Name = "张三"
            };


        }


        /// <summary>
        /// 选中的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void check_Checked(object sender, RoutedEventArgs e) {
            var s = sender as CheckBox;
            Debug.WriteLine($"选中了：{s.IsChecked}");
        }
        /// <summary>
        /// 取消的事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void check_Unchecked(object sender, RoutedEventArgs e) {
            var s = sender as CheckBox;
            Debug.WriteLine($"取消选中：{s.IsChecked}");
        }
    }
    class Person {
        public string? Name { get; set; }
    }


}
