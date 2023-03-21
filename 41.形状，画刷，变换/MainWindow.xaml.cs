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

namespace _41.形状_画刷_变换 {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public string MyTitle { get; set; }
        public PointCollection Points { get; set; }
        public MainWindow() {
            InitializeComponent();
            //PointCollection ps = new PointCollection();
            Points = new PointCollection();
            Points.Add(new Point(0, 10));
            Points.Add(new Point(10, 0));
            Points.Add(new Point(20, 30));
            MyTitle = "zaks";
            Debug.WriteLine(MyTitle);
            this.DataContext = new {
                Points = Points,
                MyTitle = MyTitle
            };
        }

    }
}
