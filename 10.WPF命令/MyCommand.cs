using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10.WPF命令 {
    /// <summary>
    /// 所有的命令都要实现这个接口
    /// </summary>
    internal class MyCommand : System.Windows.Input.ICommand {
        public event EventHandler? CanExecuteChanged;
        Action<string?> executeAction;
        public MyCommand(Action<string?> action) {
            executeAction = action;
        }


        public bool CanExecute(object? parameter) {
            if(CanExecuteChanged != null) {
                return true;
            }
            return true;
        }

        public void Execute(object? parameter) {
            executeAction(parameter as string);
        }
    }
}
