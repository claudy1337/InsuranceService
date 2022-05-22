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
    /// Логика взаимодействия для LawShow.xaml
    /// </summary>
    public partial class LawShow : Page
    {
        public LawShow()
        {
            InitializeComponent();
            lst.ItemsSource = BD_Connection.bd.Client.ToList();
            CBClient.ItemsSource = BD_Connection.bd.Client.ToList();
        }

        private void EDIT_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
