using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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


namespace ASDFWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        PrivzetiViewModel pvm = new PrivzetiViewModel();
        private bool JeServisDelujoč(string URL)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL);
                request.Timeout = 5000;
                request.Credentials = CredentialCache.DefaultNetworkCredentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                if (response.StatusCode == HttpStatusCode.OK)
                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            Podatki();
            mojOkvir.Navigate(new Prijava());
        }
        public async void Podatki()
        {
            if (JeServisDelujoč("http://gimnazija.scng.si/strojepisje/api/admin"))
            {
                var uspeh = await PrivzetiViewModel.NaložiRemoteRezultateAsync();

                if (!uspeh)
                {
                    PrivzetiViewModel.NaložiRezultate();
                }
                //rezultati vaj - vedno poberemo lokalne rezultate
                //if (PrivzetiViewModel.JeServis)
                //{
                //    await PrivzetiViewModel.NaložiStareRezultateRemoteAsync();
                //}
                //else
                //{
                PrivzetiViewModel.NaložiStareRezultateAsync();
                //}
            }
            else
            {
                PrivzetiViewModel.NaložiRezultate();
                PrivzetiViewModel.NaložiStareRezultateAsync();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
