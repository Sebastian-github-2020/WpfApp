using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _43.windows工具集.ViewModels {
    public class ToolsViewModel : ViewModelBase {
        /// <summary>
        /// 菜单栏
        /// </summary>
        public List<string> Menu { get; set; }

        public ToolsViewModel() {
            this.Menu = new List<string>() {
            "开关机","刷新dns","更换dns","ping网站"
            };

        }
    }
}
