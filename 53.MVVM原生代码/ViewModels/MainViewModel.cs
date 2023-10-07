using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _53.MVVM原生代码.ViewModels {
    public class MainViewModel:ViewModelBase {

        public RelayCommand LoginCommand { get; set; }

        private bool isChecked;

		public bool IsChecked {
			get { return isChecked; }
			set { 
				isChecked = value;
				
				OnPropertyChanged();
				// 更新命令的可用状态
				LoginCommand.CanExecute(value);
			}
		}

		private string? account;

		public string? Account {
			get { return account; }
			set { account = value; OnPropertyChanged(); }
		}


		private string? password;

		public string? Password {
			get { return password; }
			set { password = value; OnPropertyChanged(); Debug.WriteLine($"密码:{value}"); }
		}



		public MainViewModel() {
			
			LoginCommand = new RelayCommand((obj) => {
				MessageBox.Show("登录","提示");
			});

		}

	}
}
