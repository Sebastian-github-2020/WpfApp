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

namespace _29.代码实现故事板 {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void Btn_Click(object sender, RoutedEventArgs e) {
            // 创建两个 动画
            DoubleAnimation btnAnimation = new DoubleAnimation(500, TimeSpan.FromSeconds(2));
            btnAnimation.From = Btn.ActualWidth;


            DoubleAnimation btnAnimation1 = new DoubleAnimation(300, TimeSpan.FromSeconds(2));
            btnAnimation1.From = Btn.ActualHeight;


            // 创建故事板
            Storyboard storyboard = new Storyboard();

            // 使用Storyboard 类 指定运行动画的xaml节点的name 
            Storyboard.SetTargetName(storyboard, "Btn");
            // 设置依赖的属性
            Storyboard.SetTargetProperty(btnAnimation, new PropertyPath(Button.WidthProperty));

            Storyboard.SetTargetName(storyboard, "Btn");
            Storyboard.SetTargetProperty(btnAnimation1, new PropertyPath(Button.HeightProperty));

            // 设置 故事板属性
            storyboard.Duration = TimeSpan.FromSeconds(2);
            storyboard.AutoReverse = true;
            storyboard.RepeatBehavior = RepeatBehavior.Forever;

            // 添加动画到故事板
            storyboard.Children.Add(btnAnimation);
            storyboard.Children.Add(btnAnimation1);

            // 执行故事板
            storyboard.Begin(this);
        }
    }
}
