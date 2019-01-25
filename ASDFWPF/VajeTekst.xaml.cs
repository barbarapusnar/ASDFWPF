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
using System.IO;
using ASDFWPF.Model;
using System.Windows.Threading;

namespace ASDFWPF
{
    /// <summary>
    /// Interaction logic for VajeTekst.xaml
    /// </summary>
    public partial class VajeTekst : Page
    {
        TekstViewModel tvm = new TekstViewModel();
        private NačinDela načinDela;
        private string opisSkupine = "";
        private int[] številkeVaj;
        private int štVaj;
       
        public VajeTekst()
        {
            InitializeComponent();
            txtUporabnik.Text = PrivzetiViewModel.Uporabnik;
            smallImage.Source = PrivzetiViewModel.UporabnikSlika;
            smallImage.Visibility = Visibility.Visible;
            pageTitle.Text = "Teksti \t Način dela: " + NačinDela.Ignoriraj;
            DirectoryInfo d = new DirectoryInfo(".\\Teksti");
            List<Imena> vse = new List<Imena>();
            foreach (var x in d.GetFiles())
            {
                Imena i = new Imena();
                i.Ime = x.Name;
                if (x.Extension == ".json")
                {
                    //string imeS ="Slike/"+ i.Ime.Split('.')[0]+".png";
                    string imeS = "Teksti/" + i.Ime.Split('.')[0] + ".png";
                    Uri u = new Uri(imeS, UriKind.Relative);
                    i.Slika = new BitmapImage(u);
                    vse.Add(i);
                }
            }
            načinDela = NačinDela.Ignoriraj;
            itemGridView.ItemsSource = vse;
        }

        private  void ItemGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (itemGridView.SelectedItem != null)
            {
                var izbranTekst = (Imena)itemGridView.SelectedItem;
                string imeD = "Teksti/"+izbranTekst.Ime;
                //await Dispatcher.BeginInvoke(
                //(Action)(async () => { await TekstViewModel.NaložiVajeTekst(imeD); }));
                TekstViewModel.NaložiVajeTekst(imeD);
                var izbrane = TekstViewModel.GetIzbraneVaje().ToList();
                var vaja = izbrane[0];
                štVaj =izbrane.Count();
                številkeVaj = new int[štVaj];
                var k = 0;
                foreach (var x in izbrane)
                {
                    številkeVaj[k] = x.Id;
                    k++;
                }
                opisSkupine = "Tekst  " + vaja.Group.Title;
                var a = new ZaPagePayload2();
                a.št = vaja.Id; //številka vaje
                a.n = načinDela + " " + "prof";
                a.štČrkSkupaj = 0;
                a.napakeSkupaj = 0;
                a.številoUdarcevSkupaj = 0;
                a.časSkupaj = 0;
                a.vsehVajSkupaj = štVaj;
                a.številkeVajZaDan = številkeVaj;
                a.trenutnaPozicijaVaj = 0;
                a.opisS = opisSkupine;
                string tekstDatoteke = "";
                if (imeD != "")
                {
                    try
                    {
                        string[] deliPoti =imeD.Split(new[] { '/', '.' });
                        string imeD1 = Environment.CurrentDirectory + "\\Teksti\\" + deliPoti[1] + ".txt";

                        StreamReader fs = new StreamReader(imeD1);

                        tekstDatoteke = fs.ReadToEnd();
                    }
                    catch { }
                }
                a.imeD = tekstDatoteke;
                this.NavigationService.Navigate(new PoVajahTekst(a));
            }
        }

        private void BtnStatistika_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Statistika(načinDela));
        }

        private void BtnIgnoriraj_Click(object sender, RoutedEventArgs e)
        {
            var x = (Button)sender;
            switch (x.Name)
            {
                case "btnIgnoriraj":
                    načinDela = NačinDela.Ignoriraj;
                    break;
                case "btnPonovno":
                    načinDela = NačinDela.Ponovno;
                    break;
                case "btnBriši":
                    načinDela = NačinDela.Briši;
                    break;
                case "btnUredi":
                    načinDela = NačinDela.Uredi;
                    break;
                case "btnLahekTest":
                    načinDela = NačinDela.LahekTest;
                    break;
                case "btnTest":
                    načinDela = NačinDela.Test;
                    break;
                case "btnNeodvisno":
                    načinDela = NačinDela.Neodvisno;
                    break;
                default:
                    načinDela = NačinDela.Ignoriraj;
                    break;
            }
            pageTitle.Text = "Teksti \t\t Način dela: " + načinDela;
            itemGridView.SelectedItem = null;

        }
    }
}
