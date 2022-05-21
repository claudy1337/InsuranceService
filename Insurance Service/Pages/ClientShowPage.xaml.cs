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

        }
        public void Refresh()
        {
            ltv.ItemsSource = null;
            ltv.ItemsSource = BD_Connection.bd.Client.ToList();
        }
        private void ltv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        }
    }
}
