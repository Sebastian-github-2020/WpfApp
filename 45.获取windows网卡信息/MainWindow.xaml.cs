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
using System.Net.NetworkInformation;
using _45.获取windows网卡信息.ViewModels;
using System.Diagnostics;

namespace _45.获取windows网卡信息 {
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window {


        public MainViewModel Vm { get; set; }
        public MainWindow() {
            InitializeComponent();
            Debug.WriteLine("初始化对象");
            // this.Nets = new List<string>();
            this.Vm = new MainViewModel();
            this.DataContext = this.Vm;
            //Debug.WriteLine($"vm对象Nets长度{this.Vm.Nets.Count.ToString()}");

        }
        /// <summary>
        /// 获取本机 真实网卡信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void network_Click(object sender, RoutedEventArgs e) {
            this.GetNetworkAdapters();
        }
        /// <summary>
        /// 获取本机网卡信息，方法1
        /// 使用静态方法 System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces( )获取网络接口信息
        /// 无法获取到 被禁用的网卡
        /// </summary>
        public void GetNetworkAdapters() {
            Debug.WriteLine("获取网卡");
            var tmpList = new List<NetAdapterInfo>();
            Debug.WriteLine($"vm对象Nets长度{this.Vm.Nets.Count.ToString()}");
            NetworkInterface[] nets = NetworkInterface.GetAllNetworkInterfaces();
            //foreach(NetworkInterface net in nets) {
            //    Debug.WriteLine(net.Name);
            //    tmpList.Add(new NetAdapterInfo() { Name = net.Name });
            //}
            //Debug.WriteLine($"最终m对象Nets长度{this.Vm.Nets.Count.ToString()}");
            //this.Vm.Nets = tmpList;//因为对象是引用类型



            foreach(NetworkInterface net in nets) {
                Debug.WriteLine(net.Name);
                this.Vm.Nets.Add(new NetAdapterInfo() { Name = net.Name });
            }

        }
        /// <summary>
        /// 列表选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ll_Selected(object sender, RoutedEventArgs e) {
            ListBox box = (ListBox)sender;
            NetAdapterInfo infoItem = (NetAdapterInfo)box.SelectedItem;
            Debug.WriteLine(infoItem.Name);
            this.Vm.SelectedNetAdapter = infoItem.Name;
        }
    }
}
