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
    /// Логика взаимодействия для CarAdd.xaml
    /// </summary>
    public partial class CarAdd : Page
    {
        Model.CTPBDEntities7 bd = new CTPBDEntities7();
        public CarAdd()
        {
            InitializeComponent();
            CBClient.ItemsSource = BD_Connection.bd.Client.ToList();
            CBrand.ItemsSource = BD_Connection.bd.brand.ToList();
            TBColor.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand));
            TBModel.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand));
            TBNumber.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand));
            TBVin.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand));

        }
        public void OnPasteCommand(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TBVin.Text) && string.IsNullOrWhiteSpace(TBColor.Text) && string.IsNullOrWhiteSpace(TBNumber.Text) && string.IsNullOrWhiteSpace(CBCar.Text) && string.IsNullOrWhiteSpace(CBClient.Text))
            {
                MessageBox.Show("incorrect");
            }
            else
            {
                var client = CBClient.SelectedItem as Client;
                var brand = CBrand.SelectedItem as brand;
                var model = CBCar.SelectedItem as Model.Model;
                Model.Car car = BD_Connection.bd.Car.FirstOrDefault(c => c.VIN == TBVin.Text || c.StateNumber == TBNumber.Text);
                if (car == null)
                {
                    Model.Car carCreate = new Model.Car()
                    {
                       StateNumber = TBNumber.Text,
                       idBrand = brand.id,
                       VIN = TBVin.Text,
                       IdClient = client.idClient,
                       Color = TBColor.Text,
                       idModel = model.id

                    };
                    BD_Connection.bd.Car.Add(carCreate);
                    BD_Connection.bd.SaveChanges();
                    MessageBox.Show("car save");
                    Refresh();
                }
                else
                {
                    MessageBox.Show("error");
                }
            }
        }
        public void Refresh()
        {
            TBColor.Text = null;
            CBrand.Text = null;
            TBVin.Text = null;
            CBClient.Text = null;
            TBNumber.Text = null;
            CBCar.Text = null;
        }
        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void CBrand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var brand = CBrand.SelectedItem as Model.brand;
            if (brand != null)
            {
                CBCar.ItemsSource = BD_Connection.bd.Model.Where(x => x.idBrands == brand.id).ToList();
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var brands = BD_Connection.bd.Model.Where(b => b.brand.name == TBModel.Text).ToString();
            if (brands != null)
            {
                CBrand.Text = brands;
            }
        }
    }
}
