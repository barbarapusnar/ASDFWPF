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
    /// Interaction logic for VajeTekst.xaml
    /// </summary>
    public partial class VajeTekst : Page
    {
        public VajeTekst()
        {
            InitializeComponent();
            txtUporabnik.Text = PrivzetiViewModel.Uporabnik;
            smallImage.Source = PrivzetiViewModel.UporabnikSlika;
            smallImage.Visibility = Visibility.Visible;
            pageTitle.Text = "Teksti \t Način dela: " + NačinDela.Ignoriraj;
        }

        private void ItemGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void BtnStatistika_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnIgnoriraj_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
