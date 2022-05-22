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
    /// Логика взаимодействия для STSShowPage.xaml
    /// </summary>
    public partial class STSShowPage : Page
    {
        public STSShowPage()
        {
            InitializeComponent();
            Refresh();
        }

        private void BBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
        public void Refresh()
        {
            DGSsts.ItemsSource = null;
            DGSsts.ItemsSource = BD_Connection.bd.STS.ToList();
        }
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            if (TBSearch.Text == "")
            {
                Refresh();
            }
            DGSsts.ItemsSource = BD_Connection.bd.STS.ToList().Where(s=>s.Client.Login == TBSearch.Text ||
            s.Car.brand.name == TBSearch.Text || s.Car.Model.Name == TBSearch.Text || s.STSNumber == TBSearch.Text);
        }
    }
}
