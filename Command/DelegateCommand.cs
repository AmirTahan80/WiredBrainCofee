using System;
using System.Windows.Input;

namespace WiredBrainCofee.CustumrsApp.Command
{
    public class CustomDelegateCommand : ICommand
    {
        #region Properties
        public event EventHandler? CanExecuteChanged;
        private Action<object?> _execute;
        private Func<object?, bool>? _canExecute;
        #endregion

        #region Constructors
        public CustomDelegateCommand(Action<object?> execute,
            Func<object?, bool>? canExecute=null)
        {
            ArgumentNullException.ThrowIfNull(execute);
            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion

        #region Methods
        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        public void Execute(object? parameter) => _execute?.Invoke(parameter);
        public bool CanExecute(object? parameter) => _canExecute is null || _canExecute(parameter);
        #endregion
    }
}
