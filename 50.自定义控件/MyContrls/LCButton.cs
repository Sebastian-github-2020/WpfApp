﻿using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _50.自定义控件.MyContrls {
    /// <summary>
    /// 按照步骤 1a 或 1b 操作，然后执行步骤 2 以在 XAML 文件中使用此自定义控件。
    ///
    /// 步骤 1a) 在当前项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:_50.自定义控件.MyContrls"
    ///
    ///
    /// 步骤 1b) 在其他项目中存在的 XAML 文件中使用该自定义控件。
    /// 将此 XmlNamespace 特性添加到要使用该特性的标记文件的根
    /// 元素中:
    ///
    ///     xmlns:MyNamespace="clr-namespace:_50.自定义控件.MyContrls;assembly=_50.自定义控件.MyContrls"
    ///
    /// 您还需要添加一个从 XAML 文件所在的项目到此项目的项目引用，
    /// 并重新生成以避免编译错误:
    ///
    ///     在解决方案资源管理器中右击目标项目，然后依次单击
    ///     “添加引用”->“项目”->[浏览查找并选择此项目]
    ///
    ///
    /// 步骤 2)
    /// 继续操作并在 XAML 文件中使用控件。
    ///
    ///     <MyNamespace:LCButton/>
    ///
    /// </summary>
    public class LCButton : Button {

        public new Object Content {
            get { return (Object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }
        public new readonly static DependencyProperty ContentProperty = DependencyProperty.Register("Content", typeof(object), typeof(LCButton), new PropertyMetadata(null));




        public string Title {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(LCButton), new PropertyMetadata("按钮"));





        public CornerRadius CornerRadius {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CornerRadius.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(LCButton), new PropertyMetadata(new CornerRadius(5)));





        public ImageSource MyIcon {
            get { return (ImageSource)GetValue(MyIconProperty); }
            set { SetValue(MyIconProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyIcon.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MyIconProperty =
            DependencyProperty.Register("MyIcon", typeof(ImageSource), typeof(LCButton), new PropertyMetadata(null));




        static LCButton() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LCButton), new FrameworkPropertyMetadata(typeof(LCButton)));
        }
    }
}
