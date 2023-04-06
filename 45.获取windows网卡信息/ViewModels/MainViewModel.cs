using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace _45.获取windows网卡信息.ViewModels {
    public class MainViewModel : ViewModelBase {
        private ObservableCollection<NetAdapterInfo> nets;
        public ObservableCollection<NetAdapterInfo> Nets {
            get {
                return nets;
            }
            set {
                Debug.Write("列表数据变化");
                nets = value;
                OnPropertyChanged();
            }
        }

        private string selectedNetAdapter;

        public string SelectedNetAdapter {
            get { return selectedNetAdapter; }
            set { selectedNetAdapter = value; OnPropertyChanged(); }
        }





        public MainViewModel() {
            Debug.WriteLine("创建vm");
            this.Nets = new ObservableCollection<NetAdapterInfo>();
        }

        /// <summary>
        /// 获取本机网卡信息，方法1
        /// 使用静态方法 System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces( )获取网络接口信息
        /// 无法获取到 被禁用的网卡
        /// </summary>
        public void GetNetworkAdapters() {
            NetworkInterface[] nets = NetworkInterface.GetAllNetworkInterfaces();
            foreach(NetworkInterface net in nets) {
                this.Nets.Add(new NetAdapterInfo() { Name = net.Name });
            }
        }

    }




    public class NetAdapterInfo : ViewModelBase {
        private string name;
        public string Name { get { return name; } set { name = value; OnPropertyChanged(); } }
    }

}

