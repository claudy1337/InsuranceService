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
using Insurance_Service.CurrentData;

namespace Insurance_Service.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientShowPage.xaml
    /// </summary>
    public partial class ClientShowPage : Page
    {
        public ClientShowPage(Users users)
        {
            InitializeComponent();
            if (CBclear.IsChecked == true)
            {
               TBSearch.Text = null;
            }
            returnConnect(); 
            TBPasport.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand));
            TBNumber.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand));
            TBCity.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand));
        }
        public void OnPasteCommand(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void BSearchUser_Click(object sender, RoutedEventArgs e)
        {
            if (CBclear.IsChecked == true)
            {
                Refresh();
                ltv.ItemsSource = BD_Connection.bd.Client.ToList().Where(c => c.Login == TBSearch.Text || c.Number == TBSearch.Text || c.Name == TBSearch.Text);
            }
            Refresh();
            //ltv.ItemsSource = BD_Connection.bd.Client.ToList().Where(c=>c.Login == TBSearch.Text || c.Number == TBSearch.Text || c.Name == TBSearch.Text);
            if (TBSearch.Text == "" || TBSearch.Text == null || CBclear.IsChecked == true)
            {
                returnConnect();
            }
        }
        public void returnConnect()
        {
            ltv.ItemsSource = null;
            ltv.ItemsSource = BD_Connection.bd.Client.ToList();
        }
        public void Refresh()
        {
            TBLogin.Text = null;
            TBNameSplit.Text = null;
            TBNumber.Text = null;
            TBBirthDay.Text = null;
            TBCity.Text = null;
            TBPasport.Text = null;
           
        }
        private void ltv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = ltv.SelectedItem as Model.Client;
            try
            {
                TBNameSplit.Text = selected.Name;
                TBCity.Text = selected.City;
                TBLogin.Text = selected.Login;
                TBNumber.Text = selected.Number;
                TBBirthDay.Text = selected.BirthDay;
                TBPasport.Text = selected.Passport;
            }
            catch (System.NullReferenceException ex)
            { 
                Console.WriteLine(ex.Message); 
            } 
        }

        private void BBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void BEdit_Click(object sender, RoutedEventArgs e)
        {
            var client = ltv.SelectedItem as Model.Client;
            if (client != null)
            {
                var selectedClient = BD_Connection.bd.Client.Where(c => c.Login == client.Login && c.Login == TBLogin.Text).FirstOrDefault();
                selectedClient.Number = TBNumber.Text;
                selectedClient.City = TBCity.Text;
                selectedClient.Passport = TBPasport.Text;
                BD_Connection.bd.SaveChanges();
                MessageBox.Show("client edit");
                Refresh();
            }
            else
                MessageBox.Show("incorrect");
            
        }

        private void number(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void passport(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
