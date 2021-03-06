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
    /// Interaction logic for EnaSkupina.xaml
    /// </summary>
    public partial class EnaSkupina : Page
    {
        private int[] napake;
        private bool[] reseno;
        private TipkanjeDataGroup _group ;
        public TipkanjeDataGroup Group
        {
            get { return this._group; }
            set { this._group = value; }
        }

        public EnaSkupina(string id)
        {
            InitializeComponent();
            txtUporabnik.Text = PrivzetiViewModel.Uporabnik;
            smallImage.Source = PrivzetiViewModel.UporabnikSlika;
            smallImage.Visibility = Visibility.Visible;
            Group = PrivzetiViewModel.GetGroup(id);
            pageTitle.Text = Group.Title;
            txtOpis.Text = Group.Description;
            imGrupe.Source = Group.Image;
            reseno = new bool[Group.Items.Count + 1];
            napake = new int[Group.Items.Count + 1];
           
        }

        private void itemGridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {  if (itemGridView != null &itemGridView.SelectedIndex!=-1)
            {
                int x = itemGridView.SelectedIndex;
                var vaja = Group.Items[x];
                var a = new ZaPagePayload
                {
                    št = vaja.Id,
                    n = NačinDela.Ignoriraj + " " + "prosto",
                    zaporedneŠtevilke = ""
                };
               
                this.NavigationService.Navigate(new PoVajah(a));
            }
           
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            IEnumerable<Rezultati> r = PrivzetiViewModel.GetVsiRezultatiUp(txtUporabnik.Text).ToList();
            var i = 1;
            foreach (var x in Group.Items)
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
           
            itemGridView.ItemsSource = null;
            itemGridView.ItemsSource = Group.Items;
          
        }

       
    }
}
