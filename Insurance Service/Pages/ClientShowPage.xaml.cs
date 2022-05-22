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
        public ClientShowPage()
        {
            InitializeComponent();
            Refresh(); 
        }

        private void BSearchUser_Click(object sender, RoutedEventArgs e)
        {
            ltv.ItemsSource = BD_Connection.bd.Client.ToList().Where(c=>c.Login == TBSearch.Text || c.Number == TBSearch.Text || c.Name == TBSearch.Text);
            if (TBSearch.Text == "")
            {
                Refresh();
            }
        }
        public void Refresh()
        {
            ltv.ItemsSource = null;
            ltv.ItemsSource = BD_Connection.bd.Client.ToList();
        }
        private void ltv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            
            var selected = ltv.SelectedItem as Model.Client; 
            TBNameSplit.Text = string.Join(selected.FullName, " ", selected.Name, " ", selected.LastName);
            TBCity.Text = selected.City;
            TBLogin.Text = selected.Login;
            TBNumber.Text = selected.Number;
            TBBirthDay.Text = selected.BirthDay;
            TBPasport.Text = selected.Passport;
        }

        private void BBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
