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
using Microsoft.Win32;

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
            usr.ItemsSource = BD_Connection.bd.Client.ToList();
                
        }
        string photo;
        private void save_Click(object sender, RoutedEventArgs e)
        {
            string a = CheckA.IsChecked.ToString();
            string b = CheckB.IsChecked.ToString();
            string c = CheckC.IsChecked.ToString();
            string d = CheckD.IsChecked.ToString();
            string c1e = CheckC1E.IsChecked.ToString();
            List<string> chekc = new List<string>() { a, b, c, d, c1e };
            if (string.IsNullOrEmpty(TBNumber.Text) && string.IsNullOrEmpty(TBSignature.Text) && string.IsNullOrEmpty(TBTPAuthority.Text) && string.IsNullOrEmpty(DateIssue.Text))
            {
                MessageBox.Show("incorrect");
                return;
            }
            else
            {
                var client = usr.SelectedItem as Client;
                Model.Law law = BD_Connection.bd.Law.FirstOrDefault(l => l.Number == TBNumber.Text && l.idClient == client.idClient || l.idClient == client.idClient && l.TPAuthority == TBTPAuthority.Text);
                if (law == null)
                {
                    Model.Law lawCreate = new Model.Law()
                    {
                        idClient = client.idClient,
                        DateIssue = Convert.ToDateTime(DateIssue.Text),
                        DateEnd = Convert.ToDateTime(DateEnd.Text),
                        Number = TBNumber.Text,
                        Region = TBSignature.Text,
                        Category = chekc.ToString(),
                        TPAuthority = TBTPAuthority.Text,
                        image = photo
                        
                    };
                    BD_Connection.bd.Law.Add(lawCreate);
                    BD_Connection.bd.SaveChanges();
                    MessageBox.Show("law save");
                    Refresh();
                }
            }
        }
        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //NavigationService.Navigate(new ClientAddPage());
            TBTPAuthority.Text = DateIssue + "00.00.0002";
        }
        public void Refresh()
        {
            usr.Text = null;
            TBNumber.Text = null;
            TBTPAuthority.Text = null;
            DateEnd.Text = null;
            DateIssue.Text = null;
            TBSignature.Text = null;
        }

        private void TextBlock_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void tpNumber(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void TBNumbers(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";
            if (op.ShowDialog() == true)
            {
                usrImage.Source = new BitmapImage(new Uri(op.FileName));
                photo = op.FileName;
            }
        }
    }
}
