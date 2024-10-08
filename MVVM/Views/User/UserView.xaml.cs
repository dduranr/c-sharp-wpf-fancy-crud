﻿using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPF_Fancy_CRUD.MVVM.Views.User
{
    /// <summary>
    /// Lógica de interacción para UserView.xaml
    /// </summary>
    public partial class UserView : UserControl
    {
        public UserView()
        {
            InitializeComponent();


            var converter = new BrushConverter();
            ObservableCollection<Member> members = new ObservableCollection<Member>();


            // Create datagrid items info
            members.Add(new Member { Number = "1", Character = "A", Name = "Parménides 3", Position = "Administrador", Email = "parménides@gmail.com", Phone = "5551895555" });
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
