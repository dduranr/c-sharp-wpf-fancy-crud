using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;

namespace WPF_Fancy_CRUD.MVVM.Views
{
    /// <summary>
    /// Interaction logic for MainWindowView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        // Importamos la biblioteca externa user32.dll que permite hacer uso de los eventos del sistema opertivo (en este caso capturar las señales del mouse y enviar mensajes para mover y arrastrar la ventana)
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);



        private void PnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        /// <summary>
        /// Este método se encarga de que la ventana pueda ser movida. El mensaje (SendMessage) notifica al controlador de mensajes de la ventana, que debe ser arrastrado cuando se hace click en el panel y se mueva el mouse sin soltar el botón. Este mensaje se genera cada vez que se mueve cualquier ventana del sistema operativo, así que sipmlemente estamos aprovechando esa función gracias al método nativo del SO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }


        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void BtnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
            {
                this.WindowState = WindowState.Maximized;
                //btnClose.IsEnabled = false;
            }
            else
            {
                this.WindowState = WindowState.Normal;
            }
        }




        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private bool IsMaximized = false;

        private void Border_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                if (IsMaximized)
                {
                    this.WindowState = WindowState.Normal;
                    this.Width = 1080;
                    this.Height = 720;
                    IsMaximized = false;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                    IsMaximized = true;
                }
            }
        }

        /// <summary>
        /// Este método es el listener del menú de ajustes, cuando se da click a alguna de sus opciones
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemAjustes_Click(object sender, EventArgs e)
        {
            if (sender != null)
            {
                string seleccionRaw = sender.ToString() ?? "";
                string[] seleccion = seleccionRaw.Split("System.Windows.Controls.Button: ");

                if (seleccion.Length == 2)
                {
                    switch (seleccion[1])
                    {
                        case "Ajustes":
                            Trace.WriteLine("Seleccionaste AJUSTES");
                            break;
                        case "Mi cuenta":
                            Trace.WriteLine("Seleccionaste Mi cuenta");
                            break;
                        case "Ayuda":
                            Trace.WriteLine("Seleccionaste Ayuda");
                            break;
                        case "Cerrar sesión":
                            CerrarSesion();
                            break;
                    }
                }
            }
        }

        private void LinkLogout_Click(object sender, EventArgs e)
        {
            CerrarSesion();
        }

        private void CerrarSesion()
        {
            var loginView = new LoginView();
            loginView.Show();
            this.Close();
        }

    }
}
