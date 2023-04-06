using _48.plane.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _48.plane.ViewModel {
    public class MainModel : ViewModelBase {
        private string tile;

        public string Title {
            get { return tile; }
            set { tile = value; OnPropertyChanged(); }
        }
        //list数据更新 需要将list定义成如下类型 ，因为list本身没有NotifyPropertyChanged接口
        private ObservableCollection<DataHistory> dataList;

        public ObservableCollection<DataHistory> MyProperty {
            get { return dataList; }
            set { dataList = value; OnPropertyChanged(); }
        }

    }
}
