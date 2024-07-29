using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace WPF_Fancy_CRUD.MVVM.Views
{
    /// <summary>
    /// Lógica de interacción para LoginView.xaml
    /// </summary>
    /// <summary>
    /// Lógica de interacción para LoginView.xaml
    /// </summary>
    public partial class LoginView : Window
    {
        public LoginView()
        {
            InitializeComponent();
            txtUser.Focus();
        }

        /// <summary>
        /// Este método permite mover la ventana cuando se mantenga presionado click izquierdo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        /// <summary>
        /// Si un control tiene asignado este método en su propiedad KeyDown, y si además el control tiene el foco y se da enter, entonces este método ejecuta el comando vinculado con el submit. Así, el usuario tiene dos opciones para enviar el formulario: 1) Dar click al botón submit, y 2) dando enter justo después de poner sus credenciales.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EnviarFormulario(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (btnLogin.Command != null && btnLogin.Command.CanExecute(null))
                {
                    btnLogin.Command.Execute(null);
                }
            }
        }
    }

}
