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

        /// <summary>
        /// Este método se encarga de que la ventana pueda ser movida. El mensaje (SendMessage) notifica al controlador de mensajes de la ventana, que debe ser arrastrado cuando se hace click en el panel y se mueva el mouse sin soltar el botón. Este mensaje se genera cada vez que se mueve cualquier ventana del sistema operativo, así que sipmlemente estamos aprovechando esa función gracias al método nativo del SO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        /// <summary>
        /// Este método se encarga de establecer altura máxima de la ventana, dejando espacio a la barra de tareas de Windows
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else this.WindowState = WindowState.Normal;
        }
    }
}
