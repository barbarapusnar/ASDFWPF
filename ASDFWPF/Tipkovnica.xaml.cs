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
    /// Interaction logic for Tipkovnica.xaml
    /// </summary>
    public partial class Tipkovnica : UserControl
    {
        TipkovnicaViewModel _vm;
        public Tipkovnica(int i)
        {
            InitializeComponent();
            _vm = new TipkovnicaViewModel(i);
            this.DataContext = _vm;
        }
    }
}
