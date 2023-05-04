using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using _48.plane.Tools;
using _48.plane.HttpRequest;
using System.Text.Json;
using _48.plane.Models;
using System.Diagnostics;

namespace _48.plane {
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window {
        public Login() {
            InitializeComponent();
        }

        //关闭窗口
        private void CancelBtn_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
        // 执行登录
        async private void LoginBtn_Click(object sender, RoutedEventArgs e) {
            Debug.WriteLine("开始登录");
            bool res = await Api.Login(this.account.Text, this.password.Password);
            if(res) {
                var main = new MainWindow();
                main.Show();
                this.Close();
            } else {
                MessageBox.Show("登录失败");
            }
        }
    }
}
