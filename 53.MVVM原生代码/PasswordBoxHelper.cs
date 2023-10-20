using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace _53.MVVM原生代码 {
    /// <summary>
    /// 附加属性
    /// </summary>
    public class PasswordBoxHelper {

        
        public static string GetMyPassword(DependencyObject obj) {
            return (string)obj.GetValue(MyPasswprdProperty);
        }

        public static void SetMyPassword(DependencyObject obj, string value) {
            obj.SetValue(MyPasswprdProperty, value);
        }

        // Using a DependencyProperty as the backing store for MyPasswprd.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyPasswprdProperty =
            DependencyProperty.RegisterAttached("MyPassword", typeof(string), typeof(PasswordBoxHelper),new PropertyMetadata(string.Empty,onPasswordPropertyChanged));

        private static void onPasswordPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            var box = d as PasswordBox;
            if(box == null) return; else {
                // 注意 只有 触发 密码框的PasswordChanged事件才会更新数据 直接使用SetMyPassword 不能同步更新
                box.PasswordChanged -= onPwdPropertyChanged;
                var password = (string)e.NewValue;
                if(box.Password != password)
                    box.Password = password;
               //     SetMyPassword(box, box.Password);
               box.PasswordChanged += onPwdPropertyChanged;
            }
          
        }

        private static void onPwdPropertyChanged(object sender, RoutedEventArgs e) {
            var box = sender as PasswordBox;
            if(box == null) return;
            SetMyPassword(box, box.Password);
        }
    }
}
