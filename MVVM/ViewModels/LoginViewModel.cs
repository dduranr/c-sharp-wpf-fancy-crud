using System.Diagnostics;
using System.Net;
using System.Security;
using System.Security.Principal;
using System.Windows.Input;
using WPF_Fancy_CRUD.Db;
using WPF_Fancy_CRUD.MVVM.Models.Interfaces;

namespace WPF_Fancy_CRUD.MVVM.ViewModels
{
    public class LoginViewModel : ViewModelBase
    {
        // Se definen propiedades para enlazar la vista con el modelo de vista
        private string _usuario = "";
        private SecureString _contrasena = new SecureString();
        private string _mensajeError = "";
        private bool _vistaEsVisible = true;

        private IDbUser iDbUser; // Ésta no es una propiedad sino la interfaz del usuario

        // Cada vez que se use un setter, o sea, cada vez que se establezca valor a una propiedad, debemos notificar que el valor de la propiedad ha cambiado, es decir, generar un evento. Para lo cual usamos el método OnPropertyChanged de la clase base ViewModelBase.
        public string Usuario
        {
            get => _usuario;
            set
            {
                _usuario = value;
                // El 1er argumento debe ser el nombre de la propiedad. Se puede poner a mano o usando nameof:
                //      1. "Usuario"
                //      2. nameof(Usuario)
                OnPropertyChanged(nameof(Usuario));
            }
        }
        public SecureString Contrasena
        {
            get => _contrasena;
            set
            {
                _contrasena = value;
                OnPropertyChanged(nameof(Contrasena));
            }
        }
        public string MensajeError
        {
            get => _mensajeError;
            set
            {
                _mensajeError = value;
                OnPropertyChanged(nameof(MensajeError));
            }
        }
        public bool VistaEsVisible
        {
            get => _vistaEsVisible;
            set
            {
                _vistaEsVisible = value;
                OnPropertyChanged(nameof(VistaEsVisible));
            }
        }


        // Se definen propiedades de tipo comando para ejecutar las acciones del usuario. Por ejemplo, un comando para ejecutar el inicio de sesión del usuario. Sólo se define el getter, no el setter, ya que no tiene sentido que la vista establezca la acción del comando.
        public ICommand LoginCommand { get; }
        public ICommand RecoverContrasenaCommand { get; }
        public ICommand ShowContrasenaCommand { get; }
        public ICommand RememberContrasenaCommand { get; }


        // En el constructor inicializamos los comandos.
        public LoginViewModel()
        {
            iDbUser = new DbUser();
            // Al ViewModelCommand() se le envían 2 argumentos: un delegado que contenga la función a ejecutar cuando se dispare el evento, y el predicado, para ver si se puede ejecutar el comando, es decir, la función que verificará si las reglas se cumplen para activar/desactivar el control (por ejemplo, se activará el botón para ingresar hasta que los campos estén completados). Sin embargo, existen comandos que no necesitan verificar reglas para activar controles, como el de recuperar password que simplemente es un link que dirige al formulario para recuperar contraseña.
            LoginCommand = new ViewModelCommand(ExecuteLoginCommand, CanExecuteLoginCommand);
            RecoverContrasenaCommand = new ViewModelCommand(p => ExecuteRecoverContrasenaCommand("", ""));
            ShowContrasenaCommand = new ViewModelCommand(p => ExecuteRecoverContrasenaCommand("", ""));
            RememberContrasenaCommand = new ViewModelCommand(p => ExecuteRecoverContrasenaCommand("", ""));
        }

        /// <summary>
        /// Thread.CurrentPrincipal Obtiene o establece la entidad de seguridad actual del subproceso (de la seguridad basada en roles).
        /// GenericPrincipal Representa una entidad de seguridad genérica.
        /// GenericIdentity: Representa un usuario genérico.
        /// </summary>
        /// <param name="obj"></param>
        private void ExecuteLoginCommand(object obj)
        {
            Trace.WriteLine("Se lee ExecuteLoginCommand");
            var isValidUser = iDbUser.AuthenticateUser(new NetworkCredential(Usuario, Contrasena));
            // Si el usuario es válido vamos a registrar y guardar el nombre de usuario para después mostrar sus datos en la vista principal. Para esto se usará la propiedad Thread.CurrentPrincipal. Ésta permite establecer la identidad del usuario que ejecuta el subproceso actual. El 2do argumento de GenericPrincipal es para trabajar los roles. Es decir, en Thread.CurrentPrincipal se guarda el usuario de quien inicia sesión, ya con ese dato guardado en memoria, más adelante se podrá recuperar de la BD la info del usuario logueado, por ejemplo en el método LoadCurrentUserData de MainViewModel.
            if (isValidUser)
            {
                Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(Usuario), null);
                VistaEsVisible = false;
            }
            else
            {
                MensajeError = "* El usuario y/o contraseña no son válidos.";
            }
        }

        // Delegados. Estos métodos son los que se delegan a los comandos. El argumento "object obj" es opcional.
        private bool CanExecuteLoginCommand(object obj)
        {
            if (string.IsNullOrWhiteSpace(Usuario) || Usuario.Length < 3 || Contrasena == null || Contrasena.Length < 3)
            {
                return false;
            }
            return true;
        }

        private void ExecuteRecoverContrasenaCommand(string usuario, string email)
        {
            throw new NotImplementedException();
        }
    }
}
