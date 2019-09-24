using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Eblacorp_internal.Commands
{
    class RelayCommand : ICommand
    {
        readonly Action<object> _execute; //this is to prefore the execute
        readonly Predicate<object> _canExecute; // this is to check if the button should light up

        public RelayCommand(Action<object> execute, Predicate<object> canExectue)
        {
            if (execute == null)
                throw new NullReferenceException("execute");

            _execute = execute;
            _canExecute = canExectue;
        }

        // this is incase it is always valid to execute and does not need a predicate
        public RelayCommand(Action<object> execute) : this(execute, null) { }

        //detects changes that would effect canExecute 
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //if _canExecute is null we return true, if not we call the _canExecute(paramter) this is incase
        //we dont have a predicate
        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute.Invoke(parameter);
        }
    }
}
