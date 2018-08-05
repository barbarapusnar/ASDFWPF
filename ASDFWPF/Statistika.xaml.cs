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
        public List<SkupineRezultatov> Groups { get; set; }
        public List<SkupineRezultatovDatum> GroupsD { get; set; }
        public Statistika(NačinDela način)
        {
            InitializeComponent();
            StatistikaVM.NaložiRezultateAsync();
            var sampleDataGroups = StatistikaVM.GetGroups("AllGroups");
            Groups= sampleDataGroups.ToList();
            var sampleDataGroupsD = StatistikaVM.GetGroupsD("AllGroups");
            GroupsD= sampleDataGroupsD.ToList();
            itemGridView.ItemsSource = Groups;
            itemListView.ItemsSource = GroupsD;
        }
    }
}