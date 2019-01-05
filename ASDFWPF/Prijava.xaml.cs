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
            PrivzetiViewModel.NaložiStareRezultateAsync();
            if (radSam.IsChecked != null && (bool)radSam.IsChecked)
            {
                this.NavigationService.Navigate(new Page1());
            }
            else
            {
                if (radProf.IsChecked != null && (bool)radProf.IsChecked)
                {
                    int[] Od = new int[2];
                    int[] Do = new int[2];
                    try
                    {
                        Od[0] = int.Parse(txtSkupina.Text);
                        Do[0] = int.Parse(txtStevilo.Text);
                        if (Od[0] > Do[0])
                            throw new ApplicationException("Drugo število mora biti večje");
                        if (Do[0] > 163)
                            Do[0] = 163;
                        if ((bool)radProf1.IsChecked)
                        {

                            Od[1] = int.Parse(txtSkupina1.Text);
                            Do[1] = int.Parse(txtStevilo1.Text);
                            if (Do[1] > 163)
                                Do[1] = 163;
                            if (Od[1] > Do[1])
                                throw new ApplicationException("Drugo število mora biti večje");
                            if (Od[1] < Do[0])
                                throw new ApplicationException("Prva vaja drugega sklopa mora biti večja od zadnje vaje prvega");
                        }
                        this.NavigationService.Navigate(new SkupinaZaEnDan(Od, Do));

                    }
                    catch (FormatException)
                    {
                        MessageBox.Show("Izbrati moraš številko prve in zadnje vaje");
                    }
                    catch (ApplicationException y)
                    {
                        MessageBox.Show(y.Message);
                    }

                }
                else
                    if ((bool)radProf2.IsChecked)
                {
                    this.NavigationService.Navigate(new VajeTekst());
                }
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
            txtStevilo.IsEnabled = true;
        }

        private void radSam_Click(object sender, RoutedEventArgs e)
        {
            if (radSam.IsChecked != null && (bool)radSam.IsChecked)
            {
                txtSkupina.IsEnabled = false;
                txtStevilo.IsEnabled = false;
            }
        }

       

        private void RadProf1_Checked(object sender, RoutedEventArgs e)
        {
            if ((bool)radProf1.IsChecked)
            {
                txtSkupina1.IsEnabled = true;
                txtStevilo1.IsEnabled = true;
            }
            else
            {
                txtSkupina1.IsEnabled = false;
                txtStevilo1.IsEnabled = false;
            }
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
