using System.Windows.Input;

namespace WPF_Fancy_CRUD.MVVM.ViewModels
{
    /// <summary>
    /// Esta clase delega los comandos de la vista al modelo de vista.
    /// Normalmente a esta clase se le llama RelayCommand. Pero aquí se llamará ViewModelCommand.
    /// Al instanciar esta clase, se le pasan los argumentos necesarios para darle funcionalidad a un control, por ejemplo un botón: mediante los argumentos se indica qué función debe ejecutar el botón y qué reglas deben cumplirse para que ese botón se active/desactive.
    /// </summary>
    internal class ViewModelCommand : ICommand
    {
        /// <summary>
        /// Se define campo de tipo action para ejecutar los comandos. El delegado action se usa para encapsular un método, es decir, para pasar un método como parámetro. Esta propiedad es la que recibirá el método a ejecutar cuando se presione un botón.
        /// </summary>
        private readonly Action<object> _executeAction;

        /// <summary>
        /// Se define campo de tipo predicate para determinar si la acción se puede ejecutar o no. Este delegado permite que el control se habilite/deshabilite en función de si se puede ejecutar su comando.
        /// </summary>
        private readonly Predicate<object> _canExecuteAction;

        /// <summary>
        /// Constructor sin predicado (canExecuteAction). Ya que no todos los comandos deben ser validados para verificar si debe ejecutarse la acción.
        /// </summary>
        /// <param name="executeAction"></param>
        public ViewModelCommand(Action<object> executeAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = null;
        }

        /// <summary>
        /// Constructor con ambos parámetros: executeAction y canExecuteAction.
        /// </summary>
        /// <param name="executeAction"></param>
        /// <param name="canExecuteAction"></param>
        public ViewModelCommand(Action<object> executeAction, Predicate<object> canExecuteAction)
        {
            _executeAction = executeAction;
            _canExecuteAction = canExecuteAction;
        }



        /// <summary>
        /// Este evento forma parte de la implementación de ICommand.
        /// Subscribimos o damos de baja el evento RequerySuggested según sea necesario.
        /// El evento RequerySuggested se produce cuando el administrador de comandos detecta si la condición de ejecución del comando ha cambiado
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Este evento forma parte de la implementación de ICommand.
        /// Si _canExecuteAction es nulo devuleve siempre TRUE ya que no se ha establecido el predicaco de validación (1er constructor). Es decir, si no hay reglas de validación para habilitar/deshabilitar el control, éste siempre validará. De lo contrario, si sí hay reglasentonces devolvemos el valor del delegado predicado, o sea, de la validación (2do constructor).
        /// </summary>
        public bool CanExecute(object parameter)
        {
            return (_canExecuteAction == null) ? true : _canExecuteAction(parameter);
        }

        /// <summary>
        /// Este evento forma parte de la implementación de ICommand.
        /// Este método es el encargado de ejecutar la acción del control en cuestión.
        /// </summary>
        public void Execute(object parameter)
        {
            _executeAction(parameter);
        }
    }

}
