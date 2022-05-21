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
using Insurance_Service.CurrentData;

namespace Insurance_Service.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientInformationPage.xaml
    /// </summary>
    public partial class ClientInformationPage : Page
    {
        
        public ClientInformationPage()
        {
            InitializeComponent();
        }

        private void TBNumber_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void enter_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TBName.Text) && string.IsNullOrEmpty(TBLastName.Text) && string.IsNullOrEmpty(TBFullName.Text))
            {
                MessageBox.Show("incorrect");
                return;
            }
            else
            {
                CurrentUser.Name = TBName.Text;
                CurrentUser.FullName = TBFullName.Text;
                CurrentUser.Number = TBNumber.Text;
                CurrentUser.LastName = TBLastName.Text;
                NavigationService.GoBack();
            }
           
        }
    }
}
