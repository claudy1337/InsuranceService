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
    /// Логика взаимодействия для CarShow.xaml
    /// </summary>
    public partial class CarShow : Page
    {
        Model.CTPBDEntities BD = new CTPBDEntities();
        public CarShow()
        {
            InitializeComponent();
            Refresh();
        }

        private void BBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            DGCar.ItemsSource = BD_Connection.bd.Car.ToList().Where(c=>c.Client.Login == TBSearch.Text || 
            c.VIN == TBSearch.Text || c.Brand.name == TBSearch.Text || c.Color == TBSearch.Text);
            if (TBSearch.Text == "")
            {
                Refresh();
            }
            
        }
        public void Refresh()
        {
            DGCar.ItemsSource = null;
            DGCar.ItemsSource = BD_Connection.bd.Car.ToList();
        }

        private void Bdelete_Click(object sender, RoutedEventArgs e)
        {
            var item = DGCar.SelectedItem as Model.Car;
            Model.Contract contract = BD_Connection.bd.Contract.FirstOrDefault(a => a.idCar == item.idCar);
            Model.STS sts = BD_Connection.bd.STS.FirstOrDefault(a => a.idCar == item.idCar);
            
            if (DGCar.SelectedItem == null)
            {
                MessageBox.Show("select item");
                return;
            }
            if (sts != null || contract != null)
            {
                MessageBox.Show("на машину заведенны бумаги");
            }
            else
            {
                BD_Connection.bd.Car.Remove(item);
                BD_Connection.bd.SaveChanges();
                MessageBox.Show("deleted");
                Refresh();
                
            }
           
        }
    }
}
