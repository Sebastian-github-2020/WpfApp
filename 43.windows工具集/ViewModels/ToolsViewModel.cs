using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace _43.windows工具集.ViewModels {
    public class ToolsViewModel : ViewModelBase {
        /// <summary>
        /// 菜单栏
        /// </summary>
        public List<string> Menu { get; set; }
        // 命令
        public MyCommand ShowCommand { get; set; }
        private int myVar;

        public int MyProperty {
            get { return myVar; }
            set { myVar = value; OnPropertyChanged(); }
        }


        public ToolsViewModel() {
            this.Menu = new List<string>() {
            "开关机","刷新dns","更换dns","ping网站"
            };
            ShowCommand = new MyCommand(Show);
        }

        public void Show() {
            MessageBox.Show("ok");
        }
    }
}
