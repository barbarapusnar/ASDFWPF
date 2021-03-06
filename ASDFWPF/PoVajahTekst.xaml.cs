﻿using System;
using System.Collections.Generic;
using System.IO;
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
using ASDFWPF.Model;
namespace ASDFWPF
{
    /// <summary>
    /// Interaction logic for PoVajahTekst.xaml
    /// </summary>
    public partial class PoVajahTekst : Page
    {
        public StoparicaViewModel vm = new StoparicaViewModel();
        private int časSkupaj;
        
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
        string zaporedneŠtevilke;
        public bool prof { get; set; }
        public List<Vsebina> VsebinaVrstic = new List<Vsebina>();
        public string skupina { get; set; }
        public double udarci { get; set; }
        string tekstDatoteke="";
        public PoVajahTekst(ZaPagePayload2 navigationParameter)
        {
            InitializeComponent();
            txtUporabnik.Text = PrivzetiViewModel.Uporabnik;
            smallImage.Source = PrivzetiViewModel.UporabnikSlika;
            smallImage.Visibility = Visibility.Visible;
            up = PrivzetiViewModel.Uporabnik;
            var y = (ZaPagePayload2)navigationParameter;
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
            zaporedneŠtevilke = y.zaporedneŠtevilke;
            //branje iz datoteke
            Table t1 = new Table();
            doc.Blocks.Add(t1);
            //vsebinaVsega.Inlines.Add( y.imeD);
            t1.RowGroups.Add(new TableRowGroup());
            tekstDatoteke = y.imeD;
            string[] vrsticeTeksta = y.imeD.Split('\n');
            t1.RowGroups[0].Rows.Add(new TableRow());
            int štVrstic = 0;
            TableRow currentRow;
            int začetekOznačevanja = (x % 1000 - 1) * 3;
            vrsticeTeksta = vrsticeTeksta.Skip(začetekOznačevanja - 2).ToArray<string>();
            foreach (string v in vrsticeTeksta)
            {
                t1.RowGroups[0].Rows.Add(new TableRow());
                currentRow = t1.RowGroups[0].Rows[štVrstic];
                if (začetekOznačevanja == 0)
                {
                    if (štVrstic == 0 || štVrstic == 1 || štVrstic == 2)
                    {
                        currentRow.Background = new SolidColorBrush(Colors.Wheat);
                        currentRow.Foreground = new SolidColorBrush(Colors.Black);
                        currentRow.FontSize = 14;
                        currentRow.FontWeight = FontWeights.Bold;
                    }
                }
                else
                {
                    if (štVrstic == 2 || štVrstic == 3 || štVrstic == 4)
                    {
                        currentRow.Background = new SolidColorBrush(Colors.Wheat);
                        currentRow.Foreground = new SolidColorBrush(Colors.Black);
                        currentRow.FontSize = 14;
                        currentRow.FontWeight = FontWeights.Bold;
                    }
                }
                currentRow.Cells.Add(new TableCell(new Paragraph(new Run(v))));
                štVrstic++;
            }

            //var offset = (začetekOznačevanja * (14 + 2)) - vsebnik.ActualHeight / 2;
            //Tukaj je treba nekako skrolat navzdol
            //vsebnik.ScrollToVerticalOffset(4);
            //vsebnik.UpdateLayout();
            //



            časSkupaj = y.časSkupaj;
            napakeSkupaj = y.napakeSkupaj;
            udarciSkupaj = y.številoUdarcevSkupaj;
            štČrkSkupaj = y.štČrkSkupaj;
            štVaj = y.vsehVajSkupaj;
            številkeVaj = new int[štVaj];
            številkeVaj = y.številkeVajZaDan;
            pomžniŠtevec = y.trenutnaPozicijaVaj;
           
            if (načinDela == NačinDela.Test)
            {
                Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Render, new Action(() =>
                {
                    var navWindow = Window.GetWindow(this) as NavigationWindow;
                    if (navWindow != null) navWindow.ShowsNavigationUI = false;
                }));
            }
            if (načinDela == NačinDela.Ignoriraj)
            {
                pageTitle.Text = "Vaja #" + x + " - Vaje " + oba[1];
            }
            else
            {
                pageTitle.Text = "Vaja #" + x + " - " + načinDela + " " + oba[1];
            }
            št = x;

            var item = TekstViewModel.GetVsebina(x);
            VsebinaVrstic = item.ToList();
            grd.ItemsSource = VsebinaVrstic;
            skupina = TekstViewModel.GetSkupinaVaje(x);
            prof = true;
            var dolžina = 0;
            //rezultati skupaj
            txtNapake.Text = napakeSkupaj.ToString();
            txtN.Text = napake.ToString();
            txtH.Text = udarci.ToString();
            if (zaporedneŠtevilke != null)
            {
                txtŠtevilke.Text = zaporedneŠtevilke;
            }
            else
            {
                txtŠtevilke.Text = "";
            }
            // txtŠtevilke.Text = zaporedneŠtevilke;
            if (štČrkSkupaj != 0)
                nvProcentihs.Text = string.Format("{0,5:P2}", (double)napakeSkupaj / štČrkSkupaj);
            else
                nvProcentihs.Text = string.Format("{0,5:P2}", 0.00);
            double procentS = Math.Round((double)napakeSkupaj / štČrkSkupaj * 100,2) / 100.0; 
            int hitrostS = (int)((udarciSkupaj - napakeSkupaj * 25) / (časSkupaj / 60.0));
            if (udarciSkupaj != 0)
            {
                if (procentS * 100 <= 0.2)
                    uds1.Text = "5";
                else if (procentS * 100 <= 0.4)
                    uds1.Text = "4";
                else if (procentS * 100 <= 0.7)
                    uds1.Text = "3";
                else if (procentS * 100 <= 0.99)
                    uds1.Text = "2";
                else
                    uds1.Text = "1";
                if (hitrostS >= 160)
                    uds.Text = "5";
                else if (hitrostS >= 143)
                    uds.Text = "4";
                else if (hitrostS >= 126)
                    uds.Text = "3";
                else if (hitrostS >= 110)
                    uds.Text = "2";
                else
                    uds.Text = "1";
            }
            else
            {
                uds.Text = "";
                uds1.Text = "";
            }
            foreach (var vv in item.ToList())
                dolžina += vv.tekst.Length;
            //rezultati za to vajo
            nvProcentih.Text = string.Format("{0,5:P2}", procentS*100);
            ud.Text = "0";
            udarci = 0;
            m = new Tipkovnica(št);

           // KeyUp += m.Preveri;
           // vsebnik.Children.Add(m);
            switch (načinDela)
            {
                case NačinDela.Ignoriraj:
                   // m.Visibility = Visibility.Visible;
                    //brdTipkovnica.Visibility = Visibility.Visible;
                    //brdLegenda.Visibility = Visibility.Visible;
                    break;
                case NačinDela.Ponovno:
                  //  m.Visibility = Visibility.Visible;
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
                   // m.Visibility = Visibility.Collapsed;
                    brdTipkovnica.Visibility = Visibility.Collapsed;
                    //brdLegenda.Visibility = Visibility.Collapsed;
                    break;
                    //case NačinDela.Neodvisno:
                    //    Window.Current.CoreWindow.Dispatcher.AcceleratorKeyActivated += Dispatcher_AcceleratorKeyActivated;
                    //    m.Visibility = Visibility.Collapsed;
                    //    break;

            }
            txtVnos.CommandBindings.Add(new CommandBinding(ApplicationCommands.Paste, Foo));
            btnZačni.Focus();
        }

        private void Foo(object sender, ExecutedRoutedEventArgs e)
        {
            e.Handled = true;
        }

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
                številoUdarcev = 0;
                vsehČrkVVaji += trenutnaVrstica.tekst.Length;
            }
            else //naslednja vaja
            {
                var a = new ZaPagePayload2();
                //če si v načinu dela je prof preveri ali je že konec sklopa vaj
                //ne na naslednjo številko, ampak na naslednjo vajo v sklopu teh vaj - v načinu jeProf
                if (št != številkeVaj[štVaj - 1])
                  //  if (pomžniŠtevec < štVaj - 1)
                {
                    //naslednja vaja
                    for (int k = 0; k < štVaj; k++)
                    {
                        if (številkeVaj[k] == št)
                        {
                            pomžniŠtevec = k;
                            break;
                        }
                    }
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
                    a.imeD = tekstDatoteke;
                    a.zaporedneŠtevilke = zaporedneŠtevilke;
                    
                }
                else
                {
                    //končaj - v načinu test je treba tukaj nekaj narediti
                    var r = "Statistika za " + načinDela + " za skupino " + opisS;
                    r += "\nŠtevilo udarcev " + udarciSkupaj;
                    r += "\nČas skupaj " + časSkupaj + "s";
                    r += "\nNapake " + napakeSkupaj;

                    var m =
                        Xceed.Wpf.Toolkit.MessageBox.Show("Teksta je konec, lahko ga ponoviš \n" +
                                          r,"Strojepisje",MessageBoxButton.OK,MessageBoxImage.Information);
                    if (načinDela == NačinDela.Test)
                    {
                        Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Render, new Action(() =>
                        {
                            var navWindow = Window.GetWindow(this) as NavigationWindow;
                            if (navWindow != null) navWindow.ShowsNavigationUI = true;
                        }));
                    }
                    //this.NavigationService.Navigate(new VajeTekst());
                    return;
                }

                try
                {
                    this.NavigationService.Navigate(new PoVajahTekst(a));
                }
                catch
                {
                    var a1 = new ZaPagePayload2();
                    a1.št = številkeVaj[0]; //1.2.2019 - ponovi vse skupaj
                    a1.n = načinDela + " " + oba[1];
                    a1.zaporedneŠtevilke = "";
                    this.NavigationService.Navigate(new PoVajahTekst(a1));
                }
            }
        }
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
                    //tbPomoc.Text = "";
                    //tbOK.Text = "";
                    //tbPomoc.Text = trenutnaVrstica.tekst;
                    //tbOK.Visibility = Visibility.Collapsed;
                    for (var a = 0; a < trenutnaVrstica.tekst.Length; a++)
                    {
                        if (trenutnaVrstica.tekst[a] != txtVnos.Text[a])
                        //zamenjaj barvo ozadja
                        {

                            //tbOK.Inlines.Add(
                            //    (new Run { Text = txtVnos.Text[a] + "", Foreground = new SolidColorBrush(Colors.Red) }));
                            napake++;
                            enako = false;
                        }
                        else
                        {
                            //tbOK.Inlines.Add(
                            //    (new Run { Text = txtVnos.Text[a] + "", Foreground = new SolidColorBrush(Colors.Green) }));
                        }
                    }
                    txtNapake.Text = napake.ToString();
                    if (enako)
                    {
                        NovaVrstica();
                    }
                    else
                    {
                        //tbPomoc.Visibility = Visibility.Visible;
                        //tbOK.Visibility = Visibility.Visible;
                        štČrk = 0;
                        txtVnos.Text = "";
                    }
                    break;
                case NačinDela.Briši:
                case NačinDela.Uredi:
                case NačinDela.LahekTest:
                    var enako1 = true;
                    ////tbPomoc.Text = "";
                    ////tbOK.Text = "";
                    ////tbPomoc.Text = trenutnaVrstica.tekst;
                    ////tbOK.Visibility = Visibility.Collapsed;
                    for (var a = 0; a < trenutnaVrstica.tekst.Length; a++)
                    {
                        if (trenutnaVrstica.tekst[a] != txtVnos.Text[a])
                        //zamenjaj barvo ozadja
                        {
                            //tbOK.Inlines.Add(
                            //    (new Run { Text = txtVnos.Text[a] + "", Foreground = new SolidColorBrush(Colors.Red) }));
                            napake++;
                            enako1 = false;
                        }
                        else
                        {
                            //tbOK.Inlines.Add(
                            //    (new Run { Text = txtVnos.Text[a] + "", Foreground = new SolidColorBrush(Colors.Green) }));
                        }
                    }
                    txtNapake.Text = napake.ToString();
                    if (enako1)
                    {
                        NovaVrstica();
                    }
                    else
                    {
                        //tbPomoc.Visibility = Visibility.Visible;
                        //tbOK.Visibility = Visibility.Visible;
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
            //tbOK.Text = "Pravilno!";
            //tbPomoc.Visibility = Visibility.Collapsed;
        }

        private void KonecVaje()
        {
            vm.Stop();

            var čas = (int)vm.Sekunde + vm.Minute * 60;
            var hitrost = (int)((številoUdarcev - napake * 25) / (čas / 60.0)); //preveri
            nvProcentih.Text = string.Format("{0,5:P2}", (double)napake / vsehČrkVVaji);
            ud.Text = številoUdarcev + "";

            časSkupaj = časSkupaj + (int)vm.Sekunde + vm.Minute * 60;

            napakeSkupaj = napakeSkupaj + napake;

            udarciSkupaj = udarciSkupaj + številoUdarcev;

            štČrkSkupaj = štČrkSkupaj + vsehČrkVVaji;

            txtNapake.Text = napakeSkupaj + "";
            txtN.Text = napake.ToString();
            txtH.Text = hitrost.ToString();
            double procentS = Math.Round((double)napakeSkupaj / štČrkSkupaj * 100,2) / 100.0; ;
            int hitrostS = (int)((udarciSkupaj - napakeSkupaj * 25) / (časSkupaj / 60.0));
            if (zaporedneŠtevilke != null)
            {
                if (zaporedneŠtevilke.Length < 40)
                {
                    if (zaporedneŠtevilke == "")
                        zaporedneŠtevilke = št + "";
                    else
                    zaporedneŠtevilke = zaporedneŠtevilke + ", " + št;
                }
                else
                {
                    int zadnja = zaporedneŠtevilke.LastIndexOf(',');
                    if (zadnja != -1)
                        zaporedneŠtevilke = zaporedneŠtevilke.Substring(0, zadnja) + "..." + št;
                }
            }
            else
                zaporedneŠtevilke = št + "";
            txtŠtevilke.Text = zaporedneŠtevilke;
            // uds.Text = udarciSkupaj.ToString();
            if (procentS * 100 <= 0.2)
                uds1.Text = "5";
            else if (procentS * 100 <= 0.4)
                uds1.Text = "4";
            else if (procentS * 100 <= 0.7)
                uds1.Text = "3";
            else if (procentS * 100 <= 0.99)
                uds1.Text = "2";
            else
                uds1.Text = "1";
            if (hitrostS >= 160)
                uds.Text = "5";
            else if (hitrostS >= 143)
                uds.Text = "4";
            else if (hitrostS >= 126)
                uds.Text = "3";
            else if (hitrostS >= 110)
                uds.Text = "2";
            else
                uds.Text = "1";
            //piši v json datoteko nazaj
            štČrk = 0;
            štVrstice = 0;
            trenutnaVrstica = null;
            txtVnos.IsEnabled = false;
            btnZačni.Content = "Naslednja vaja";

            btnZačni.IsEnabled = true;
            //if (načinDela != NačinDela.Test)
            //    backButton.IsEnabled = true;
           
            //lahko začne znova, samo če ima cikel vaj, sicer iz vaje ne more iti na drugo vajo kot eno naprej      
            //tbOK.Text = "";
            grd.SelectedIndex = 0;
            var način = načinDela + " " + oba[1];
            //prava pozicija
            var nov = PrivzetiViewModel.SetItemR(št, napake, čas, številoUdarcev, vsehČrkVVaji, način, up, opisS);
            //var busyIndicator = PrepareIndeterminateTask("Počakaj trenutek, rezultati samo na tem računalniku");
            PrivzetiViewModel.PišiRezultate();

            // CleanUpIndeterminateTask(busyIndicator);

            btnZačni.Focus();
        }

   
        private void Spremeni(object sender, TextChangedEventArgs e)
        {
            if (trenutnaVrstica != null && štČrk == trenutnaVrstica.tekst.Length)
            {
                KonecVrstice();
            }
        }

        private void btnStatistika_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Statistika(načinDela));
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
       
        private void txtVnos_PreviewKeyDown(object sender, KeyEventArgs e)
        {

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
            if ((!jeKapps && !jeS) || (jeKapps && jeS))
                vnešenZnak = char.ToLower(vnešenZnak);
            if (vnešenZnak == 186 && ((!jeKapps && !jeS) || (jeKapps && jeS)))
                vnešenZnak = 'č';
            if (vnešenZnak == 186 && ((jeKapps && !jeS) || (jeS && !jeKapps)))
                vnešenZnak = 'Č';
            if (vnešenZnak == 253 && ((!jeKapps && !jeS) || (jeKapps && jeS)))
                vnešenZnak = 'đ';
            if (vnešenZnak == 221 && ((jeKapps && !jeS) || (jeS && !jeKapps)))
                vnešenZnak = 'Đ';
            if (vnešenZnak == 254 && ((!jeKapps && !jeS) || (jeKapps && jeS)))
                vnešenZnak = 'ć';
            if (vnešenZnak == 222 && ((jeKapps && !jeS) || (jeS && !jeKapps)))
                vnešenZnak = 'Ć';
            if (vnešenZnak == 251 && ((!jeKapps && !jeS) || (jeKapps && jeS)))
                vnešenZnak = 'š';
            if (vnešenZnak == 219 && ((jeKapps && !jeS) || (jeS && !jeKapps))) //!!
                vnešenZnak = 'Š';
            if (vnešenZnak == 252 && ((!jeKapps && !jeS) || (jeKapps && jeS)))
                vnešenZnak = 'ž';
            if (vnešenZnak == 220 && ((jeKapps && !jeS) || (jeS && !jeKapps)))
                vnešenZnak = 'Ž';
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
            številoUdarcev++;
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
                        txtN.Text = napake.ToString();
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

        private void TxtVnos_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            e.Handled = true;
        }

        private void Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Back)
            {
                e.Handled = true;
                return;
            }
        }
    }
}
