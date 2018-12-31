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

namespace ASDFWPF
{
    /// <summary>
    /// Interaction logic for SkupinaZaEnDan.xaml
    /// </summary>
    public partial class SkupinaZaEnDan : Page
    {
        private NačinDela načinDela;
        private int[] napake;
        private string opisSkupine = "";
        private bool[] reseno;
        private string s;
        private int[] številkeVaj;
        private int štVaj;
        private int vaje1 = 0;
        List<Vaje> Group = new List<Vaje>();
        public SkupinaZaEnDan(int[] vaje,int[] st) //od vaje, st pomeni koliko vaj
        {
            InitializeComponent();
            txtUporabnik.Text = PrivzetiViewModel.Uporabnik;
            smallImage.Source = PrivzetiViewModel.UporabnikSlika;
            smallImage.Visibility = Visibility.Visible;
            //s = (string)navigationParameter;
            vaje1 = vaje[0];
            int st1 = st[0];
            opisSkupine = vaje+"--" +(vaje1+st1);
            List<Vaje> vse = new List<Vaje>();
            vse = PrivzetiViewModel.GetVajeZaDanPoŠtevilki(vaje1,st1).ToList();
            if (vaje[1] != 0)
            {
                var vse1 = PrivzetiViewModel.GetVajeZaDanPoŠtevilki(vaje[1], st[1]);
                vse.AddRange(vse1.ToList());
            }
            štVaj = vse.Count();
            številkeVaj = new int[štVaj];
            var k = 0;
            foreach (var x in vse)
            {
                številkeVaj[k] = x.Id;
                k++;
            }
            Group = vse.ToList();
           // itemGridView.ItemsSource = vse;
            reseno = new bool[štVaj];
            napake = new int[štVaj];
            načinDela = NačinDela.Ignoriraj;
            pageTitle.Text = "Vaje za danes \t Način dela: " + načinDela;
            
           
        }
        
        private void btnStatistika_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Statistika(načinDela));
        }

        private void btnIgnoriraj_Click(object sender, RoutedEventArgs e)
        {
            //Izbor načina dela, v XAMLU še ni vseh gumbov
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
            pageTitle.Text = "Vaje za danes \t Način dela: " + načinDela;
            itemGridView.SelectedItem = null;

        }

        private void itemGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (itemGridView .SelectedItem!= null)
            {
                var a = new ZaPagePayload();
                int x = itemGridView.SelectedIndex;
                var vaja = Group[x];
                a.št = vaja.Id; //številka vaje
                if (a.št != vaje1)
                {
                    Xceed.Wpf.Toolkit.MessageBox.Show("To ni prva vaja sklopa, lahko ponovno izbereš vaje za ta dan");
                    return;
                }
                
                a.n = načinDela + " " + "prof";
                a.štČrkSkupaj = 0;
                a.napakeSkupaj = 0;
                a.številoUdarcevSkupaj = 0;
                a.časSkupaj = 0;
                a.vsehVajSkupaj = štVaj;
                a.številkeVajZaDan = številkeVaj;
                a.trenutnaPozicijaVaj = 0;
                a.opisS = opisSkupine;
                this.NavigationService.Navigate(new PoVajah(a));
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            IEnumerable<Rezultati> r = PrivzetiViewModel.GetVsiRezultatiUp(txtUporabnik.Text).ToList();
            var i = 0;
            foreach (var x in Group)
            {
                var a = (from b in r
                         where b.idVaje == x.Id
                         select b).FirstOrDefault();
                if (a != null)
                {
                    napake[i] = a.napake;
                    reseno[i] = true;
                }
                i++;
            }
            itemGridView.ItemsSource = null;
            itemGridView.ItemsSource = Group;
        }
    }
}
