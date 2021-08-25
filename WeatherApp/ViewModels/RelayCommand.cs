using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WeatherApp.ViewModels
{
    public class RelayCommand : ICommand
    {
        private readonly Func<Task> _execute;
        private readonly Func<bool> _canExecute;
        private readonly EventHandler _handler;
        private bool _isExecuting;

        public RelayCommand(Func<Task> execute,
            Func<bool> canExecute = null,
            EventHandler handler = null)
        {
            _execute = execute;
            _canExecute = canExecute;
            _handler = handler;
        }

        public bool CanExecute(object parameter)
        {
            return !_isExecuting && (_canExecute?.Invoke() ?? true);
        }

        public async void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                try
                {
                    _isExecuting = true;
                    await _execute();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    _isExecuting = false;
                    throw;
                } 
            }

            if (_handler is not null) RaiseCanExecuteChanged();
            _isExecuting = false;
        }

        public event EventHandler CanExecuteChanged;

        private void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}