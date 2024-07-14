using System.ComponentModel;

namespace WPF_Fancy_CRUD.MVVM.ViewModels
{
    /// <summary>
    /// Ésta es la clase base para todos los modelos de vista (view models). Esta clase implementa la Interfaz INotifyPropertyChanged con el fin de que pueda notificar todos los cambios de propiedad.
    /// </summary>
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        /// <summary>
        /// La interfaz INotifyPropertyChanged tiene un único evento (PropertyChanged) que notifica a los clientes que una propiedad ha cambiado y que deben volver a evaluar sus valores. El tutorial no lo indica, pero agregué ?
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Método para generar evento para cuando una propiedad haya cambiado
        /// </summary>
        /// <param name="propertyName"></param>
        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
