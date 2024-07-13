using FontAwesome.Sharp;
using System.Windows.Input;
using WPF_Fancy_CRUD.Db;
using WPF_Fancy_CRUD.MVVM.Models;
using WPF_Fancy_CRUD.MVVM.Models.Interfaces;

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
        private UserModel _usuario;
        private ViewModelBase _vista;
        private string _titulo;
        private IconChar _icono;

        // Propiedades públicas
        public UserModel Usuario
        {
            get
            {
                return _usuario;
            }

            set
            {
                _usuario = value;
                OnPropertyChanged(nameof(Usuario));
            }
        }

        public ViewModelBase Vista
        {
            get => _vista;
            set
            {
                _vista = value;
                // Cada vez que se establece el valor, notificamos que la propiedad ha cambiado para así actualizar la vista
                OnPropertyChanged(nameof(Vista));
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
                OnPropertyChanged(nameof(Icon));
            }
        }

        // COMANDOS. Cada vez que se ejecuta un comando se crea una nueva instancia en la propiedad vista secundaria actual. Esto implica que se pierdan/borren todos los cambios hechos en una sección del admin, por ejemplo si se pone texto en un campo de texto, ese texto se borra al cambiar de sección.

        // Comando 1. Para mostrar la vista de inicio
        public ICommand ShowHomeViewCommand { get; }
        // Comando 2. Para mostrar la vista de clientes
        public ICommand ShowCustomerViewCommand { get; }
        public ICommand ShowUserViewCommand { get; }

        public MainViewModel()
        {
            dbUser = new DbUser();
            Usuario = new UserModel();

            // Se inicializan comandos (en estos casos no hay razón para poner reglas de validación para mostrar las vistas)
            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowCustomerViewCommand = new ViewModelCommand(ExecuteShowCustomerViewCommand);
            ShowUserViewCommand = new ViewModelCommand(ExecuteShowUserViewCommand);

            // Se establece la vista predeterminada
            ExecuteShowHomeViewCommand(null);

            LoadCurrentUserData();
        }

        private void ExecuteShowHomeViewCommand(object obj)
        {
            Vista = new HomeViewModel();
            Titulo = "Dashboard";
            Icono = IconChar.Home;
        }

        private void ExecuteShowCustomerViewCommand(object obj)
        {
            Vista = new CustomerViewModel();
            Titulo = "Clientes";
            Icono = IconChar.UserGroup;
        }

        private void ExecuteShowUserViewCommand(object obj)
        {
            Vista = new UserViewModel();
            Titulo = "Usuarios";
            Icono = IconChar.UserGroup;
        }

        private void LoadCurrentUserData()
        {
            // En el método ExecuteLoginCommand de LoginViewModel.cs se guardó en Thread.CurrentPrincipal el usuario de quien inicia sesión. Con este dato ya podemos aquí recuperar todos los datos del usuario logueado.
            var user = dbUser.GetByUsuario(Thread.CurrentPrincipal.Identity.Name);
            if (user != null)
            {
                Usuario.Usuario = user.Usuario;
                Usuario.Nombre = $"Bienvenido, {user.Nombre} {user.Apellido1}";
                Usuario.Image = null;
            }
            else
            {
                Usuario.Nombre = "Usuario inválido, no logueado.";
            }
        }
    }
}
