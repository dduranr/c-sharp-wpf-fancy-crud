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
        private UserModel _usuario = new UserModel { Id = 0, Usuario = "", Contrasena = "", Nombre = "", Apellido1 = "", Email = "" };
        private ViewModelBase _modeloDeVista = new HomeViewModel();
        private string _titulo = "";
        private IconChar _icono;

        /// <summary>
        /// Propiedades públicas (Usuario, ModeloDeVista, Titulo e Icono)
        ///     Todas están bindeadas en la vista MainView.xaml.
        ///     WPF usa un mecanismo llamado "data binding" para actualizar automáticamente la UI cuando sea que cambien los datos subyacentes (propiedades en code-behind o controlador o view model).
        ///     La clase ViewModelBase implementa la interfaz INotifyPropertyChanged. Esta interfaz define un evento llamado PropertyChanged que se dispara cuando cambia el valor de una propiedad dentro de cualquier ViewModel que herede de ViewModelBase, como es la presente clase MainViewModel. El método OnPropertyChanged en ViewModelBase es responsable de notificar al sistema de "data binding" que el valor de una propiedad ha cambiado. En el view model este método toma el nombre de la propiedad (como una cadena) como argumento. Con esto, el sistema "data binding" actualiza automáticamente los elementos UI vinculados a la propiedad en cuestión.
        /// </summary>
        public UserModel Usuario
        {
            get { return _usuario; }
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

        // COMANDOS
        public ICommand ShowHomeViewCommand { get; }
        public ICommand ShowCustomerViewCommand { get; }
        public ICommand ShowUserViewCommand { get; }

        /// <summary>
        /// Este es el modelo de vista de la home del aplicativo.
        /// </summary>
        public MainViewModel()
        {
            dbUser = new DbUser();
            Usuario = new UserModel { Id = 0, Usuario = "", Contrasena = "", Nombre = "", Apellido1 = "", Email = "" };

            ShowHomeViewCommand = new ViewModelCommand(ExecuteShowHomeViewCommand);
            ShowCustomerViewCommand = new ViewModelCommand(ExecuteShowCustomerViewCommand);
            ShowUserViewCommand = new ViewModelCommand(ExecuteShowUserViewCommand);

            // Ejecutamos un comando, el que sea, con el fin de establecer una vista predeterminada
            ExecuteShowHomeViewCommand(null);
            LoadCurrentUserData();
        }

        /// <summary>
        /// Los siguientes métodos privados son las funciones Execute que se ejecutan cuando un comando sea llamado. Como se puede apreciar, cada vez que se ejecuta un comando se crea una nueva instancia del modelo de vista en cuestión, esto implica que cualquier cosa que se haya hecho en una vista (y no se haya guardado), por ejemplo poner un texto en un TextBox, se pierde o borra. De tal manera que si el usuario regresa a esa misma sección del aplicativo obviamente no verá los cambios que puso.
        /// TODO. Para solucionar el problema mencionado aquí arriba pueden hacerse dos cosas: 1) automáticamente guardar los datos que el usuario haya puesto y sólo después saltar a la otra vista a la que el usuario quiere ir, o 2) ver la forma de hacer que la info no guardada se guarde en algo así como datos de sesión
        /// </summary>
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
            Icono = IconChar.UsersGear;
        }

        private void LoadCurrentUserData()
        {
            // En el método ExecuteLoginCommand de LoginViewModel.cs se guardó en Thread.CurrentPrincipal el usuario de quien inicia sesión. Con este dato ya podemos aquí recuperar todos los datos del usuario logueado.
            // TODO: Consider using dependency injection to inject the logged-in user information into MainViewModel instead of relying on Thread.CurrentPrincipal.This can improve testability and make the code more modular.

            if (Thread.CurrentPrincipal != null && Thread.CurrentPrincipal.Identity != null && Thread.CurrentPrincipal.Identity.Name != null)
            {
                var user = dbUser.GetByUsuario(Thread.CurrentPrincipal.Identity.Name);
                string NombreUsuario = user?.Usuario ?? "No disponible";
                string ApelleidoUsuario = user?.Apellido1 ?? "No disponible";
                Usuario.Usuario = NombreUsuario;
                Usuario.Nombre = $"Bienvenido, {NombreUsuario} {ApelleidoUsuario}";
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
