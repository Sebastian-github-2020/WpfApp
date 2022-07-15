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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Media.Animation;

namespace _24.动画基础 {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }
        /// <summary>
        /// 按钮点击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Click(object sender, RoutedEventArgs e) {
            // 1. 创建动画对象
            DoubleAnimation animation = new DoubleAnimation();
            // 2. 指定起始位置 From和to都可以省略
            //animation.From = Btn.ActualWidth;//ActualWidth 是对象呈现的宽度  width是设定的宽度
            //animation.To = Btn.ActualWidth - 130;

            animation.By = -200; // 不指定起始值 使用by ，下面执行动画 指定了 依赖属性 

            //3. 指定动画事件
            animation.Duration = TimeSpan.FromSeconds(1);
            // 4. 动画 反向播放 运行时间也加倍
            animation.AutoReverse = true;
            // 设置缓动值 开始慢 然后增速
            animation.AccelerationRatio = 1;
            // 设置重复次数 根据参数来决定的 可以传入时间 设置重复的时间 也可以一直重复
            //animation.RepeatBehavior = new RepeatBehavior(2);
            //animation.RepeatBehavior = new RepeatBehavior(TimeSpan.FromSeconds(5));
            animation.RepeatBehavior = RepeatBehavior.Forever;

            // 5. 执行动画
            Btn.BeginAnimation(Button.WidthProperty, animation);



        }
    }
}
