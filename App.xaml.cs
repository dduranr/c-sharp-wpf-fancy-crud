using System.Windows;
using WPF_Fancy_CRUD.MVVM.Views;

// SIGO AQUÍ
// SIGO AQUÍ
// SIGO AQUÍ
//          Documentar bien este código
//          En MainView.xaml.cs intentar cambiar a true la visibilidad de loginView al cerrar el mainView



namespace WPF_Fancy_CRUD
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void IniciarAplicacion(object sender, StartupEventArgs e)
        {
            //var loginView = new LoginView();
            //loginView.Show();
            //loginView.Closed += (s, ev) =>
            //{
            //    var mainView = new MainView();
            //    mainView.Show();
            //};


            var loginView = new LoginView();
            loginView.Show();

            // Usando una expresión lambda se adjunta un manejador de eventos para que nosotros hagamos algo en caso que cambie la visibilidad de loginView
            loginView.IsVisibleChanged += (s, ev) =>
            {
                if (loginView.IsVisible == false && loginView.IsLoaded)
                {
                    var mainView = new MainView();
                    mainView.Show();
                    loginView.Close();
                }
            };
        }
    }

}
