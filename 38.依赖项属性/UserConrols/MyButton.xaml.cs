using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace _38.依赖项属性.UserConrols
{
    /// <summary>
    /// MyButton.xaml 的交互逻辑
    /// </summary>
    public partial class MyButton : UserControl
    {
        public MyButton()
        {
            InitializeComponent();
        }

        // usercontrol 默认的有content属性 而button也有content属性 因此，button 接收不到content内容，
        // 1. 手动覆盖掉userControl的content,
        // 2. 定义新的依赖属性



        // 1.使用覆盖 userControl content的方式
        public new object Content
        {
            get
            {
                System.Diagnostics.Debug.WriteLine(GetValue(ContentProperty));
                return (object)GetValue(ContentProperty);
            }
            set { SetValue(ContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Content.  This enables animation, styling, binding, etc...
        public new static readonly DependencyProperty ContentProperty =
            DependencyProperty.Register("Content", typeof(object), typeof(MyButton), new PropertyMetadata(null));




        // 新建一个依赖属性 来接收 绑定的内容
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(MyButton), new PropertyMetadata("默认值"));


        // 图片地址的依赖属性


        public ImageSource ImageUrl
        {
            get { return (ImageSource)GetValue(ImageUrlProperty); }
            set { SetValue(ImageUrlProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImageUrl.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageUrlProperty =
            DependencyProperty.Register("ImageUrl", typeof(ImageSource), typeof(MyButton), new PropertyMetadata(null));



        // 按钮的圆角
        public CornerRadius BntRadio
        {
            get { return (CornerRadius)GetValue(BntRadioProperty); }
            set { SetValue(BntRadioProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BntRadio.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BntRadioProperty =
            DependencyProperty.Register("BntRadio", typeof(int), typeof(MyButton), new PropertyMetadata(null));






        public SolidColorBrush BtnBgc
        {
            get { return (SolidColorBrush)GetValue(BtnBgcProperty); }
            set { SetValue(BtnBgcProperty, value); }
        }

        // Using a DependencyProperty as the backing store for BtnBgc.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BtnBgcProperty =
            DependencyProperty.Register("BtnBgc", typeof(SolidColorBrush), typeof(MyButton), new PropertyMetadata(null));






    }
}
