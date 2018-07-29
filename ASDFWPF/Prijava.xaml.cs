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
using System.IO;


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
            GetCurrentUserProfileImage();
            if (radSam.IsChecked != null && (bool)radSam.IsChecked)
            {
                this.NavigationService.Navigate(new Page1(PrivzetiViewModel.Uporabnik, PrivzetiViewModel.UporabnikSlika));
            }
            else
            {
                this.NavigationService.Navigate(new SkupinaZaEnDan(PrivzetiViewModel.Uporabnik, PrivzetiViewModel.UporabnikSlika,txtSkupina.Text));
            }
           
        }
        private  void GetCurrentUserProfileImage()
        {
            var imageFile = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) +
                @"\Microsoft\User Account Pictures\user.png" );
            if (!imageFile.Exists)
                return;
            string pot = imageFile.FullName;
            ImageSource b = new BitmapImage(new Uri(pot)); ;
            
            PrivzetiViewModel.UporabnikSlika = b;
        }

        private void radProf_Checked(object sender, RoutedEventArgs e)
        {
            txtSkupina.IsEnabled = true;
        }

        private void radSam_Click(object sender, RoutedEventArgs e)
        {
            if (radSam.IsChecked != null && (bool)radSam.IsChecked)
                txtSkupina.IsEnabled = false;
        }

        //private static void GetCurrentUserProfileImage()
        //{
        //    var imageFile = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) +
        //    @"\Microsoft\User Account Pictures\" + Environment.UserDomainName + "+" + Environment.UserName + ".dat");
        //    if (!imageFile.Exists)
        //        return;

        //    var desktopSaveLocation = new FileInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) +
        //    @"\" + Environment.UserDomainName + "+" + Environment.UserName + ".bmp");
        //    byte[] originalImageBytes = new byte[imageFile.Length];
        //    using (var imageInputStream = imageFile.OpenRead())
        //        imageInputStream.Read(originalImageBytes, 0, (int)imageFile.Length);
        //    using (var imageOutput = desktopSaveLocation.Create())
        //        imageOutput.Write(originalImageBytes, 16, originalImageBytes.Length - 200);
        //}
    }
}
