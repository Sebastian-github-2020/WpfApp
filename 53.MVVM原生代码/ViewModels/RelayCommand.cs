using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _53.MVVM原生代码.ViewModels {
    public class RelayCommand : ICommand {

        // 接收 自定义的命令函数
        public Action<object?> MyAction { get;  }


        public RelayCommand(Action<object?> action)
        {
                MyAction = action;
        }

        // 当CanExecute方法被执行了 会调用这个事件刷新 命令的可执行状态
        public event EventHandler? CanExecuteChanged {

            add {
                CommandManager.RequerySuggested += value;
            }
            remove {
                CommandManager.RequerySuggested -= value;
            }
        }

        public bool CanExecute(object? parameter) {
            if(parameter == null) {
                return true;
            } else {
                return (bool)parameter;
            }
        }

        public void Execute(object? parameter) {
            MyAction(parameter);
        }
    }
}
