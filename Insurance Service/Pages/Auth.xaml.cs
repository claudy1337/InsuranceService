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
        public Auth()
        {
            InitializeComponent();
            TBPassword.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand));
            TBLogin.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand));
        }
        private void auth_Click(object sender, RoutedEventArgs e)
        {
            Role role = BD_Connection.bd.Role.FirstOrDefault();
            Model.Client clientData = BD_Connection.bd.Client.FirstOrDefault(c=> c.Login == TBLogin.Text && c.Password == TBPassword.Text);
            if (clientData.idRole == 1)
            {
                
                MessageBox.Show("welcome user: " + clientData.Name);
            }
            else if(clientData.idRole == 2)
            {
                NavigationService.Navigate(new ChoosingActionPage());
                MessageBox.Show("welcome admin: " + clientData.Name);
            }
            else if (true)
            {
                MessageBox.Show("welcome prodavech: " + clientData.Name);
            }
            else
                MessageBox.Show("error");
        }
        public void OnPasteCommand(object sender, ExecutedRoutedEventArgs e)
        {

        }
    }
}
