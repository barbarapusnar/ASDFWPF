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
    /// Interaction logic for RezultatiPožVajahZaEnDan.xaml
    /// </summary>
    public partial class RezultatiPoVajahZaEnDan : Page
    {
        public RezultatiPoVajahZaEnDan(ZaPagePayload1 a)
        {
            InitializeComponent();
            var x = a.title;
            var n = a.n;
            var item = StatistikaVM.GetItemsPoDatumu(x, n);
            itemListView.ItemsSource= item;
            pageTitle.Text = x;
        }
    }
}
