using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11.MVVM框架 {
    /// <summary>
    /// 继承ICommand 实现 命令绑定
    /// </summary>
    internal class MyCommands : System.Windows.Input.ICommand {
        public event EventHandler? CanExecuteChanged;
        Action<string> myAction;
        public MyCommands(Action<string> action) {
            myAction = action;
        }
        public bool CanExecute(object? parameter) {
            return true;
        }

        public void Execute(object? parameter) {
            var p = parameter == null ? "" : parameter.ToString();
            myAction(p);
        }
    }
}
