using System.Windows;
using WPF_Fancy_CRUD.MVVM.Views;

namespace WPF_Fancy_CRUD
{
    /// <summary>
    /// Lógica de interacción para App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected void IniciarAplicacion(object sender, StartupEventArgs e)
        {
            var loginView = new LoginView();
            loginView.Show();
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
