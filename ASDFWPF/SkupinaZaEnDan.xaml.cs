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
        public SkupinaZaEnDan(string vaje,string st) //od vaje, st pomeni koliko vaj
        {
            InitializeComponent();
            txtUporabnik.Text = PrivzetiViewModel.Uporabnik;
            smallImage.Source = PrivzetiViewModel.UporabnikSlika;
            smallImage.Visibility = Visibility.Visible;
            //s = (string)navigationParameter;
            int vaje1 = int.Parse(vaje);
            int st1 = int.Parse(st);
            opisSkupine = vaje+" --" +(vaje+st);
            var vse = PrivzetiViewModel.GetVajeZaDanPoŠtevilki(vaje1,st1);
            štVaj = vse.Count();
            številkeVaj = new int[štVaj];
            var k = 0;
            foreach (var x in vse)
            {
                številkeVaj[k] = x.Id;
                k++;
            }
            itemGridView.ItemsSource = vse;
            reseno = new bool[štVaj];
            napake = new int[štVaj];

            IEnumerable<Rezultati> r = PrivzetiViewModel.GetVsiRezultatiUp(txtUporabnik.Text).ToList();
            var i = 0;
            foreach (var x in vse)
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
           
        }
    }
}
