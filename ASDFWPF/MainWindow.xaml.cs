using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace ASDFWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Page
    {      
        public MainWindow()
        {
            InitializeComponent();
           

        }
        
        private async void  Page_Loaded(object sender, RoutedEventArgs e)
        {


            bi.IsBusy = true;
            await Dispatcher.BeginInvoke(
                (Action)(async() => { await PrivzetiViewModel.NaložiRezultate(); }));
            bi.IsBusy = false;
            mojOkvir.Navigate(new Prijava());
        }
    }
}
