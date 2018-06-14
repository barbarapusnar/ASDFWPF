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
using System.DirectoryServices.AccountManagement;

namespace ASDFWPF
{
    /// <summary>
    /// Interaction logic for Prijava.xaml
    /// </summary>
    public partial class Prijava : Page
    {
        public Prijava()
        {
            InitializeComponent();
        }
        private void PrijaviSe(object sender, RoutedEventArgs e)
        {
            if (txtUp.Text != "")
                PrivzetiViewModel.Uporabnik = txtUp.Text;
            else
                PrivzetiViewModel.Uporabnik = UserPrincipal.Current.DisplayName;
            //StorageFile image = UserInformation.GetAccountPicture(AccountPictureKind.SmallImage)
            //    as StorageFile;
            //if (image != null)
            //{


            //    try
            //    {
            //        IRandomAccessStream imageStream = await image.OpenReadAsync();
            //        BitmapImage bitmapImage = new BitmapImage();
            //        bitmapImage.SetSource(imageStream);
            //        PrivzetiViewModel.UporabnikSlika = bitmapImage;
            //        //smallImage.Source = bitmapImage;
            //        //smallImage.Visibility = Visibility.Visible;

            //    }
            //    catch (Exception)
            //    {

            //    }
            // }
            this.NavigationService.Navigate(new Page1(PrivzetiViewModel.Uporabnik));
        }
    }
}
