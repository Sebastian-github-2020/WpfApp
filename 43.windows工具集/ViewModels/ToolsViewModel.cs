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
        public List<MenuData> Menus { get; set; }
        // 命令
        public MyCommand ShowCommand { get; set; }
        private int myVar;

        public int MyProperty {
            get { return myVar; }
            set { myVar = value; OnPropertyChanged(); }
        }


        public ToolsViewModel() {
            this.Menus = new List<MenuData>();
            //注意  如果通过绑定 unicode字符需要写成  \ue638  而不是&#xe638; 否则会造成不转义
            this.Menus.Add(new MenuData("首页", "\ue638"));
            this.Menus.Add(new MenuData("任务中心", "\ue63f"));
            this.Menus.Add(new MenuData("人员管理", "\ue645"));
            this.Menus.Add(new MenuData("客户管理", "\ue67e"));
            ShowCommand = new MyCommand(Show);
        }

        public void Show() {
            MessageBox.Show("ok");
        }
    }


    /// <summary>
    /// 菜单模型
    /// </summary>
    public class MenuData : ViewModelBase {
        private string name;

        public string Name {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private string icon;

        public string Icon {
            get { return icon; }
            set { icon = value; OnPropertyChanged(); }
        }

        public MenuData(string name, string icon) {
            this.Name = name;
            this.Icon = icon;
        }


    }
}
