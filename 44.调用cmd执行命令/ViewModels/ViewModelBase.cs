using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _44.调用cmd执行命令.ViewModels {
    /// <summary>
    /// 实现了INotifyPropertyChanged接口，用来实现界面xaml绑定属性的双向更新
    /// 如：TextBox绑定了 Name属性，界面上修改同时更新到绑定的属性上
    /// </summary>
    public class ViewModelBase : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// CallerMemberName 这个装饰器 可以自动识别当前域的属性名，免去手写
        /// </summary>
        /// <param name="propertyName"></param>
        public void OnPropertyChanged([CallerMemberName] string propertyName = "") {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
