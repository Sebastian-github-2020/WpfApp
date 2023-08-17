using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace _52.转换器Conver {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }


    }

    /// <summary>
    /// 自定义转换器
    /// </summary>
    public class BooleanTostring : IValueConverter {
        #region 当界面绑定的数据源值变化，就通过这个方法转换成为 接收数据源控件能够支持显示的值 
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return ((Boolean)value) ? "我学，我学还不行吗！" : "太tmd繁琐了不学";
        }
        #endregion


        #region 和上面的方法一样，只是数据流方向是相反的。 这种情况出现在双向绑定的情况   接收数据的控件数据改变，转换后 返回给数据源
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            string s = (string)value;
            if(s == "我学，我学还不行吗！") {
                return true;
            } else {
                return false;
            }
        }
        #endregion
    }
}
