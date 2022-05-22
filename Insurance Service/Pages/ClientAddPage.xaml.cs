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

namespace Insurance_Service.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientAddPage.xaml
    /// </summary>
    public partial class ClientAddPage : Page
    {
        public ClientAddPage()
        {
            InitializeComponent();
        }

        private void Bsave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TBLogin.Text) && string.IsNullOrEmpty(TBPassport.Text) && string.IsNullOrEmpty(TBPassport.Text) && string.IsNullOrEmpty(BithDay.Text) && string.IsNullOrEmpty(TBCity.Text))
            {
                MessageBox.Show("incorrect");
                return;
            }
            Model.Admin admin = BD_Connection.bd.Admin.FirstOrDefault(a=> a.Login == TBLogin.Text);
            if (admin == null)
            {
                Model.Client clients = BD_Connection.bd.Client.FirstOrDefault(c => c.Login == TBLogin.Text &&  c.Passport == TBPassport.Text || c.Passport == TBPassport.Text || c.Number == CurrentUser.Number);
                if (CurrentUser.Name != null && CurrentUser.Number != null && CurrentUser.FullName != null && clients == null)
                {
                    clientVerificated.Text = "client load";
                    if (TBPassword.Text == TBPasswordReturn.Text && clients == null)
                    {
                        Model.Client client = new Model.Client()
                        {
                            Name = CurrentUser.Name,
                            LastName = CurrentUser.LastName,
                            FullName = CurrentUser.FullName,
                            Number = CurrentUser.Number,
                            Login = TBLogin.Text,
                            Password = TBPassword.Text,
                            BirthDay = BithDay.Text,
                            Passport = TBPassport.Text,
                            City = TBCity.Text
                        };
                        BD_Connection.bd.Client.Add(client);
                        BD_Connection.bd.SaveChanges();
                        MessageBox.Show("client save");
                        Refresh();
                    }
                }
                else
                {
                    MessageBox.Show("error");
                }
            }
            else
                MessageBox.Show("error");
            
            
            
        }
        public void Verificated()
        {
            clientVerificated.Text = null;
            if (CurrentUser.Name != null && CurrentUser.Number != null && CurrentUser.FullName != null)
                clientVerificated.Text = "client load";
            else
                clientVerificated.Text = "client dont load";
            
        }
        public void Refresh()
        {
            TBCity.Text = null;
            TBPassword.Text = null;
            TBPassport.Text = null;
            TBPasswordReturn.Text = null;
            TBLogin.Text = null;
            TBCity = null;
            BithDay.Text = null;
            CurrentUser.Name = null;
            CurrentUser.Number = null;
            CurrentUser.FullName = null;
        }
        private void Bclient_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientInformationPage());

        }

        private void TBPassport_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ChoosingActionPage());
        }

        private void clientVerificated_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Verificated();
        }

    }
}
