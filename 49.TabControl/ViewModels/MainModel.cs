using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _49.TabControl.ViewModels {
    public class MainModel : ViewModelBase {
        private string Name;

        public string name {
            get { return Name; }
            set { Name = value; OnPropertyChanged(); }
        }



        private string Title;

        public string title {
            get { return Title; }
            set { Title = value; OnPropertyChanged(); }
        }

    }
}
