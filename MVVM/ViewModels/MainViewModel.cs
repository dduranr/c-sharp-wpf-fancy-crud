using FontAwesome.Sharp;
using Microsoft.VisualBasic.Logging;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Channels;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Markup;
using WPF_Fancy_CRUD.Db;
using WPF_Fancy_CRUD.MVVM.Models;
using WPF_Fancy_CRUD.MVVM.Models.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WPF_Fancy_CRUD.MVVM.ViewModels
{
    /// <summary>
    /// Esta clase corresponde con el modelo de vista de la ventana principal.
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        // Interfaces
        private IDbUser dbUser;

        // Propiedades privadas
        private UserModel _usuario = new UserModel {Id="",Usuario="",Contrasena="",Nombre="",Apellido1="",Apellido2="",Email="",Image=""};
        private ViewModelBase _modeloDeVista = new HomeViewModel();
        private string _titulo = "";
        private IconChar _icono;

        /// <summary>
        /// Propiedades públicas (Usuario, ModeloDeVista, Titulo e Icono)
        ///     El método OnPropertyChanged usado en estas propiedades es crucial para implementar MVVM. MVVM separa la lógica de la aplicación (Model), la interfaz de usuario (View) y el puente entre ellas (ViewModel). WPF usa un mecanismo llamado "data binding" para actualizar automáticamente la UI cuando sea que cambien los datos subyacentes.
        ///     La clase ViewModelBase implementa la interfaz INotifyPropertyChanged. Esta interfaz define un evento llamado PropertyChanged que se dispara cuando cambia el valor de una propiedad dentro de cualquier ViewModel que herede de ViewModelBase, como es la presente clase MainViewModel. El método OnPropertyChanged en ViewModelBase es responsable de notificar al sistema de "data binding" que el valor de una propiedad ha cambiado. Toma el nombre de la propiedad (como una cadena) como argumento. Con esto, el sistema "data binding" actualiza automáticamente los elementos UI vinculados a la propiedad en cuestión (controles en la vista).
        /// </summary>
        public UserModel Usuario
        {
            get {return _usuario;}
            set
            {
                _usuario = value;
                OnPropertyChanged(nameof(Usuario));
            }
        }

        public ViewModelBase ModeloDeVista
        {
            get => _modeloDeVista;
            set
            {
                _modeloDeVista = value;
                OnPropertyChanged(nameof(ModeloDeVista));
            }
        }
        public string Titulo
        {
            get => _titulo;
            set
            {
                _titulo = value;
                OnPropertyChanged(nameof(Titulo));
            }
        }
        public IconChar Icono
        {
            get => _icono;
            set
            {
                _icono = value;
                OnPropertyChanged(nameof(Icono));
            }
        }

        // COMANDOS. Cada vez que se ejecuta un comando se crea una nueva instancia en la propiedad vista secundaria actual. Esto implica que se pierdan/borren todos los cambios hechos en una sección del admin, por ejemplo si se pone texto en un campo de texto, ese texto se borra al cambiar de sección.

        // Comando 1. Para mostrar la vista de inicio
        public ICommand ShowHomeViewCommand { get; }
        // Comando 2. Para mostrar la vista de clientes
        public ICommand ShowCustomerViewCommand { get; }
        public ICommand ShowUserViewCommand { get; }

        /// <summary>
        /// Es posible que la clase UserModel tenga un constructor de tipo de referencia que admita valores null. Esto permitiría que Usuario se asigne técnicamente, pero que se siga considerando null, ya que sus propiedades internas podrían no estar inicializadas.
        /// </summary>
        public MainViewModel()
        {
            dbUser = new DbUser();
            Usuario = new UserModel {Id="",Usuario="",Contrasena="",Nombre="",Apellido1="",Apellido2="",Email="",Image=""};

            // Se inicializan comandos (en estos casos no hay razón para poner reglas de validación para mostrar las vistas)
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowCustomerViewCommand = new ViewModelCommand(ExecuteShowCustomerViewCommand);
            ShowUserViewCommand = new ViewModelCommand(ExecuteShowUserViewCommand);

            // Se establece la vista predeterminada
            ExecuteShowHomeViewCommand(null);
            LoadCurrentUserData();
        }

        private void ExecuteShowHomeViewCommand(object? obj)
        {
            ModeloDeVista = new HomeViewModel();
            Titulo = "Dashboard";
            Icono = IconChar.Home;
        }

        private void ExecuteShowCustomerViewCommand(object obj)
        {
            ModeloDeVista = new CustomerViewModel();
            Titulo = "Clientes";
            Icono = IconChar.UserGroup;
        }

        private void ExecuteShowUserViewCommand(object obj)
        {
            ModeloDeVista = new UserViewModel();
            Titulo = "Usuarios";
            Icono = IconChar.UserGroup;
        }

        private void LoadCurrentUserData()
        {
            // En el método ExecuteLoginCommand de LoginViewModel.cs se guardó en Thread.CurrentPrincipal el usuario de quien inicia sesión. Con este dato ya podemos aquí recuperar todos los datos del usuario logueado.
            // TODO: Consider using dependency injection to inject the logged-in user information into MainViewModel instead of relying on Thread.CurrentPrincipal.This can improve testability and make the code more modular.

            if (Thread.CurrentPrincipal != null && Thread.CurrentPrincipal.Identity != null && Thread.CurrentPrincipal.Identity.Name != null)
            {
                var user = dbUser.GetByUsuario(Thread.CurrentPrincipal.Identity.Name);
                Usuario.Usuario = user.Usuario;
                Usuario.Nombre = $"Bienvenido, {user.Nombre} {user.Apellido1}";
                Usuario.Image = "/ruta/a/la/imagen.jpg";
            }
            else
            {
                Usuario.Nombre = "No hay sesión iniciada.";
                //TODO: Hay que hacer algo aquí, el usuario no puede simplemente interactuar normalmente con el dashboard si se lee este ELSE, porque si se lee significa que no estuvo del todo bien el inicio de sesión. la idea es lanzar un MessageBox o algo para que usuario se dé cuenta que algo salió mal y que NO puede visualizar el dashboard del aplicativo, e inmediatamente cerrar la aplicación. El MVVM no permite interactual con la vista desde el modelo de vista, por tanto, Una forma común de manejar esto es crear un servicio que se encargue de cerrar la aplicación...
            }
        }
    }
}
