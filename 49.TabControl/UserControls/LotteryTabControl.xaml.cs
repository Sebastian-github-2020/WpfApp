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

namespace _49.TabControl.UserControls {
    /// <summary>
    /// LotteryTabControl.xaml 的交互逻辑
    /// </summary>
    public partial class LotteryTabControl : UserControl {
        public string Title {
            get { return (string)GetValue(titleProperty); }
            set {
                SetValue(titleProperty, value);
            }
        }
        public static readonly DependencyProperty titleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(LotteryTabControl), new UIPropertyMetadata("", OnpropertChanged));





        public LotteryTabControl() {
            InitializeComponent();

            //this.DataContext = this;

        }
        /// <summary>
        /// 属性值发生变化 的回调函数
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        private static void OnpropertChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            LotteryTabControl lt = (LotteryTabControl)d;
            Debug.WriteLine($"属性变化{lt.Title}");
        }
    }
}
