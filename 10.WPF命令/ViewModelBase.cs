using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _10.WPF命令 {
    /// <summary>
    /// 实现INotifyPropertyChanged 来实现 属性变更 同时更新到界面，这里只是封装了一下 通知方法，给viewmodel继承
    /// </summary>
    internal class ViewModelBase : System.ComponentModel.INotifyPropertyChanged {
        public event PropertyChangedEventHandler? PropertyChanged;
        /// <summary>
        /// 在属性set 里面 调用这个方法
        /// </summary>
        /// <param name="propertyName">属性名</param>
        public void OnPropertyChanged([CallerMemberName]string propertyName="") {  // CallerMemberName使用这个语法糖 可以不用手动传入参数了
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
