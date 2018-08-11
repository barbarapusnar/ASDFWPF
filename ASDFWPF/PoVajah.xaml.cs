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
using Xceed.Wpf.Toolkit;

namespace ASDFWPF
{
    /// <summary>
    /// Interaction logic for PoVajah.xaml
    /// </summary>
    public partial class PoVajah : Page
    {
        public StoparicaViewModel vm = new StoparicaViewModel();
        private int časSkupaj;
        private bool jeProf;
        private Tipkovnica m;
        private NačinDela načinDela;
        public int napake { get; set; }
        private int napakeSkupaj;
        private List<Key> narobe = new List<Key>();
        private string[] oba = new string[2];
        private string opisS = "";
        private int pomžniŠtevec;
        private char praviZnak = (char)0;
        private int št = 1;
        private int štČrk;
        private int štČrkSkupaj;
        private int številkaVaje;
        private int[] številkeVaj;
        private int številoUdarcev;
        private int štVaj;
        private int štVrstice;
        private Vsebina trenutnaVrstica = new Vsebina();
        private int udarciSkupaj;
        private string up = "";
        private char vnešenZnak = (char)0;
        private int vsehČrkVVaji;
        public bool prof { get; set; }
        public List<Vsebina> VsebinaVrstic = new List<Vsebina>();
        public string skupina { get; set; }
        public double udarci { get; set; }
        public PoVajah(ZaPagePayload navigationParameter)
        {
            InitializeComponent();
            
            txtUporabnik.Text = PrivzetiViewModel.Uporabnik;
            smallImage.Source = PrivzetiViewModel.UporabnikSlika;
            smallImage.Visibility = Visibility.Visible;
            up = PrivzetiViewModel.Uporabnik;
            var y = (ZaPagePayload)navigationParameter;
            var x = y.št;
            številkaVaje = x;
            opisS = y.opisS;
            oba = y.n.Split(' ');
            switch (oba[0])
            {
                case "Ignoriraj":
                    načinDela = NačinDela.Ignoriraj;
                    break;
                case "Ponovno":
                    načinDela = NačinDela.Ponovno;
                    break;
                case "Briši":
                    načinDela = NačinDela.Briši;
                    break;
                case "Uredi":
                    načinDela = NačinDela.Uredi;
                    break;
                case "LahekTest":
                    načinDela = NačinDela.LahekTest;
                    break;
                case "Test":
                    načinDela = NačinDela.Test;
                    break;
                case "Neodvisno":
                    načinDela = NačinDela.Neodvisno;
                    break;
            }

            if (oba[1] != "prosto")
                jeProf = true;
            if (jeProf)
                barNacin.IsEnabled = false;
            if (!jeProf || načinDela == NačinDela.Test)
                btnNovaVaja.Visibility = Visibility.Collapsed;
            else
                btnNovaVaja.Visibility = Visibility.Visible;
            časSkupaj = y.časSkupaj;
            napakeSkupaj = y.napakeSkupaj;
            udarciSkupaj = y.številoUdarcevSkupaj;
            štČrkSkupaj = y.štČrkSkupaj;
            štVaj = y.vsehVajSkupaj;
            številkeVaj = new int[štVaj];
            številkeVaj = y.številkeVajZaDan;
            pomžniŠtevec = y.trenutnaPozicijaVaj;
            //tukaj bo vseeno treba nekaj narediti
            //if (načinDela == NačinDela.Test)
            //{
            //    backButton.IsEnabled = false;
            //}
            if (načinDela == NačinDela.Ignoriraj)
            {
                pageTitle.Text = "Vaja #" + x + " - Vaje " + oba[1];
            }
            else
            {
                pageTitle.Text = "Vaja #" + x + " - " + načinDela + " " + oba[1];
            }
            št = x;
            
            var item = PrivzetiViewModel.GetVsebina(x);
            if (item.Count() == 0)
            {
                x = (x++) % 163;
                št = x;
                item = PrivzetiViewModel.GetVsebina(x);
            }
            VsebinaVrstic = item.ToList();
            grd.ItemsSource = VsebinaVrstic;
            //če ni rezultatov dam na 0
            
            //stari rezultati - poberem, če je vaja že rešena
            //this.DefaultViewModel["napake"] = PrivzetiViewModel.GetNapake(x);   
            //dejansko gre za hitrost po formuli
            //this.DefaultViewModel["udarci"] = PrivzetiViewModel.GetUdarcevNaMinuto(x);
            skupina = PrivzetiViewModel.GetSkupinaVaje(x);
            prof = jeProf;
            var dolžina = 0;
            //rezultati skupaj
            txtNapake.Text = napakeSkupaj.ToString();
            txtN.Text = napake.ToString();
            txtH.Text = udarci.ToString();
            if (štČrkSkupaj != 0)
                nvProcentihs.Text = string.Format("{0,5:P2}", (double)napakeSkupaj / štČrkSkupaj);
            else
                nvProcentihs.Text = string.Format("{0,5:P2}", 0.00);
            uds.Text = udarciSkupaj.ToString();
            if (časSkupaj != 0)
                txtHitrost.Text = ((int)((udarciSkupaj - napakeSkupaj * 25) / (časSkupaj / 60.0))).ToString();
            else
                txtHitrost.Text = "0";
            foreach (var vv in item.ToList())
                dolžina += vv.tekst.Length;
            //rezultati za to vajo
            nvProcentih.Text = string.Format("{0,5:P2}", 0.00);
            ud.Text = "0";
            //DefaultViewModel["napake"] = napake;
            udarci = 0;
            //nvProcentih.Text = String.Format("{0,5:P2}", (double)PrivzetiViewModel.GetNapake(x)/ dolžina);
            //ud.Text = PrivzetiViewModel.GetUdarcev(x).ToString() ;
            m = new Tipkovnica(št);
            KeyUp += m.Preveri;
            vsebnik.Children.Add(m);
            switch (načinDela)
            {
                case NačinDela.Ignoriraj:
                    m.Visibility = Visibility.Visible;
                    brdTipkovnica.Visibility = Visibility.Visible;
                    brdLegenda.Visibility = Visibility.Visible;
                    break;
                case NačinDela.Ponovno:
                    m.Visibility = Visibility.Visible;
                    break;
                //case NačinDela.Briši:
                //    m.Visibility = Visibility.Visible;
                //    Window.Current.CoreWindow.Dispatcher.AcceleratorKeyActivated += Dispatcher_AcceleratorKeyActivated;
                //    break;
                //case NačinDela.Uredi:
                //    m.Visibility = Visibility.Visible;
                //    Window.Current.CoreWindow.Dispatcher.AcceleratorKeyActivated += Dispatcher_AcceleratorKeyActivated;
                //    break;
                //case NačinDela.LahekTest:
                //    m.Visibility = Visibility.Collapsed;
                //    Window.Current.CoreWindow.Dispatcher.AcceleratorKeyActivated += Dispatcher_AcceleratorKeyActivated;
                //    break;
                case NačinDela.Test:
                    m.Visibility = Visibility.Collapsed;
                    brdTipkovnica.Visibility = Visibility.Collapsed;
                    brdLegenda.Visibility = Visibility.Collapsed;
                    break;
                //case NačinDela.Neodvisno:
                //    Window.Current.CoreWindow.Dispatcher.AcceleratorKeyActivated += Dispatcher_AcceleratorKeyActivated;
                //    m.Visibility = Visibility.Collapsed;
                //    break;
                
            }
            btnZačni.Focus();
        }
        //private void Dispatcher_AcceleratorKeyActivated(CoreDispatcher sender, AcceleratorKeyEventArgs args)
        //{
        //    //tako onemogočiš akceleratorske tipke
        //    if (načinDela == NačinDela.Ignoriraj || načinDela == NačinDela.Ponovno)
        //    {
        //        if (args.VirtualKey == Key.Back)
        //        {
        //            //sedaj prikaže ' in % dela pa tudi puščica levo, desno
        //            args.Handled = true;
        //        }
        //        var shiftKey = (Window.Current.CoreWindow.GetKeyState(VirtualKey.Shift) & CoreVirtualKeyStates.Down) ==
        //                       CoreVirtualKeyStates.Down;
        //        if (args.VirtualKey == Key.Left && !shiftKey)
        //            args.Handled = true;
        //        //manjka še ' in desni smernik
        //    }
        //    if (načinDela == NačinDela.Briši)
        //    {
        //        if (args.VirtualKey == VirtualKey.Left || args.VirtualKey == VirtualKey.Right)
        //            args.Handled = true;
        //        var shiftKey = (Window.Current.CoreWindow.GetKeyState(VirtualKey.Shift) & CoreVirtualKeyStates.Down) ==
        //                       CoreVirtualKeyStates.Down;
        //        if (args.VirtualKey == VirtualKey.Left && !shiftKey)
        //            args.Handled = true;
        //    }
        //}

        private void ZačniZVajo(object sender, RoutedEventArgs e)
        {
            btnPrav1.Visibility = Visibility.Collapsed;
            btnPrav2.Visibility = Visibility.Collapsed;
            btnPrav3.Visibility = Visibility.Collapsed;
            grd.SelectedIndex = 0;
            if (btnZačni.Content.Equals("Začni z vajo"))
            {
                btnZačni.IsEnabled = false;
                štVrstice = 0;
                var vrstice = VsebinaVrstic.ToList();
                trenutnaVrstica = (Vsebina)vrstice[štVrstice];
                txtVnos.IsEnabled = true;
                vm = (StoparicaViewModel)ura.Resources["vm"];              
                vm.Start();
                txtVnos.Focus();
                štČrk = 0;
                napake = 0;
                btnNovaVaja.IsEnabled = false;
               // backButton.IsEnabled = false; mogoče v vrstici, kjer ga imaš
                barNacin.IsEnabled = false;
                številoUdarcev = 0;
                vsehČrkVVaji += trenutnaVrstica.tekst.Length;
            }
            else
            {
                var a = new ZaPagePayload();
                //če si v načinu dela je prof preveri ali je že konec sklopa vaj
                //ne na naslednjo številko, ampak na naslednjo vajo v sklopu teh vaj - v načinu jeProf
                if (!jeProf)
                {
                    št++;

                    a.št = št;
                    a.n = načinDela + " " + oba[1];
                    a.napakeSkupaj = napakeSkupaj;
                    a.štČrkSkupaj = štČrkSkupaj;
                    a.številoUdarcevSkupaj = udarciSkupaj;
                    a.časSkupaj = časSkupaj;
                }
                else
                {
                    if (pomžniŠtevec < štVaj - 1)
                    {
                        //naslednja vaja
                        pomžniŠtevec++;
                        št = številkeVaj[pomžniŠtevec];

                        a.št = št;
                        a.n = načinDela + " " + oba[1];
                        a.napakeSkupaj = napakeSkupaj;
                        a.štČrkSkupaj = štČrkSkupaj;
                        a.številoUdarcevSkupaj = udarciSkupaj;
                        a.časSkupaj = časSkupaj;
                        a.vsehVajSkupaj = štVaj;
                        a.številkeVajZaDan = številkeVaj;
                        a.trenutnaPozicijaVaj = pomžniŠtevec;
                        a.opisS = opisS;
                    }
                    else
                    {
                        //končaj - v načinu test je treba tukaj nekaj narediti
                        var r = "Statistika za " + načinDela + " za skupino " + opisS;
                        r += "\nŠtevilo udarcev " + udarciSkupaj;
                        r += "\nČas skupaj " + časSkupaj + "s";
                        r += "\nNapake " + napakeSkupaj;

                        var m =
                            Xceed.Wpf.Toolkit.MessageBox.Show("Ta sklop si končal, lahko ga ponoviš ali se vrneš na začetni zaslon\n" +
                                              r);
                        //m.Commands.Add(new UICommand("Ponovno začni", CommandInvokedHandler1));
                        //m.Commands.Add(new UICommand("Prekliči", CommandInvokedHandler2));

                        //// Set the command that will be invoked by default
                        //m.DefaultCommandIndex = 0;

                        //// Set the command to be invoked when escape is pressed
                        //m.CancelCommandIndex = 1;

                        //// Show the message dialog
                        //await m.ShowAsync();

                        return;
                    }
                }
                try
                {
                    this.NavigationService.Navigate(new PoVajah(a));
                }
                catch
                {
                    var a1 = new ZaPagePayload();
                    a1.št = 1;
                    a1.n = načinDela + " " + oba[1];
                    this.NavigationService.Navigate(new PoVajah(a1));
                }
            }
        }

        //prekliči
        //private void CommandInvokedHandler2(IUICommand command)
        //{
        //    Frame.Navigate(typeof(Prijava), PrivzetiViewModel.Uporabnik);
        //}

        ////ponovno začni
        //private void CommandInvokedHandler1(IUICommand command)
        //{
        //    Frame.Navigate(typeof(SkupinaZaEnDan), opisS);
        //}

       

        private void KonecVrstice() //ali je dovolj črk ali je enter
        {
            // pojdi v novo vrstico
            //še prikaži kljukico na odtipkani vrstici
            if (trenutnaVrstica.vrstica == 1)
                btnPrav1.Visibility = Visibility.Visible;
            if (trenutnaVrstica.vrstica == 2)
                btnPrav2.Visibility = Visibility.Visible;
            if (trenutnaVrstica.vrstica == 3)
                btnPrav3.Visibility = Visibility.Visible;
            switch (načinDela)
            {
                case NačinDela.Ignoriraj:
                case NačinDela.Test:
                    NovaVrstica();
                    break;
                case NačinDela.Ponovno:
                    var enako = true;
                    tbPomoc.Text = "";
                    tbOK.Text = "";
                    tbPomoc.Text = trenutnaVrstica.tekst;
                    tbOK.Visibility = Visibility.Collapsed;
                    for (var a = 0; a < trenutnaVrstica.tekst.Length; a++)
                    {
                        if (trenutnaVrstica.tekst[a] != txtVnos.Text[a])
                        //zamenjaj barvo ozadja
                        {
                            tbOK.Inlines.Add(
                                (new Run { Text = txtVnos.Text[a] + "", Foreground = new SolidColorBrush(Colors.Red) }));
                            napake++;
                            enako = false;
                        }
                        else
                        {
                            tbOK.Inlines.Add(
                                (new Run { Text = txtVnos.Text[a] + "", Foreground = new SolidColorBrush(Colors.Green) }));
                        }
                    }
                    txtNapake.Text = napake.ToString();
                    if (enako)
                    {
                        NovaVrstica();
                    }
                    else
                    {
                        tbPomoc.Visibility = Visibility.Visible;
                        tbOK.Visibility = Visibility.Visible;
                        štČrk = 0;
                        txtVnos.Text = "";
                    }
                    break;
                case NačinDela.Briši:
                case NačinDela.Uredi:
                case NačinDela.LahekTest:
                    var enako1 = true;
                    tbPomoc.Text = "";
                    tbOK.Text = "";
                    tbPomoc.Text = trenutnaVrstica.tekst;
                    tbOK.Visibility = Visibility.Collapsed;
                    for (var a = 0; a < trenutnaVrstica.tekst.Length; a++)
                    {
                        if (trenutnaVrstica.tekst[a] != txtVnos.Text[a])
                        //zamenjaj barvo ozadja
                        {
                            tbOK.Inlines.Add(
                                (new Run { Text = txtVnos.Text[a] + "", Foreground = new SolidColorBrush(Colors.Red) }));
                            napake++;
                            enako1 = false;
                        }
                        else
                        {
                            tbOK.Inlines.Add(
                                (new Run { Text = txtVnos.Text[a] + "", Foreground = new SolidColorBrush(Colors.Green) }));
                        }
                    }
                    txtNapake.Text= napake.ToString();
                    if (enako1)
                    {
                        NovaVrstica();
                    }
                    else
                    {
                        tbPomoc.Visibility = Visibility.Visible;
                        tbOK.Visibility = Visibility.Visible;
                        štČrk = txtVnos.Text.Length - 1;
                        //pri načinu dela briši je treba spremeniti trenutni položaj v textboxu vrednost spremenljivke štČrk
                        txtVnos.Focus();
                    }
                    break;


                case NačinDela.Neodvisno:
                    NovaVrstica();
                    break;
            }
        }

        private void NovaVrstica()
        {
            štVrstice++;
            štČrk = 0;
            txtVnos.Text = "";

            udarci = (int)((številoUdarcev - napake * 25) / ((vm.Sekunde + vm.Minute * 60) / 60));
            if (štVrstice > 2)
            {
                KonecVaje();
                return;
            }
            var vrstice = VsebinaVrstic.ToList();
            trenutnaVrstica = (Vsebina)vrstice[štVrstice];
            vsehČrkVVaji += trenutnaVrstica.tekst.Length;
            grd.SelectedIndex = štVrstice;
            tbOK.Text = "Pravilno!";
            tbPomoc.Visibility = Visibility.Collapsed;
        }

        private  void KonecVaje()
        {
            vm.Stop();

            var čas = (int)vm.Sekunde + vm.Minute * 60;
            var hitrost = (int)(številoUdarcev / (čas / 60.0));
            nvProcentih.Text = string.Format("{0,5:P2}", (double)napake / vsehČrkVVaji);
            ud.Text = številoUdarcev + "";

            časSkupaj = časSkupaj + (int)vm.Sekunde + vm.Minute * 60;

            napakeSkupaj = napakeSkupaj + napake;

            udarciSkupaj = udarciSkupaj + številoUdarcev;

            štČrkSkupaj = štČrkSkupaj + vsehČrkVVaji;

            txtNapake.Text = napakeSkupaj + "";
            txtN.Text = napake.ToString();
            txtH.Text = hitrost.ToString();
            if (časSkupaj != 0)
                txtHitrost.Text = ((int)((udarciSkupaj - napakeSkupaj * 25) / (časSkupaj / 60.0))).ToString();
            nvProcentihs.Text = string.Format("{0,5:P2}", (double)napakeSkupaj / štČrkSkupaj);
            uds.Text = udarciSkupaj.ToString();
            //piši v json datoteko nazaj
            štČrk = 0;
            štVrstice = 0;
            trenutnaVrstica = null;
            txtVnos.IsEnabled = false;
            btnZačni.Content = "Naslednja vaja";
            btnZačni.IsEnabled = true;
            //if (načinDela != NačinDela.Test)
            //    backButton.IsEnabled = true;
            if (jeProf && načinDela != NačinDela.Test)
            {
                btnNovaVaja.IsEnabled = true;
                //v bistvu z vrstnim redom omogočanja gumbov, določaš fokus
                //string f= (FocusManager.GetFocusedElement() as Button).Content.ToString();
                //FocusManager.TryMoveFocus(FocusNavigationDirection.Next);
                //FocusManager.TryMoveFocus(FocusNavigationDirection.Next);               
            }
            //lahko začne znova, samo če ima cikel vaj, sicer iz vaje ne more iti na drugo vajo kot eno naprej      

            if (!jeProf)
                barNacin.IsEnabled = true;
            tbOK.Text = "";
            grd.SelectedIndex = 0;
            var način = načinDela + " " + oba[1];
            //prava pozicija
            var nov = PrivzetiViewModel.SetItemR(št, napake, čas, številoUdarcev, vsehČrkVVaji, način, up, opisS);
            // tudi tukaj je treba poskrbeti, da se bodo rezultati pisali tudi, ko ni strežnika
            //  samo lokalni zapis po vsaki vaji, po vseh vajah v eni skupini ali ko se gre na novo stran, zapis na strežnik,če obstaja
            // pišemo samo na strežnik vsako vajo, lokalno je že v memory , 
            // pišemo, ko zapustimo sklop ali še bolje zapremo program
            // await PrivzetiViewModel.PišiRezultate(nov);
            //var uspeh = false;
            //if (App.IsInternet() && PrivzetiViewModel.JeServis)
            //{
            //    uspeh = await PrivzetiViewModel.PišiRezultateRemote(nov);
            //}
            //if (!uspeh)
            //{
                var busyIndicator = PrepareIndeterminateTask("Počakaj trenutek, rezultati samo na tem računalniku");
                PrivzetiViewModel.PišiRezultate();
                CleanUpIndeterminateTask(busyIndicator);
          //  }
            //else
            //{

            //}
            //tukaj je problem, če prehitro pritisneš na enter, preden zapie karkoli - disable???
            //  btnZačni.Focus(FocusState.Programmatic);
        }

        private void CleanUpIndeterminateTask(BusyIndicator busyIndicator)
        {
            busyIndicator.Visibility = Visibility.Collapsed;
        }

        private BusyIndicator PrepareIndeterminateTask(string p)
        {
            var busyIndicator = new BusyIndicator();
            return (busyIndicator);
        }
        //bo treba napisati, a verjetno ne tukaj
        //protected override async void GoBack(object sender, RoutedEventArgs e)
        //{
        //    if (jeProf)
        //    {
        //        // base.GoBack(sender, e);
        //        var m = new MessageDialog("Od tu ne moreš nazaj, lahko samo ponoviš celoten sklop vaj");
        //        m.Commands.Add(new UICommand("Ponovno začni", CommandInvokedHandler));
        //        m.Commands.Add(new UICommand("Prekliči", CommandInvokedHandler));

        //        // Set the command that will be invoked by default
        //        m.DefaultCommandIndex = 0;

        //        // Set the command to be invoked when escape is pressed
        //        m.CancelCommandIndex = 1;

        //        // Show the message dialog
        //        await m.ShowAsync();
        //    }
        //    else
        //    {
        //        var x = PrivzetiViewModel.GetItem(št);
        //        Frame.Navigate(typeof(EnaSkupina), x.Group.Id);
        //    }
        //}

        //private void CommandInvokedHandler(IUICommand command)
        //{
        //    if (command.Label.Equals("Ponovno začni"))
        //        Frame.Navigate(typeof(Prijava), PrivzetiViewModel.Uporabnik);
        //}

        private void Spremeni(object sender, TextChangedEventArgs e)
        {
            if (trenutnaVrstica != null && štČrk == trenutnaVrstica.tekst.Length)
            {
                KonecVrstice();
            }
        }

        private void btnStatistika_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Statistika (načinDela));
        }

        private void txtVnos_KeyUp(object sender, KeyEventArgs e)
        {
            m.VrniShift();
        }

        private void txtVnos_LostFocus(object sender, RoutedEventArgs e)
        {
            vm.Stop();
        }

        private void txtVnos_GotFocus(object sender, RoutedEventArgs e)
        {
            vm.Start();
        }

        private void ZacniZnova(object sender, RoutedEventArgs e)
        {
            if (jeProf)
            {
                //izbrisati je treba vse stare rezultate in začeti znova  
                var ZaOdstrani = from b in PrivzetiViewModel.GetVsiRezultatiUp(PrivzetiViewModel.Uporabnik)
                                 where b.skupina.OpisSkupine == opisS && b.način == načinDela + " prof "
                                 select b;
                foreach (var x in ZaOdstrani)
                    PrivzetiViewModel.Briši(x);
                //TO IZBRIŠE SAMO LOKALNO - STREŽNIK???
                pomžniŠtevec = 0;
                št = številkeVaj[pomžniŠtevec];
                var a = new ZaPagePayload();
                a.št = št;
                a.n = načinDela + " " + oba[1];
                a.napakeSkupaj = 0;
                a.štČrkSkupaj = 0;
                a.številoUdarcevSkupaj = 0;
                a.časSkupaj = 0;
                a.vsehVajSkupaj = štVaj;
                a.številkeVajZaDan = številkeVaj;
                a.trenutnaPozicijaVaj = pomžniŠtevec;
                a.opisS = opisS;
                this.NavigationService.Navigate(new PoVajah(a));
              
            }
        }

        private void txtVnos_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            številoUdarcev++;
            int pomožna = (int)(KeyInterop.VirtualKeyFromKey(e.Key));
            vnešenZnak = (char)(pomožna);
            praviZnak = trenutnaVrstica.tekst[štČrk];
            if (e.Key == Key.CapsLock)
                return; //če smo prižgali caps lock naj ne šteje črk
            if (e.Key == Key.Enter)
                return; //samo, da ne šteje črk
            var jeS = false;
            if (Keyboard.IsKeyDown(Key.LeftShift) || Keyboard.IsKeyDown(Key.RightShift))
            {
                jeS = true;
                m.PreveriShift();
            }
            

            if (e.Key == Key.RightShift || e.Key == Key.LeftShift)
                return;
            var jeKapps = Console.CapsLock;
            if (!jeKapps && !jeS)
                vnešenZnak = char.ToLower(vnešenZnak);
            if (vnešenZnak == 186 && !jeKapps && !jeS)
                vnešenZnak = 'č';
            if (vnešenZnak == 186 && (jeKapps || jeS))
                vnešenZnak = 'Č';
            if (vnešenZnak == 253 && !jeKapps && !jeS)
                vnešenZnak = 'đ';
            if (vnešenZnak == 253 && (jeKapps || jeS))
                vnešenZnak = 'Đ';
            if (vnešenZnak == 254 && !jeKapps && !jeS)
                vnešenZnak = 'ć';
            if (vnešenZnak == 254 && (jeKapps || jeS))
                vnešenZnak = 'Ć';
            if (vnešenZnak == 251 && !jeKapps && !jeS)
                vnešenZnak = 'š';
            if (vnešenZnak == 251 && (jeKapps || jeS))
                vnešenZnak = 'Š';
            if (vnešenZnak == 252 && !jeKapps && !jeS)
                vnešenZnak = 'ž';
            if (vnešenZnak == 252 && (jeKapps || jeS))
                vnešenZnak = 'ž';
            if (vnešenZnak == 191 && !jeKapps && !jeS)
                vnešenZnak = '\'';
            if (vnešenZnak == 191 && (jeKapps || jeS))
                vnešenZnak = '?';
            if (vnešenZnak == 226 && !jeKapps && !jeS)
                vnešenZnak = '<';
            if (vnešenZnak == 226 && (jeKapps || jeS))
                vnešenZnak = '>';
            if (vnešenZnak == 190 && jeS)
                vnešenZnak = ':';
            if (vnešenZnak == 190 && !jeS)
                vnešenZnak = '.';
            if (vnešenZnak == 188 && !jeS)
                vnešenZnak = ',';
            if (vnešenZnak == 188 && jeS)
                vnešenZnak = ';';
            if (vnešenZnak == 189 && !jeKapps && !jeS)
                vnešenZnak = '-';
            if (vnešenZnak == 189 && (jeKapps || jeS))
                vnešenZnak = '_';
            if (vnešenZnak == 187 && !jeKapps && !jeS)
                vnešenZnak = '+';
            if (vnešenZnak == 187 && (jeKapps || jeS))
                vnešenZnak = '*';
            if (vnešenZnak == 48 && (jeKapps || jeS))
                vnešenZnak = '=';
            if (vnešenZnak == 49 && (jeKapps || jeS))
                vnešenZnak = '!';
            if (vnešenZnak == 50 && (jeKapps || jeS))
                vnešenZnak = '"';
            if (vnešenZnak == 51 && (jeS))
                vnešenZnak = '#';
            if (vnešenZnak == 52 && (jeS))
                vnešenZnak = '$';
            if (vnešenZnak == 53 && (jeS))
                vnešenZnak = '%';
            if (vnešenZnak == 54 && (jeS))
                vnešenZnak = '&';
            if (vnešenZnak == 55 && (jeS))
                vnešenZnak = '/';
            if (vnešenZnak == 56 && (jeS))
                vnešenZnak = '(';
            if (vnešenZnak == 57 && (jeS))
                vnešenZnak = ')';

            switch (načinDela)
            {
                case NačinDela.Ignoriraj:
                    if (e.Key == Key.Back)
                    {
                        e.Handled = true;
                        return;
                    }
                    if (vnešenZnak != praviZnak)
                    {
                        napake++;
                        txtNapake.Text = napake.ToString();
                        m.PobarvajNapačno(e.Key);
                        narobe.Add(e.Key);
                        e.Handled = true;
                        return;
                    }
                    if (vnešenZnak == praviZnak && narobe.Count > 0)
                    {
                        m.Ponastavi(narobe);
                        narobe = new List<Key>();
                    }
                    break;
                case NačinDela.Ponovno:
                    //if (e.Key == VirtualKey.Enter) //dodano, ker je šlo prehitro v novo vrstico 
                    //    return; //prenos noavzgor, verjetno je problem še kje druge
                    break;
                case NačinDela.Briši:
                    if (e.Key == Key.Back)
                    {
                        štČrk--;
                        return;
                    }
                    break;
                case NačinDela.Uredi:
                case NačinDela.LahekTest:
                    if (e.Key == Key.Back)
                    {
                        štČrk--;
                        return;
                    }
                    //če grem levo ali desno v bistvu vrivam in se nič ne spremeni
                    //kontrola je na koncu vrtsice
                    break;
                case NačinDela.Test:
                    if (vnešenZnak != praviZnak)
                    {
                        napake++;
                        txtNapake.Text = napake.ToString();
                        e.Handled = true;
                        return;
                    }
                    break;
            }
            štČrk++;
        }
    }
}
