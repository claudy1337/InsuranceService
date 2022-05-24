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
        public Calculator()
        {
            InitializeComponent();
            CBrand.ItemsSource = BD_Connection.bd.brand.ToList();
            CBAccident.ItemsSource = BD_Connection.bd.Accident.ToList();            
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
        public void Refresh()
        {
            int procent = Assets.Assets.procent;
            if (string.IsNullOrEmpty(TBExperience.Text) && string.IsNullOrEmpty(TBYear.Text) && string.IsNullOrWhiteSpace(CBAccident.Text) && string.IsNullOrWhiteSpace(CBrand.Text))
            {
                MessageBox.Show("incorrect");
            }
            else
            {
                var idCar = CBrand.SelectedItem as Model.brand;
                if (idCar != null) 
                {
                    int getPrice = Assets.Assets.Price;
                    if (idCar.id > 150)
                        getPrice += 1000;
                    else if (idCar.id > 1000)
                        getPrice += 500;
                    else if (idCar.id > 50)
                        getPrice += 250;
                    else if (idCar.id > 7)
                        getPrice += 150;
                    else if (idCar.id > 5)
                        getPrice += 100;
                    else
                    {
                        getPrice += 50;
                    }

                    var accident = CBAccident.SelectedItem as Model.Accident;
                    if (accident != null)
                    {
                        if (getPrice > 2100)
                        {
                            int Accidentp = 10;
                            procent += Accidentp;
                            var year = Convert.ToInt32(TBYear.Text);
                            if (year < 2019 && year > 2017)
                            {
                                procent += 1;
                            }
                            else if (year < 2021 && year > 2019)
                                procent += 5;
                            else if (year < 2022 && year > 2021)
                            {
                                procent += 10;
                            }
                            else
                                getPrice -= 1000;

                            int experiences = Convert.ToInt32(TBExperience.Text);
                            if (experiences > 20 && experiences < 99)
                            {
                                getPrice -= 1000;
                            }
                            else if (experiences > 10 && experiences < 20)
                                getPrice += 1500;
                            else
                                getPrice += 2000;

                            int results = (procent + 100) * getPrice / 10000; //:)logic the best all fun
                            MessageBox.Show($"{results}");

                        }
                        else
                            getPrice += 1000;

                        int experience = Convert.ToInt32(TBExperience.Text);
                        if (experience > 20 && experience < 99)
                        {
                            getPrice -= 1000;
                        }
                        else if (experience > 10 && experience < 20)
                            getPrice += 1500;
                        else
                            getPrice += 2000;

                        int result = (procent + 500) * getPrice / 10000;

                        TBPrice.Text = $"{result} doll";
                    }
                }
                else
                    MessageBox.Show("incorrect");
            }
        }
        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
