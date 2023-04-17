using _11.MVVM框架.Pages;
using _11.MVVM框架.ViewModels;
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

namespace _11.MVVM框架 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {


        public MainWindow() {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }

        private void ButtonOpen_Click(object sender, RoutedEventArgs e) {

            var _window = new Window1();
            _window.Show();
        }
    }
}
