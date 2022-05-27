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
using Insurance_Service.Assets;

namespace Insurance_Service.Pages
{
    /// <summary>
    /// Логика взаимодействия для LawShow.xaml
    /// </summary>
    public partial class LawShow : Page
    {
        public LawShow(Users users)
        {
            InitializeComponent();
            countLaw.Text = $"{BD_Connection.bd.Law.Count().ToString()} law";
            lst.ItemsSource = BD_Connection.bd.Law.ToList();
            TBIdClient.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand));
            TBNumber.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand));
            TBTPAuthority.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand));
            TBSignature.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, OnPasteCommand));
        }
        public void OnPasteCommand(object sender, ExecutedRoutedEventArgs e)
        {

        }
        private void EDIT_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBlock_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void lst_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            usrImage.Source = null;
            var selected = lst.SelectedItem as Model.Law;
            TBNumber.Text = selected.Number; 
            TBIdClient.Text = string.Join(selected.Client.Name, " ", selected.Client.FullName, " ", selected.idClient);
            DateIssue.Text = selected.DateIssue.ToString();
            DateEnd.Text = selected.DateEnd.ToString();
            TBTPAuthority.Text = selected.TPAuthority;
            TBSignature.Text = selected.Region;
            if (selected.image == "")
            {
                usrImage.Source = null;
                
            }
            else if (selected.image != null)
            {
              //  usrImage.Source = new BitmapImage(new Uri(selected.images, UriKind.RelativeOrAbsolute));
            }
        }
    }
}
