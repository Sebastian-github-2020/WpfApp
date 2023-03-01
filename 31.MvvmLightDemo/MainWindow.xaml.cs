using _31.MvvmLightDemo.Models;
using _31.MvvmLightDemo.Services;
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

namespace _31.MvvmLightDemo {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public StudentService service { get; set; }
        List<StudentModel> students { get; set; }
        public MainWindow() {
            InitializeComponent();
            this.students = new List<StudentModel>()
            {
                new StudentModel() {Id=1,Name="zaks"},
                new StudentModel() {Id=2,Name="link"},
                new StudentModel() {Id=3,Name="sephiroth"},
                new StudentModel() {Id=4,Name="behimoth"},
            };
            this.DataContext = new { List = this.students };

            // 初始化studentServices
            this.service = new StudentService();
            service.Students = this.students;

        }

        private void search_Click(object sender, RoutedEventArgs e) {
            this.DataContext = new { List = this.service.searchStudent(this.keywords.Text) };
            Debug.WriteLine($"初始数据长度:{this.students.Count}");
        }

        private void reset_Click(object sender, RoutedEventArgs e) {
            this.DataContext = new { List = this.service.resetStudent() };
            Debug.WriteLine($"初始数据长度:{this.students.Count}");
        }

        private void add_Click(object sender, RoutedEventArgs e) {
            //this.dataGrid.
        }
    }
}
