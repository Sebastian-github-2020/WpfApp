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

namespace _34.界面中切换不同的page {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public List<Uri> Urls { get; set; }
        public List<Page> Pages { get; set; }
        public MainWindow() {
            InitializeComponent();
            this.Urls = new List<Uri>();
            this.Urls.Add(new Uri("Pages/Page1.xaml", UriKind.RelativeOrAbsolute));

            this.Pages = new List<Page>();
            this.Pages.Add(new Pages.Page1());

            this.frame.Navigate(this.Pages[0]);
        }

        /// <summary>
        /// 点击切换页面 frame url导航的方式，没法缓存页面数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn1_Click(object sender, RoutedEventArgs e) {
            Button btn = (Button)sender;
            int len = this.Urls.Count;
            if(btn.Name.Equals("btn1")) {

                if(len > 0) {
                    this.frame.Source = this.Urls[0];
                } else {
                    var p1 = new Uri("Pages/Page1.xaml", UriKind.RelativeOrAbsolute);
                    this.frame.Source = p1;
                    this.Urls.Add(p1);
                }

            } else if(btn.Name.Equals("btn2")) {
                if(len > 1) {
                    this.frame.Source = this.Urls[1];
                } else {
                    var p2 = new Uri("Pages/Page2.xaml", UriKind.RelativeOrAbsolute);
                    this.frame.Source = p2;
                    this.Urls.Add(p2);
                }

            } else if(btn.Name.Equals("btn3")) {

                if(len > 2) {
                    this.frame.Source = this.Urls[2];
                } else {
                    var p3 = new Uri("Pages/Page3.xaml", UriKind.RelativeOrAbsolute);
                    this.frame.Source = p3;
                    this.Urls.Add(p3);
                }

            } else {

            }
        }

        /// <summary>
        /// frame 使用navigate导航方式,可以缓存页面内容
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frame_navigate(object sender, RoutedEventArgs e) {
            Button btn = (Button)sender;
            int len = this.Pages.Count;
            if(btn.Name.Equals("btn1")) {

                if(len > 0) {
                    this.frame.Navigate(this.Pages[0]);
                } else {
                    var p1 = new Pages.Page1();
                    this.Pages.Add(p1);
                    this.frame.Navigate(p1);
                }

            } else if(btn.Name.Equals("btn2")) {
                if(len > 1) {
                    this.frame.Navigate(this.Pages[1]);
                } else {
                    var p2 = new Pages.Page2();
                    this.Pages.Add(p2);
                    this.frame.Navigate(p2);
                }

            } else if(btn.Name.Equals("btn3")) {

                if(len > 2) {
                    this.frame.Navigate(this.Pages[2]);
                } else {
                    var p3 = new Pages.Page3();
                    this.Pages.Add(p3);
                    this.frame.Navigate(p3);
                }

            } else {

            }
        }
    }
}
