using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;

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

            var converter = new BrushConverter();
            ObservableCollection<Member> members = new ObservableCollection<Member>();


            // Create datagrid items info
            members.Add(new Member { Number = "1", Character = "A", Name = "Parménides", Position = "Administrador", Email = "parménides@gmail.com", Phone = "5551895555" });
            members.Add(new Member { Number = "2", Character = "B", Name = "Heráclito", Position = "Editor", Email = "heráclito@gmail.com", Phone = "5551895512" });
            members.Add(new Member { Number = "3", Character = "C", Name = "Anaxágoras", Position = "Staff", Email = "anaxágoras@gmail.com", Phone = "5551895544" });
            members.Add(new Member { Number = "4", Character = "D", Name = "Anaxímenes", Position = "Staff", Email = "anaxímenes@gmail.com", Phone = "5551895598" });
            members.Add(new Member { Number = "5", Character = "E", Name = "Anaximandro", Position = "Administrador", Email = "anaximandro@gmail.com", Phone = "5551895538" });
            members.Add(new Member { Number = "6", Character = "F", Name = "Tales", Position = "Editor", Email = "tales@gmail.com", Phone = "5551895574" });
            members.Add(new Member { Number = "7", Character = "G", Name = "Hesíodo", Position = "Administrador", Email = "hesíodo@gmail.com", Phone = "5551895522" });
            members.Add(new Member { Number = "8", Character = "H", Name = "Eurípides", Position = "Staff", Email = "eurípides@gmail.com", Phone = "55518955578" });
            members.Add(new Member { Number = "9", Character = "I", Name = "Sófocles", Position = "Administrador", Email = "sófocles@gmail.com", Phone = "5551895531" });
            members.Add(new Member { Number = "10", Character = "J", Name = "Esquilo", Position = "Staff", Email = "esquilo@gmail.com", Phone = "5551895500" });

            members.Add(new Member { Number = "11", Character = "K", Name = "Solón", Position = "Administrador", Email = "solón@gmail.com", Phone = "5551895555" });
            members.Add(new Member { Number = "12", Character = "L", Name = "Biante", Position = "Editor", Email = "biante@gmail.com", Phone = "5551895512" });
            members.Add(new Member { Number = "13", Character = "M", Name = "Epiménides", Position = "Staff", Email = "epiménides@gmail.com", Phone = "5551895544" });
            members.Add(new Member { Number = "14", Character = "N", Name = "Arquelao", Position = "Staff", Email = "arquelao@gmail.com", Phone = "5551895598" });
            members.Add(new Member { Number = "15", Character = "O", Name = "Sócrates", Position = "Administrador", Email = "sócrates@gmail.com", Phone = "5551895538" });
            members.Add(new Member { Number = "16", Character = "P", Name = "Platón", Position = "Editor", Email = "platón@gmail.com", Phone = "5551895574" });
            members.Add(new Member { Number = "17", Character = "Q", Name = "Aristóteles", Position = "Administrador", Email = "aristóteles@gmail.com", Phone = "5551895522" });
            members.Add(new Member { Number = "18", Character = "R", Name = "Santo Tomás de Aquino", Position = "Editor", Email = "aquino@gmail.com", Phone = "55518955578" });
            members.Add(new Member { Number = "19", Character = "S", Name = "Descartes", Position = "Administrador", Email = "descartes@gmail.com", Phone = "5551895531" });
            members.Add(new Member { Number = "20", Character = "T", Name = "Arthur Schopenhauer", Position = "Staff", Email = "schopenhauer@gmail.com", Phone = "5551895500" });

            members.Add(new Member { Number = "21", Character = "U", Name = "Leibniz", Position = "Administrador", Email = "leibniz@gmail.com", Phone = "5551895555" });
            members.Add(new Member { Number = "22", Character = "V", Name = "Spinoza", Position = "Editor", Email = "spinoza@gmail.com", Phone = "5551895512" });
            members.Add(new Member { Number = "23", Character = "W", Name = "Shelling", Position = "Staff", Email = "shelling@gmail.com", Phone = "5551895544" });
            members.Add(new Member { Number = "24", Character = "X", Name = "Hegel", Position = "Staff", Email = "hegel@gmail.com", Phone = "5551895598" });
            members.Add(new Member { Number = "25", Character = "Y", Name = "Marx", Position = "Administrador", Email = "marx@gmail.com", Phone = "5551895538" });
            members.Add(new Member { Number = "26", Character = "Z", Name = "Sartre", Position = "Editor", Email = "sartre@gmail.com", Phone = "5551895574" });
            members.Add(new Member { Number = "27", Character = "AA", Name = "Le Maitre", Position = "Administrador", Email = "maitre@gmail.com", Phone = "5551895522" });
            members.Add(new Member { Number = "28", Character = "AB", Name = "Luis Villoro", Position = "Staff", Email = "villoro@gmail.com", Phone = "55518955578" });
            members.Add(new Member { Number = "29", Character = "AC", Name = "Popper", Position = "Administrador", Email = "popper@gmail.com", Phone = "5551895531" });
            members.Add(new Member { Number = "30", Character = "AD", Name = "Max Weber", Position = "Staff", Email = "max@gmail.com", Phone = "5551895500" });

            membersDatagGrid.ItemsSource = members;
        }

        // Importamos la biblioteca externa user32.dll que permite hacer uso de los eventos del sistema opertivo (en este caso capturar las señales del mouse y enviar mensajes para mover y arrastrar la ventana)
        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        /// <summary>
        /// Este método se encarga de que la ventana pueda ser movida. El mensaje (SendMessage) notifica al controlador de mensajes de la ventana, que debe ser arrastrado cuando se hace click en el panel y se mueva el mouse sin soltar el botón. Este mensaje se genera cada vez que se mueve cualquier ventana del sistema operativo, así que sipmlemente estamos aprovechando esa función gracias al método nativo del SO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        //{
        //    WindowInteropHelper helper = new WindowInteropHelper(this);
        //    SendMessage(helper.Handle, 161, 2, 0);
        //}


        //private void BtnClose_Click(object sender, RoutedEventArgs e)
        //{
        //    Application.Current.Shutdown();
        //}

        //private void BtnMinimize_Click(object sender, RoutedEventArgs e)
        //{
        //    this.WindowState = WindowState.Minimized;
        //}

        //private void BtnMaximize_Click(object sender, RoutedEventArgs e)
        //{
        //    if (this.WindowState == WindowState.Normal)
        //        this.WindowState = WindowState.Maximized;
        //    else this.WindowState = WindowState.Normal;
        //}




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

    public class Member
    {
        public string Number { get; set; }
        public string Character { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Member() { Number = "0"; Character = ""; Name = ""; Position = ""; Email = ""; Phone = ""; }
    }

}
