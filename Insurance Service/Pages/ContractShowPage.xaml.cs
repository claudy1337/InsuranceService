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
using Insurance_Service.Car;
using Insurance_Service.Model;
using Insurance_Service.CurrentData;

namespace Insurance_Service.Pages
{
    /// <summary>
    /// Логика взаимодействия для ContractShowPage.xaml
    /// </summary>
    public partial class ContractShowPage : Page
    {
        public ContractShowPage()
        {
            InitializeComponent();
            contractList.ItemsSource = BD_Connection.bd.Contract.ToList();
            countContract.Text = $"{BD_Connection.bd.Contract.Count().ToString()} contracts";
        }
        public void Refresh()
        {
            contractList.ItemsSource = null;
            contractList.ItemsSource = BD_Connection.bd.Contract.ToList();
            TBLogin.Text = null;
            TBName.Text = null;
            TBNumber.Text = null;
            TBModel.Text = null;
            TBStateNumber.Text = null;
            TBVIN.Text = null;
            TBPrice.Text = null;
            

        }
        public void OnPasteCommand(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void contractList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var selected = contractList.SelectedItem as Model.Contract;
                TBLogin.Text = selected.Car.Client.Login;
                TBName.Text = selected.Car.Client.Name;
                TBNumber.Text = selected.Car.Client.Number;

                TBStateNumber.Text = selected.Car.StateNumber;
                //TBModel.Text = selected.Car.Model.Name;
                TBVIN.Text = selected.Car.VIN;

                TBPrice.Text = selected.Price.ToString();
            }
            catch (System.NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void auth_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
            try
            {
                contractList.ItemsSource = BD_Connection.bd.Contract.ToList().Where(c => c.Car.Client.Login == TBLogins.Text || c.Car.StateNumber == TBLogins.Text || c.Car.Brand.name == TBLogins.Text);
                if (TBLogins.Text == "")
                {
                    Refresh();
                }
            }
            catch(ArgumentNullException )
            {
                MessageBox.Show("incrorect");
                Refresh();
            }
        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
