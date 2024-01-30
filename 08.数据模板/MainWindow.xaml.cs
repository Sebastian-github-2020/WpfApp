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

namespace _08.数据模板 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            List<Color> test = new List<Color>();
            test.Add(new Color() { Code = "	#FFB6C1", Name = "LightPink" });
            test.Add(new Color() { Code = "	#DC143C", Name = "Crimson" });
            test.Add(new Color() { Code = "	#FFF0F5", Name = "LavenderBlush" });
            test.Add(new Color() { Code = "	#DB7093", Name = "PaleVioletRed" });
            test.Add(new Color() { Code = "	#FF69B4", Name = "HotPink" });
            test.Add(new Color() { Code = "	#FF1493", Name = "DeepPink" });
            //list.ItemsSource = test;
            this.DataContext = test;
        }
        public struct Color {
            public string Code { get; set; }
            public string Name { get; set; }
        }
    }
}
