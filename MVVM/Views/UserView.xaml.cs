using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPF_Fancy_CRUD.MVVM.Views
{
    /// <summary>
    /// Lógica de interacción para UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        public UserView()
        {
            InitializeComponent();

            //btnAgregar.
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
