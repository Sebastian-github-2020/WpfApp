using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _43.windows工具集.ViewModels {
    public class MyCommand : ICommand {
        // 无参的action
        private Action MyAction { get; set; }
        // 一个参数的action
        private Action<string> MyAction1 { get; set; }

        /// <summary>
        /// 无参数的action
        /// </summary>
        /// <param name="action"></param>
        public MyCommand(Action action) {
            MyAction = action;
        }
        /// <summary>
        /// 一个参数的action
        /// </summary>
        /// <param name="action"></param>
        public MyCommand(Action<string> action) {
            MyAction1 = action;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter) {

            return MyAction != null;
        }

        public void Execute(object parameter) {
            if(this.CanExecuteChanged != null) {
                MyAction();
            }

        }
    }
}
