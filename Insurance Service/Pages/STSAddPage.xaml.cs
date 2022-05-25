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
    /// Логика взаимодействия для STSAddPage.xaml
    /// </summary>
    public partial class STSAddPage : Page
    {
        public STSAddPage()
        {
            InitializeComponent();
            CBClient.ItemsSource = BD_Connection.bd.Client.ToList();
            CBCar.ItemsSource = BD_Connection.bd.Car.ToList();
            TBNumber.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand));
        }
        public void OnPasteCommand(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientAddPage());
        }

        private void CBClient_Loaded(object sender, RoutedEventArgs e)
        {
            
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var car = CBCar.SelectedItem as Model.Car;
                var client = CBClient.SelectedItem as Model.Client;
                if (string.IsNullOrEmpty(CBClient.Text) && string.IsNullOrEmpty(CBCar.Text) && string.IsNullOrWhiteSpace(TBNumber.Text))
                {
                    Model.STS sts = BD_Connection.bd.STS.FirstOrDefault(s => s.STSNumber == TBNumber.Text || s.idClient == client.idClient);
                    if (sts == null)
                    {
                        Model.STS stsCreate = new Model.STS()
                        {
                            idCar = car.idCar,
                            idClient = client.idClient,
                            STSNumber = TBNumber.Text
                        };
                        BD_Connection.bd.STS.Add(stsCreate);
                        BD_Connection.bd.SaveChanges();
                        MessageBox.Show("sts save");
                        Refresh();
                    }
                    else
                    {
                        
                    }

                }
            }
            catch (FormatException)
            {
                MessageBox.Show("incorrect");
                Refresh();
            }
        }
        public void Refresh()
        {
            CBClient.Text = null;
            CBCar.Text = null;
            TBNumber.Text = null;
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CarAdd());
        }

        private void BBack_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack(); 
        }

        private void CBCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
