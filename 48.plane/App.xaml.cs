using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace _48.plane {
    /// <summary>
    /// App.xaml 的交互逻辑
    /// </summary>
    public partial class App : Application {

        protected override void OnStartup(StartupEventArgs e) {
            // 设置等待页面
            //SplashScreen splashScreen = new SplashScreen("Images/icon.png");
            //splashScreen.Show(true);
            base.OnStartup(e);
        }
    }
}
