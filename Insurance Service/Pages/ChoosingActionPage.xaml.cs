﻿using System;
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
    /// Логика взаимодействия для ChoosingActionPage.xaml
    /// </summary>
    public partial class ChoosingActionPage : Page
    {
        public static Users users; 
        Assets.Assets assets;
        public ChoosingActionPage()
        {
            InitializeComponent();
            if (CurrentUser.Usrerole == 1)
            {
                clietAdd.Visibility = Visibility.Hidden;
                LawAdd.Visibility = Visibility.Hidden;
                STSAdd.Visibility = Visibility.Hidden;
                carAdd.Visibility = Visibility.Hidden;
            }
            else if (CurrentUser.Usrerole == 3)
            {
                ContractShow.Visibility = Visibility.Hidden;
                STSShow.Visibility = Visibility.Hidden;
                LawShow.Visibility = Visibility.Hidden;
                carShow.Visibility = Visibility.Hidden;
                clientShow.Visibility = Visibility.Hidden;
                Calculator.Visibility = Visibility.Hidden;
            }
        }

        private void clietAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientAddPage());
        }

        private void clientShow_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientShowPage(users));
        }

        private void carAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CarAdd());
        }

        private void carShow_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CarShow(users));
        }

        private void LawAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateLaw());
        }

        private void LawShow_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LawShow(users));
        }

        private void STSAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new STSAddPage());
        }

        private void STSShow_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new STSShowPage(users));
        }

        private void ContractShow_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ContractShowPage(users));
        }

        private void Calculator_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Calculator(users));
        }

        private void Bexit_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new Auth());
        }
    }
}
