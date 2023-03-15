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

namespace _38.依赖项属性.UserConrols {
    /// <summary>
    /// MyButton.xaml 的交互逻辑
    /// </summary>
    public partial class MyButton : UserControl {
        public MyButton() {
            InitializeComponent();
            this.DataContext = this; // 不写这个 无法接收 xaml上穿的值，title是新建的依赖属性 
        }

        // usercontrol 默认的有content属性 而button也有content属性 因此，button 接收不到content内容，
        // 1. 手动覆盖掉userControl的content,
        // 2. 定义新的依赖属性



        // 1.使用覆盖 userControl content的方式
        public new Object Content {
            get {
                Debug.WriteLine(GetValue(ContentProperty));
                return (Object)GetValue(ContentProperty);
            }
            set { SetValue(ContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Content.  This enables animation, styling, binding, etc...
        public new static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(Object), typeof(MyButton), new PropertyMetadata(null));




        // 新建一个依赖属性 来接收 绑定的内容
        public string Title {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(MyButton), new PropertyMetadata(null));
    }
}
