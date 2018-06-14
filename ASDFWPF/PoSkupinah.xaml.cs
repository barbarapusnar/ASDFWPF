using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for PoSkupinah.xaml
    /// </summary>
    public partial class PoSkupinah :Window   {
        PrivzetiViewModel pvm = new PrivzetiViewModel();
        public PoSkupinah()
        {
            InitializeComponent();
            mojOkvir.Navigate(new System.Uri("Prijava.xaml",
              UriKind.RelativeOrAbsolute));
            this.DataContext = pvm;
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
