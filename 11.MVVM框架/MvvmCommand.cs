using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.Input;
namespace _11.MVVM框架 {
    internal class MvvmCommand : IRelayCommand {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) {
            return true;
        }

        public void Execute(object? parameter) {
            throw new NotImplementedException();
        }

        public void NotifyCanExecuteChanged() {
            throw new NotImplementedException();
        }
    }
}
