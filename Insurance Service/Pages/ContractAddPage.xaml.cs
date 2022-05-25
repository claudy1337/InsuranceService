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
using Insurance_Service.Assets;
using Insurance_Service.Car;
using Insurance_Service.Model;
using Insurance_Service.Pages;
using Insurance_Service.CurrentData;

namespace Insurance_Service.Pages
{
    /// <summary>
    /// Логика взаимодействия для ContractAddPage.xaml
    /// </summary>
    public partial class ContractAddPage : Page
    {

        Assets.Assets assets;
        public ContractAddPage()
        {
            InitializeComponent();
            TBExperience.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand)); 
            Refresh();
        }
        public void OnPasteCommand(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void Experience(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void getPrice_Click(object sender, RoutedEventArgs e)
        {
            Maths();
            var accident = CBAccident.SelectedItem as Model.Accident;
            var cars = CBCar.SelectedItem as Model.Car;
            Model.contract contracts = BD_Connection.bd.contract.FirstOrDefault(c => c.idCar == cars.idCar);
            if (string.IsNullOrEmpty(TBExperience.Text) && string.IsNullOrEmpty(CBAccident.Text) && string.IsNullOrEmpty(CBCar.Text))
            {
                MessageBox.Show("incorrect");
            }
            else if (contracts != null)
            {
                MessageBoxResult result = MessageBox.Show("Данная машина уже заведена в учет изменить данные?", "Запись найдена", MessageBoxButton.YesNoCancel);
                switch (result)
                {
                    case MessageBoxResult.Yes:
                        Model.contract contract;
                        var car = CBCar.SelectedItem as Model.Car;
                        if (car != null)
                        {
                            contracts.idCar = car.idCar;
                            contracts.Experience = Convert.ToInt32(TBExperience.Text);
                            contracts.ProcentAccidents = accident.id;
                            contracts.Price = Assets.Assets.valuePrice;
                            BD_Connection.bd.SaveChanges();
                            MessageBox.Show($"contract edit, price: {Assets.Assets.valuePrice}");
                            Refresh();
                        }
                        else
                            MessageBox.Show("incorrect");
                        break;
                    case MessageBoxResult.No:
                        break;
                    case MessageBoxResult.Cancel:
                        break;
                }
               

            }
            else
            {
                Maths();
                Model.contract contract = new contract()
                {
                    idCar = cars.idCar,
                    Experience = Convert.ToInt32(TBExperience.Text),
                    ProcentAccidents = accident.id,
                    Price = Assets.Assets.valuePrice
                };
                BD_Connection.bd.contract.Add(contract);
                BD_Connection.bd.SaveChanges();
                MessageBox.Show("contract save");
                Refresh();
            }
        }
        public void Refresh()
        {
            CBCar.Text = null;
            TBExperience.Text = null;
            CBAccident.Text = null;
            TBPrice.Text = null;
            CBCar.ItemsSource = BD_Connection.bd.Car.ToList();
            CBAccident.ItemsSource = BD_Connection.bd.Accident.ToList();            
            
        }
        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Maths();
        }
        public void Maths()
        {
            try
            {

                var accident = CBAccident.SelectedItem as Model.Accident;
                var cars = CBCar.SelectedItem as Model.Car;
                var experience = Convert.ToInt32(TBExperience.Text);
                if (cars.idModel > 2 && cars.idModel < 10)
                {
                    Assets.Assets.valuePrice += 500;
                }
                else if (cars.idModel > 10 && cars.idModel < 25)
                {
                    Assets.Assets.valuePrice += 500;
                }
                else if (cars.idModel > 25 && cars.idModel < 100)
                {
                    Assets.Assets.valuePrice += 1000;
                }
                else
                {
                    Assets.Assets.valuePrice += 500;
                }

                if (experience > 1 && experience < 5)
                {
                    Assets.Assets.valuePrice += 1000;
                }
                else if (experience > 5 && experience < 10)
                {
                    Assets.Assets.valuePrice += 500;
                }
                else if (experience > 10 && experience < 25)
                {
                    Assets.Assets.valuePrice += 100;
                }
                else
                {
                    Assets.Assets.valuePrice += 500;
                }

                if (accident.Count == 10)
                {
                    Assets.Assets.valuePrice += 1100;
                }
                else if (accident.Count == 5)
                {
                    Assets.Assets.valuePrice += 500;
                }
                else if (accident.Count == 3)
                {
                    Assets.Assets.valuePrice += 300;
                }
                else if (accident.Count == 1)
                {
                    Assets.Assets.valuePrice += 100;
                }
                TBPrice.Text = $"{Assets.Assets.valuePrice}";
            }
            catch (FormatException)
            {
                MessageBox.Show("incorrect");
                Refresh();
            }
        }

        private void CBCar_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void CBAccident_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void TextBlock_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
