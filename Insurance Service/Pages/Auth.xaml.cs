using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Insurance_Service.Model;
using Insurance_Service.CurrentData;
using Insurance_Service.Pages;

namespace Insurance_Service.Pages
{
    /// <summary>
    /// Логика взаимодействия для Auth.xaml
    /// </summary>
    public partial class Auth : Page
    {
        public static Users user;
        public Auth()
        {
            InitializeComponent();
            TBPassword.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand));
            TBLogin.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand));
        }
        private void auth_Click(object sender, RoutedEventArgs e)
        {
            Role role = BD_Connection.bd.Role.FirstOrDefault();
            Model.Client clientData = BD_Connection.bd.Client.FirstOrDefault(c => c.Login == TBLogin.Text && c.Password == TBPassword.Text);
            if (clientData != null)
            {
                try
                {
                    if (clientData.idRole == 1 && clientData != null)
                    {
                        CurrentUser.Usrerole = clientData.idRole;
                        Users users = new Users(clientData.idClient, clientData.Name, clientData.LastName, clientData.Number, clientData.idRole);
                        MessageBox.Show("welcome user: " + clientData.Name);
                        NavigationService.Navigate(new ChoosingActionPage());
                    }
                    else if (clientData.idRole == 2 && clientData != null)
                    {
                        CurrentUser.Usrerole = clientData.idRole;
                        Users users = new Users(clientData.idClient, clientData.Name, clientData.LastName, clientData.Number, clientData.idRole);
                        MessageBox.Show("welcome admin: " + clientData.Name);
                        NavigationService.Navigate(new ChoosingActionPage());
                    }
                    else if (clientData.idRole == 3 && clientData != null)
                    {
                        MessageBox.Show("welcome consultant :" + clientData.Name);
                        Users users = new Users(clientData.idClient, clientData.Name, clientData.LastName, clientData.Number, clientData.idRole);
                        CurrentUser.Usrerole = clientData.idRole;
                        NavigationService.Navigate(new ChoosingActionPage());

                    }
                    else if (clientData == null || clientData.idRole == null)
                    {
                        MessageBox.Show("error");
                    }
                }
                catch (System.NullReferenceException ex)
                {
                    MessageBox.Show("incorrect");
                }
            }
            else
            {
                MessageBox.Show("incorrect");
            }
            
               
        }
        public void OnPasteCommand(object sender, ExecutedRoutedEventArgs e)
        {

        }
    }
}
