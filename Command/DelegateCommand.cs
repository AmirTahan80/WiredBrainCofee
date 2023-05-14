using System;
using System.Windows.Input;

namespace WiredBrainCofee.CustumrsApp.Command
{
    class CustomDelegateCommand : ICommand
    {
        private Action<object?> _execute;
        private Func<object?, bool> _canExecute;

        public CustomDelegateCommand(Action<object?> execute,
            Func<object?, bool> canExecute)
        {
            ArgumentNullException.ThrowIfNull(execute);
            _execute = execute;
            _canExecute = canExecute;
        }
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) => _canExecute is null || _canExecute(parameter);

        public void Execute(object? parameter) => _execute?.Invoke(parameter);
    }
}
