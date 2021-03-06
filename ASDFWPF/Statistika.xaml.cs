﻿using System;
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
    /// Interaction logic for Statistika.xaml
    /// </summary>
    public partial class Statistika : Page
    {
        //public List<SkupineRezultatov> Groups { get; set; }
        public List<SkupineRezultatovDatum> GroupsD { get; set; }
        public Statistika(NačinDela način)
        {
            InitializeComponent();
            txtUporabnik.Text = PrivzetiViewModel.Uporabnik;
            smallImage.Source = PrivzetiViewModel.UporabnikSlika;
            smallImage.Visibility = Visibility.Visible;

            StatistikaVM.NaložiRezultateAsync();
            var sampleDataGroupsD = StatistikaVM.GetGroupsD("AllGroups");

            GroupsD = sampleDataGroupsD.ToList(); 
            itemGridView.ItemsSource = GroupsD;
           

        }

        private void itemGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var a = new ZaPagePayload1();
            a.title = ((SkupineRezultatovDatum)itemGridView.SelectedItem).Title;
            a.n = ((SkupineRezultatovDatum)itemGridView.SelectedItem).NačinDela;
            this.NavigationService.Navigate(new RezultatiPoVajahZaEnDan(a));
        }
    }
}
