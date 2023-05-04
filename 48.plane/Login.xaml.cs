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
            using(HttpClient httpClient = new HttpClient()) {
                // 设置header
                string uuid = Tool.MakeUUID();
                httpClient.DefaultRequestHeaders.Add("x-auth-uu", uuid);
                httpClient.DefaultRequestHeaders.Add("x-auth-sign", Tool.MakeSign(uuid, "9&N4orgck9M!rh2#Wpfyg2Q!teDds8Bl"));
                var a = httpClient.DefaultRequestHeaders;
                // 添加
                httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                string jsonParse = JsonSerializer.Serialize(new { memberAccount = this.account.Text, password = this.password.Password, zhuakuaiValidate = "" });
                StringContent content = new StringContent(jsonParse);

                //var response = await httpClient.PostAsync("https://httpbin.org/post", content);
                var response = await httpClient.PostAsync("https://5981aa.com/melody/api/v1/memberuser/login", content);
                if(response.IsSuccessStatusCode) {
                    // 读取返回的内容
                    string res = await response.Content.ReadAsStringAsync();
                    LoginResponseModel lrm = JsonSerializer.Deserialize<LoginResponseModel>(res);
                    Debug.WriteLine(res);
                    if(lrm.Code.Equals("12200")) {
                        Debug.WriteLine("登录成功");
                        // 登录成功 读取header里面的token

                        foreach(var item in response.Headers) {
                            Debug.WriteLine(item);
                        }
                    } else {
                        foreach(var item in response.Headers) {
                            Debug.WriteLine(item.Key);
                        }
                        MessageBox.Show(lrm.Msg);
                    }

                    httpClient.Dispose();
                }
            }
        }
    }
}
