using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _44.调用cmd执行命令.ViewModels {
    /// <summary>
    /// 实现ICommand接口
    /// </summary>
    public class MyCommand : ICommand {
        public event EventHandler CanExecuteChanged;
        Action<string> excuteAction { get; set; }

        /// <summary>
        /// 构造函数接收一个action，注意这里是无参数的action
        /// </summary>
        /// <param name="excuteAction"></param>
        public MyCommand(Action<string> excuteAction) {
            this.excuteAction = excuteAction;
        }

        public bool CanExecute(object parameter) {
            return excuteAction != null;
        }
        /// <summary>
        /// 执行传递的action
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter) {
            Debug.WriteLine($"传入的参数{parameter.ToString()}");
            excuteAction(Convert.ToString(parameter));
        }
    }
}
