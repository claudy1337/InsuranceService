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
        }
        private void auth_Click(object sender, RoutedEventArgs e)
        {
            Model.Admin admin = BD_Connection.bd.Admin.FirstOrDefault(a=> a.Login == TBLogin.Text && a.Password == TBPassword.Text);
            Model.Client clientData = BD_Connection.bd.Client.FirstOrDefault(c=> c.Login == TBLogin.Text && c.Password == TBPassword.Text);
            if (clientData != null)
            {
                
                MessageBox.Show("welcome: " + clientData.Name);
            }
            else if(admin != null)
            {
                NavigationService.Navigate(new ChoosingActionPage());
                MessageBox.Show("welcome: " + admin.Name);
            }
            else
            {
                MessageBox.Show("error");
            }
        }
    }
}
