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
using System.Windows.Shapes;

namespace 登录窗体 {
    /// <summary>
    /// Login.xaml 的交互逻辑
    /// </summary>
    public partial class Login : Window {
        public Login() {
            InitializeComponent();
        }

        private void LoginBtn_Click(object sender, RoutedEventArgs e) {
            // 1. 验证账户密码
            if(this.username.Text.Equals("admin") && this.password.Password.Equals("admin")) {
                MessageBox.Show("登录成功");
                // 转到新窗口
                MainWindow mainWindow = new MainWindow();
                //显示新窗口
                mainWindow.Show();
                //关闭当前窗口
                this.Close();
            } else {
                MessageBox.Show("登录失败");
            }
        }
    }
}
