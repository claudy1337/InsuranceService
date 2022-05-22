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
using Insurance_Service.Model;

namespace Insurance_Service.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateLaw.xaml
    /// </summary>
    public partial class CreateLaw : Page
    {
        public CreateLaw()
        {
            InitializeComponent();
        }

        private void save_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(TBNumber.Text) && string.IsNullOrEmpty(TBSignature.Text) && string.IsNullOrEmpty(TBTPAuthority.Text) && string.IsNullOrEmpty(DateIssue.Text))
            {
                MessageBox.Show("incorrect");
                return;
            }
            Model.Law law = new Law()
            {
                idClient = 1,
                DateIssue = Convert.ToDateTime(DateIssue),
                CategoryType = null,
                DateEnd = Convert.ToDateTime(DateEnd),
                Region = TBSignature.Text,
                Number = TBNumber.Text,
                TPAuthority = TBTPAuthority.Text
            };

        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new ClientAddPage());
        }

        private void TextBlock_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
