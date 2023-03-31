using _43.windows工具集.ViewModels;
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

namespace _43.windows工具集 {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            this.DataContext = new ToolsViewModel();
        }
        /// <summary>
        /// 菜单切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuList_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            ListBox lb = (ListBox)sender;
            Debug.WriteLine(sender.GetType().ToString());

        }
    }
}
