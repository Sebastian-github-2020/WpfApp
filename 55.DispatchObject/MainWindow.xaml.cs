using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _55.DispatchObject {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();

            // 1. 当前改变按钮的内容的方法是位于主线程，而按钮UI在UI线程，因此会出现异常
            // ChangeTitle();

            //2. 如果在主线程要更新UI线程 则需要使用Dispatcher,当前控件继承DispatchObject 就有这个Dispatcher调度对象

            Task.Run(async () => {
                await Task.Delay(5000);
                this.Dispatcher.Invoke(ChangeTitle);
            });


        }

        private void ChangeTitle() {
            this.btn.Content = "改变标题1";
        }

        private void img_MouseDown(object sender, MouseButtonEventArgs e) {
            MessageBox.Show("image");
        }

        private void btn_Click(object sender, RoutedEventArgs e) {
            MessageBox.Show("enter", "提示", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e) {
            ToggleButton tb = (ToggleButton)sender;
            MessageBox.Show("enter", tb.IsChecked.ToString(), MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e) {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e) {
            CheckBox tb = (CheckBox)sender;
            MessageBox.Show(tb.IsChecked.ToString(), "提示", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        int count = 0;
        //重复按钮
        private void rbtn_Click(object sender, RoutedEventArgs e) {
            Debug.WriteLine($"重复时间:{DateTime.Now.ToLongTimeString()} {DateTime.Now.Millisecond},重复次数:{count++}");
        }
    }
}