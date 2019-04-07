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
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private List<TipkanjeDataGroup> _groups = new List<TipkanjeDataGroup>();
        public List<TipkanjeDataGroup> Groups
        {
            get { return this._groups; }
            set { this._groups = value; }
        }
        public Page1()
        {
            InitializeComponent();
            var sampleDataGroups = PrivzetiViewModel.GetGroups("AllGroups");
            this.Groups = sampleDataGroups.ToList<TipkanjeDataGroup>();
            itemGridView.ItemsSource = Groups;
            txtUporabnik.Text = PrivzetiViewModel.Uporabnik; ;
            if (PrivzetiViewModel.UporabnikSlika != null)
            {
                smallImage.Source = PrivzetiViewModel.UporabnikSlika;
            }

        }

        private void itemGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (itemGridView.SelectedIndex != -1)
            {
                var izbran = itemGridView.SelectedIndex;
                TipkanjeDataGroup skupina = Groups[izbran];
                itemGridView.SelectedIndex = -1;
                this.NavigationService.Navigate(new EnaSkupina(skupina.Id));
            }
        }
        

       
    }
}
