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

namespace Insurance_Service.Pages
{
    /// <summary>
    /// Логика взаимодействия для ChoosingActionPage.xaml
    /// </summary>
    public partial class ChoosingActionPage : Page
    {
        public ChoosingActionPage()
        {
            InitializeComponent();
        }

        private void clietAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientAddPage());
        }

        private void clientShow_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientShowPage());
        }

        private void carAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCar());
        }

        private void carShow_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CarShow());
        }

        private void LawAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CreateLaw());
        }

        private void LawShow_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LawShow());
        }

        private void STSAdd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new STSAddPage());
        }

        private void STSShow_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
