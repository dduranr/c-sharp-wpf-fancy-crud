using System.Security;
using System.Windows;
using System.Windows.Controls;

namespace WPF_Fancy_CRUD.MVVM.Views.CustomControls
{
    /// <summary>
    /// Lógica de interacción para BindablePasswordBox.xaml
    /// </summary>
    public partial class BindablePasswordBox : UserControl
    {
        // Se registra la propiedad PasswordProperty como propiedad de dependencia. El 1er argumento de "Register" es el nombre de la propiedad del LoginViewModel. El 2do param es el tipo de datos de dicha propiedad. eL 3er argumento es el tipo de datos del propietario de la propiedad, que es el nombre de la presente clase
        public static readonly DependencyProperty PasswordProperty = DependencyProperty.Register("Password", typeof(SecureString), typeof(BindablePasswordBox));

        public SecureString Password
        {
            // En este getter devolvemos el valor de la propiedad de dependencia definido anteriormente (PasswordProperty)
            get { return (SecureString)GetValue(PasswordProperty); }
            set { SetValue(PasswordProperty, value); }
        }

        public BindablePasswordBox()
        {
            InitializeComponent();

            // Establecermos el valor del control contraseña en la nueva propiedad de contraseña
            txtPassword.PasswordChanged += OnPasswordChanged;
        }

        private void OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            Password = txtPassword.SecurePassword;
        }
    }
}
