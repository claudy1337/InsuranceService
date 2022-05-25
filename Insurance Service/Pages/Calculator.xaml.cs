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
using Insurance_Service.Pages;
using Insurance_Service.CurrentData;
using Insurance_Service.Assets;
using System.Collections;
using System.Collections.ObjectModel;
using System.Web;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net;
using System.Net.Security;
using System.IO;
using System.Text.Json;
using Microsoft.Win32;
using Newtonsoft.Json;
using System.Reflection;
using Insurance_Service.Car;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Insurance_Service.Pages
{
    /// <summary>
    /// Логика взаимодействия для Calculator.xaml
    /// </summary>
    public partial class Calculator : Page
    {
        Assets.Assets assets;
        public Calculator()
        {
            InitializeComponent();
            CBrand.ItemsSource = BD_Connection.bd.brand.ToList();
            CBAccident.ItemsSource = BD_Connection.bd.Accident.ToList();
            TBVin.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand));
            TBExperience.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand));
            TBYear.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand));
        }

        private void CBrand_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var brand = CBrand.SelectedItem as Model.brand;
            if (brand != null)
            {
                CBCar.ItemsSource = BD_Connection.bd.Model.Where(x => x.idBrands == brand.id).ToList();
            }
        }

        private void getPrice_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
          
        }
        public void OnPasteCommand(object sender, ExecutedRoutedEventArgs e)
        {

        }
        public void Refresh()
        {
            int procent = Assets.Assets.procent;
            int price = Assets.Assets.Price;

            var brand = CBrand.SelectedItem as Model.brand;
            var model = CBCar.SelectedItem as Model.Model;
            var accident = CBAccident.SelectedItem as Model.Accident;

            int experience = Convert.ToInt32(TBExperience.Text);
            int year = Convert.ToInt32(TBYear.Text);

            if (string.IsNullOrEmpty(TBExperience.Text) && string.IsNullOrEmpty(TBYear.Text) && string.IsNullOrWhiteSpace(CBAccident.Text) && string.IsNullOrWhiteSpace(CBrand.Text))
            {
                MessageBox.Show("incorrect");
            }
            else
            {
                if (brand.id < 20 && brand.id > 1)
                {
                    price += 1000;
                    procent += 2;
                }
                else if (brand.id < 40 && brand.id > 20)
                {
                    price += 2000;
                    procent += 5;
                }
                else if (brand.id < 80 && brand.id > 40)
                {
                    price += 3000;
                    procent += 7;
                }
                else if (brand.id < 120 && brand.id > 80)
                {
                    price += 3500;
                    procent += 5;
                }
                else if (brand.id < 250 && brand.id > 120)
                {
                    price += 3000;
                    procent += 5;
                }

                if (model.id < 4 && model.id >1 )
                {
                    procent += 10;
                }
                else if (model.id < 10 && model.id > 4)
                {
                    procent += 7;
                }

                if (accident.Count == 10)
                {
                    procent += 10;
                    price += 300;
                }
                else if (accident.Count == 5)
                {
                    procent += 5;
                    price += 250;
                }
                else if (accident.Count == 3)
                {
                    procent += 3;
                    price += 150;
                }
                else if (accident.Count == 1)
                {
                    procent += 1;
                    price += 100;
                }


                if (experience > 5 && experience < 10)
                {
                    procent += 15;
                }
                else if (experience > 10 && experience < 25)
                {
                    procent += 5;
                }
                else if (experience > 25 && experience < 40)
                {
                    procent += 3;
                }
                else if (experience > 40 && experience < 99)
                {
                    procent += 1;
                }

                if (year > 2021 && year < 2023)
                {
                    procent += 10;
                    price += 500;
                }
                else if (year > 2018 && year < 2021)
                {
                    procent += 5;
                    price += 100;
                }
                else if (year > 2015 && year < 2018)
                {
                    price += 50;
                    procent += 3;
                }
                else if (year > 1980 && year < 2015)
                {
                    price += 10;
                }
                

                Assets.Assets.valuePrice = price * procent;
                TBPrice.Text = $"{Assets.Assets.valuePrice}";
                if (Assets.Assets.valuePrice > 100000)
                {

                    Assets.Assets.valuePrice = price / 10 - 10000;
                    TBPrice.Text = $"{Assets.Assets.valuePrice}";
                }
            }
        }
        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void TextBlock_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ContractAddPage());
        }
    }
}
