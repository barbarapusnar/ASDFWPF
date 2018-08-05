using System;
using System.Collections.ObjectModel;


namespace ASDFWPF
{
    public class SkupineRezultatovDatum  //datumi
    {
        private readonly ObservableCollection<RezultatiZaVajo> _items = new ObservableCollection<RezultatiZaVajo>();
        private string _načinDela;
        private string _title = string.Empty; //datum
        private decimal cas;
        private int do1;
        private double hitrost;
        private int napake;
        private int ocenaH;
        private int ocenaP;
        private int od;
        private decimal procent;
        private int stCrk;
        private int udarci;

        public string Title
        {
            get { return _title; }
            set { _title=value; }
        }

        public string NačinDela
        {
            get { return _načinDela; }
            set { _načinDela = value; }
        }

        public int Napake
        {
            get { return napake; }
            set { napake = value; }
        }

        public int Udarci
        {
            get { return udarci; }
            set { udarci = value; }
        }

        public int StCrk
        {
            get { return stCrk; }
            set { stCrk = value; }
        }

        public decimal Procent
        {
            get { return procent; }
            set { procent = value; }
        }

        public int OcenaP
        {
            get { return ocenaP; }
            set { ocenaP = value; }
        }

        public double Hitrost
        {
            get { return hitrost; }
            set { hitrost = value; }
        }

        public int OcenaH
        {
            get { return ocenaH; }
            set { ocenaH = value; }
        }

        public ObservableCollection<RezultatiZaVajo> Items
        {
            get { return _items; }
        }

        public decimal Cas
        {
            get { return cas; }
            set { cas = value; }
        }

        public int Od
        {
            get { return od; }
            set { od = value; }
        }

        public int Do
        {
            get { return do1; }
            set { do1 = value; }
        }
    }

    public class SkupineRezultatov 
    {
        private readonly ObservableCollection<RezultatiZaVajo> _items = new ObservableCollection<RezultatiZaVajo>();

        private readonly ObservableCollection<SkupineRezultatovDatum> _itemsD =
            new ObservableCollection<SkupineRezultatovDatum>();

        private string _title = string.Empty; //način dela

        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public ObservableCollection<SkupineRezultatovDatum> ItemsD
        {
            get { return _itemsD; }
        }

        public ObservableCollection<RezultatiZaVajo> Items
        {
            get { return _items; }
        }
    }

    public class RezultatiZaVajo 
    {
        private SkupineRezultatovDatum _group;
        private string _imeRac;
        private decimal cas;
        private int id;
        private string nacinDela;
        private int napake;
        private decimal procent;
        private Skupina skupina;
        private int stCrk;
        private int udarci;
        private DateTime zadnjičRešeno;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public string ImeRac
        {
            get { return _imeRac; }
            set { _imeRac = value; }
        }

        public string NacinDela
        {
            get { return nacinDela; }
            set { nacinDela = value; }
        }

        public int Napake
        {
            get { return napake; }
            set { napake = value; }
        }

        public int Udarci
        {
            get { return udarci; }
            set { udarci = value; }
        }

        public int StCrk
        {
            get { return stCrk; }
            set { stCrk = value; }
        }

        public decimal Procent
        {
            get { return procent; }
            set { procent = value; }
        }

        public decimal Cas
        {
            get { return cas; }
            set { cas = value; }
        }

        public DateTime ZadnjičRešeno
        {
            get { return zadnjičRešeno; }
            set { zadnjičRešeno = value; }
        }

        public SkupineRezultatovDatum Group
        {
            get { return _group; }
            set { _group = value; }
        }

        public Skupina Skupina
        {
            get { return skupina; }
            set { skupina = value; }
        }
    }
}