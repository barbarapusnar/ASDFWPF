using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ASDFWPF
{
    class TipkovnicaViewModel:INotifyPropertyChanged

    {
        private readonly string[] r;
        private bool _isCapsLock;
        private bool _jeNarobe;
        private string apostrof;
        private string devet;
        private string dva;
        private string ena;
        private string nič;
        private string osem;
        private string pet;
        private string plus;
        private string sedem;
        private string sklop;
        private string šest;
        private string štiri;
        private string tri;

        public TipkovnicaViewModel(int i)
        {
            Tt = false;
            Dt = false;
            Pt = false;
            Ni = false;
            T = false;
            D = false;
            P = false;
            r = PrivzetiViewModel.GetCrke(i);
            // sklop = PrivzetiViewModel.GetSkupinaVaje(i);
            string[] ničta =
            {
                "1", "2", "3", "4", "5", "6", "7", "8", "9", "0", "'", "+", "!", "\"", "#", "$", "%", "&",
                "/", "(", ")", "?", "*"
            };
            string[] prva =
            {
                "Q", "W", "E", "R", "T", "Z", "U", "I", "O", "P", "Š", "Đ", "q", "w", "e", "r", "t", "z",
                "u", "i", "o", "p", "š", "đ"
            };
            string[] druga =
            {
                "A", "S", "D", "F", "G", "H", "J", "K", "L", "Č", "Ć", "Ž", "a", "s", "d", "f", "g", "h",
                "j", "k", "l", "č", "ć", "ž"
            };
            string[] tretja =
            {
                "Y", "X", "C", "V", "B", "N", "M", "y", "x", "c", "v", "b", "n", "m", ",", ".", "-", ";",
                ":"
            };
            foreach (var a in r)
            {
                if (ničta.Contains(a))
                {
                    Ni = true;
                    OnPropertyChanged("Ni");
                    switch (a)
                    {
                        case "1":
                        case "!":
                            //                             OzadjeQ = Color.FromArgb(0xFF, 0x71, 0x6F, 0x64);
                            Ozadje1 = Color.FromArgb(0xFF, 0x36, 0xaa, 0x9d);
                            OnPropertyChanged("Ozadje1");
                            //tekstQ = true;
                            //OnPropertyChanged("tekstQ");
                            break;
                        case "\"":
                        case "2":
                            Ozadje2 = Color.FromArgb(0xff, 0x11, 0x6e, 0xa9);
                            OnPropertyChanged("Ozadje2");
                            //tekstW = true;
                            //OnPropertyChanged("tekstW");
                            break;
                        case "3":
                        case "#":
                            Ozadje3 = Color.FromArgb(0xff, 0x27, 0x4e, 0x79);
                            OnPropertyChanged("Ozadje3");
                            //tekstE = true;
                            //OnPropertyChanged("tekstE");
                            break;
                        case "4":
                        case "$":
                            Ozadje4 = Color.FromArgb(0xff, 0x97, 0x76, 0x57);
                            OnPropertyChanged("Ozadje4");
                            //tekstR = true;
                            //OnPropertyChanged("tekstR");
                            break;
                        case "5":
                        case "%":
                            Ozadje5 = Color.FromArgb(0xff, 0x97, 0x76, 0x57);
                            OnPropertyChanged("Ozadje5");
                            //tekstT = true;
                            //OnPropertyChanged("tekstT");
                            break;
                        case "&":
                        case "6":
                            Ozadje6 = Color.FromArgb(0xff, 0x4d, 0x53, 0x13);
                            OnPropertyChanged("Ozadje6");
                            //tekstZ = true;
                            //OnPropertyChanged("tekstZ");
                            break;
                        case "7":
                        case "/":
                            Ozadje7 = Color.FromArgb(0xff, 0x4d, 0x53, 0x13);
                            OnPropertyChanged("Ozadje7");
                            //tekstU = true;
                            //OnPropertyChanged("tekstU");
                            break;
                        case "8":
                        case "(":
                            Ozadje8 = Color.FromArgb(0xff, 0x27, 0x4e, 0x79);
                            OnPropertyChanged("Ozadje8");
                            //tekstI = true;
                            //OnPropertyChanged("tekstI");
                            break;
                        case "9":
                        case ")":
                            Ozadje9 = Color.FromArgb(0xff, 0x11, 0x6e, 0xa9);
                            OnPropertyChanged("Ozadje9");
                            //tekstO = true;
                            //OnPropertyChanged("tekstO");
                            break;
                        case "0":
                        case "=":
                            Ozadje0 = Color.FromArgb(0xFF, 0x36, 0xaa, 0x9d);
                            OnPropertyChanged("Ozadje0");
                            //tekstP = true;
                            //OnPropertyChanged("tekstP");
                            break;
                        case "'":
                        case "?":
                            OzadjeAp = Color.FromArgb(0xFF, 0x36, 0xaa, 0x9d);
                            OnPropertyChanged("OzadjeAp");
                            //tekstSs = true;
                            //OnPropertyChanged("tekstSs");
                            break;
                        case "+":
                        case "*":
                            OzadjePlus = Color.FromArgb(0xFF, 0x36, 0xaa, 0x9d);
                            OnPropertyChanged("OzadjePlus");
                            //tekstDz = true;
                            //OnPropertyChanged("tekstDz");
                            break;
                    }
                }

                if (prva.Contains(a))
                {
                    P = true;
                    Pt = true;
                    OnPropertyChanged("P");
                    switch (a)
                    {
                        case "Q":
                        case "q":
                            OzadjeQ = Color.FromArgb(0xFF, 0x36, 0xaa, 0x9d);
                            OnPropertyChanged("OzadjeQ");
                            tekstQ = true;
                            OnPropertyChanged("tekstQ");
                            break;
                        case "W":
                        case "w":
                            Color.FromArgb(0xff, 0x11, 0x6e, 0xa9);
                            OnPropertyChanged("OzadjeW");
                            tekstW = true;
                            OnPropertyChanged("tekstW");
                            break;
                        case "E":
                        case "e":
                            OzadjeE = Color.FromArgb(0xff, 0x27, 0x4e, 0x79);
                            OnPropertyChanged("OzadjeE");
                            tekstE = true;
                            OnPropertyChanged("tekstE");
                            break;
                        case "R":
                        case "r":
                            OzadjeR = Color.FromArgb(0xff, 0x97, 0x76, 0x57);
                            OnPropertyChanged("OzadjeR");
                            tekstR = true;
                            OnPropertyChanged("tekstR");
                            break;
                        case "T":
                        case "t":
                            OzadjeT = Color.FromArgb(0xff, 0x97, 0x76, 0x57);
                            OnPropertyChanged("OzadjeT");
                            tekstT = true;
                            OnPropertyChanged("tekstT");
                            break;
                        case "Z":
                        case "z":
                            OzadjeZ = Color.FromArgb(0xff, 0x4d, 0x53, 0x13);
                            OnPropertyChanged("OzadjeZ");
                            tekstZ = true;
                            OnPropertyChanged("tekstZ");
                            break;
                        case "U":
                        case "u":
                            OzadjeU = Color.FromArgb(0xff, 0x4d, 0x53, 0x13);
                            OnPropertyChanged("OzadjeU");
                            tekstU = true;
                            OnPropertyChanged("tekstU");
                            break;
                        case "I":
                        case "i":
                            OzadjeI = Color.FromArgb(0xff, 0x27, 0x4e, 0x79);
                            OnPropertyChanged("OzadjeI");
                            tekstI = true;
                            OnPropertyChanged("tekstI");
                            break;
                        case "O":
                        case "o":
                            OzadjeO = Color.FromArgb(0xff, 0x11, 0x6e, 0xa9);
                            OnPropertyChanged("OzadjeO");
                            tekstO = true;
                            OnPropertyChanged("tekstO");
                            break;
                        case "P":
                        case "p":
                            OzadjeP = Color.FromArgb(0xFF, 0x36, 0xaa, 0x9d);
                            OnPropertyChanged("OzadjeP");
                            tekstP = true;
                            OnPropertyChanged("tekstP");
                            break;
                        case "Š":
                        case "š":
                            OzadjeSs = Color.FromArgb(0xFF, 0x36, 0xaa, 0x9d);
                            OnPropertyChanged("OzadjeSs");
                            tekstSs = true;
                            OnPropertyChanged("tekstSs");
                            break;
                        case "Đ":
                        case "đ":
                            OzadjeDz = Color.FromArgb(0xFF, 0x36, 0xaa, 0x9d);
                            OnPropertyChanged("OzadjeDz");
                            tekstDz = true;
                            OnPropertyChanged("tekstDz");
                            break;
                    }
                }
                if (druga.Contains(a))
                {
                    D = true;
                    Dt = true;
                    OnPropertyChanged("D");
                    switch (a)
                    {
                        case "A":
                        case "a":
                            OzadjeA = Color.FromArgb(0xFF, 0x36, 0xaa, 0x9d);
                            OnPropertyChanged("OzadjeA");
                            break;
                        case "S":
                        case "s":
                            OzadjeS = Color.FromArgb(0xff, 0x11, 0x6e, 0xa9);
                            OnPropertyChanged("OzadjeS");
                            break;
                        case "D":
                        case "d":
                            OzadjeD = Color.FromArgb(0xff, 0x27, 0x4e, 0x79);
                            OnPropertyChanged("OzadjeD");
                            break;
                        case "F":
                        case "f":
                            OzadjeF = Color.FromArgb(0xff, 0x97, 0x76, 0x57);
                            OnPropertyChanged("OzadjeF");
                            break;
                        case "G":
                        case "g":
                            OzadjeG = Color.FromArgb(0xff, 0x97, 0x76, 0x57);
                            OnPropertyChanged("OzadjeG");
                            crkaG = "G";
                            OnPropertyChanged("crkaG");
                            tekstG = true;
                            OnPropertyChanged("tekstG");
                            break;
                        case "H":
                        case "h":
                            OzadjeH = Color.FromArgb(0xff, 0x4d, 0x53, 0x13);
                            OnPropertyChanged("OzadjeH");
                            crkaH = "H";
                            OnPropertyChanged("crkaH");
                            tekstH = true;
                            OnPropertyChanged("tekstH");
                            break;
                        case "J":
                        case "j":
                            OzadjeJ = Color.FromArgb(0xff, 0x4d, 0x53, 0x13);
                            OnPropertyChanged("OzadjeJ");
                            break;
                        case "K":
                        case "k":
                            OzadjeK = Color.FromArgb(0xff, 0x27, 0x4e, 0x79);
                            OnPropertyChanged("OzadjeK");
                            break;
                        case "L":
                        case "l":
                            OzadjeL = Color.FromArgb(0xff, 0x11, 0x6e, 0xa9);
                            OnPropertyChanged("OzadjeL");
                            break;
                        case "Č":
                        case "č":
                            OzadjeCc = Color.FromArgb(0xFF, 0x36, 0xaa, 0x9d);
                            OnPropertyChanged("OzadjeCc");
                            break;
                        case "Ć":
                        case "ć":
                            OzadjeCcc = Color.FromArgb(0xFF, 0x36, 0xaa, 0x9d);
                            OnPropertyChanged("OzadjeCcc");
                            break;
                        case "Ž":
                        case "ž":
                            OzadjeZz = Color.FromArgb(0xFF, 0x36, 0xaa, 0x9d);
                            OnPropertyChanged("OzadjeZz");
                            break;
                    }
                }
                if (tretja.Contains(a))
                {
                    T = true;
                    Tt = true;
                    OnPropertyChanged("T");
                    switch (a)
                    {
                        case "Y":
                        case "y":
                            OzadjeY = Color.FromArgb(0xFF, 0x36, 0xaa, 0x9d);
                            OnPropertyChanged("OzadjeY");
                            tekstY = true;
                            OnPropertyChanged("tekstY");
                            break;
                        case "X":
                        case "x":
                            OzadjeX = Color.FromArgb(0xff, 0x11, 0x6e, 0xa9);
                            OnPropertyChanged("OzadjeX");
                            tekstX = true;
                            OnPropertyChanged("tekstX");
                            break;
                        case "C":
                        case "c":
                            OzadjeC = Color.FromArgb(0xff, 0x27, 0x4e, 0x79);
                            OnPropertyChanged("OzadjeC");
                            tekstC = true;
                            OnPropertyChanged("tekstC");
                            break;
                        case "V":
                        case "v":
                            OzadjeV = Color.FromArgb(0xff, 0x97, 0x76, 0x57);
                            OnPropertyChanged("OzadjeV");
                            tekstV = true;
                            OnPropertyChanged("tekstV");
                            break;
                        case "B":
                        case "b":
                            OzadjeB = Color.FromArgb(0xff, 0x97, 0x76, 0x57);
                            OnPropertyChanged("OzadjeB");
                            tekstB = true;
                            OnPropertyChanged("tekstB");
                            break;
                        case "N":
                        case "n":
                            OzadjeN = Color.FromArgb(0xff, 0x4d, 0x53, 0x13);
                            OnPropertyChanged("OzadjeN");
                            tekstN = true;
                            OnPropertyChanged("tekstN");
                            break;
                        case "M":
                        case "m":
                            OzadjeM = Color.FromArgb(0xff, 0x4d, 0x53, 0x13);
                            OnPropertyChanged("OzadjeM");
                            tekstM = true;
                            OnPropertyChanged("tekstM");
                            break;
                        case ",":
                            OzadjeVejica = Color.FromArgb(0xff, 0x27, 0x4e, 0x79);
                            OnPropertyChanged("OzadjeVejica");
                            tekstVejica = true;
                            OnPropertyChanged("tekstVejica");
                            break;
                        case ".":
                            OzadjePika = Color.FromArgb(0xff, 0x11, 0x6e, 0xa9);
                            OnPropertyChanged("OzadjePika");
                            tekstPika = true;
                            OnPropertyChanged("tekstPika");
                            break;
                        case "-":
                            OzadjeMinus = Color.FromArgb(0xFF, 0x36, 0xaa, 0x9d);
                            OnPropertyChanged("OzadjeMinus");
                            tekstMinus = true;
                            OnPropertyChanged("tekstMinus");
                            break;
                    }
                }
            }
            if (r.Count() > 10)
            {
                Pt = false;
                Tt = false;
            }
        }

        public bool P { get; set; }
        public bool D { get; set; }
        public bool T { get; set; }
        public bool Ni { get; set; }
        public bool Pt { get; set; }
        public bool Dt { get; set; }
        public bool Tt { get; set; }
        public bool tekstG { get; set; }
        public bool tekstH { get; set; }
        public bool tekstQ { get; set; }
        public bool tekstW { get; set; }
        public bool tekstE { get; set; }
        public bool tekstR { get; set; }
        public bool tekstT { get; set; }
        public bool tekstZ { get; set; }
        public bool tekstU { get; set; }
        public bool tekstI { get; set; }
        public bool tekstO { get; set; }
        public bool tekstP { get; set; }
        public bool tekstSs { get; set; }
        public bool tekstDz { get; set; }
        public bool tekstY { get; set; }
        public bool tekstX { get; set; }
        public bool tekstC { get; set; }
        public bool tekstV { get; set; }
        public bool tekstB { get; set; }
        public bool tekstN { get; set; }
        public bool tekstM { get; set; }
        public bool tekstVejica { get; set; }
        public bool tekstPika { get; set; }
        public bool tekstMinus { get; set; }
        public string crkaG { get; set; }
        public string crkaH { get; set; }
        public Color Ozadje1 { get; set; }
        public Color Ozadje2 { get; set; }
        public Color Ozadje3 { get; set; }
        public Color Ozadje4 { get; set; }
        public Color Ozadje5 { get; set; }
        public Color Ozadje6 { get; set; }
        public Color Ozadje7 { get; set; }
        public Color Ozadje8 { get; set; }
        public Color Ozadje9 { get; set; }
        public Color Ozadje0 { get; set; }
        public Color OzadjeAp { get; set; }
        public Color OzadjePlus { get; set; }
        public Color OzadjeCaps { get; set; }
        public Color OzadjeQ { get; set; }
        public Color OzadjeW { get; set; }
        public Color OzadjeE { get; set; }
        public Color OzadjeR { get; set; }
        public Color OzadjeT { get; set; }
        public Color OzadjeZ { get; set; }
        public Color OzadjeU { get; set; }
        public Color OzadjeI { get; set; }
        public Color OzadjeO { get; set; }
        public Color OzadjeP { get; set; }
        public Color OzadjeSs { get; set; }
        public Color OzadjeDz { get; set; }
        public Color OzadjeA { get; set; }
        public Color OzadjeS { get; set; }
        public Color OzadjeD { get; set; }
        public Color OzadjeF { get; set; }
        public Color OzadjeG { get; set; }
        public Color OzadjeH { get; set; }
        public Color OzadjeJ { get; set; }
        public Color OzadjeK { get; set; }
        public Color OzadjeL { get; set; }
        public Color OzadjeCc { get; set; }
        public Color OzadjeCcc { get; set; }
        public Color OzadjeZz { get; set; }
        public Color OzadjeY { get; set; }
        public Color OzadjeX { get; set; }
        public Color OzadjeC { get; set; }
        public Color OzadjeV { get; set; }
        public Color OzadjeB { get; set; }
        public Color OzadjeN { get; set; }
        public Color OzadjeM { get; set; }
        public Color OzadjeVejica { get; set; }
        public Color OzadjePika { get; set; }
        public Color OzadjeMinus { get; set; }

        public string Ena
        {
            get { return ena; }
            set
            {
                if (ena != value)
                {
                    ena = value;
                    OnPropertyChanged("Ena");
                }
            }
        }

        public string Dva
        {
            get { return dva; }
            set
            {
                if (dva != value)
                {
                    dva = value;
                    OnPropertyChanged("Dva");
                }
            }
        }

        public string Tri
        {
            get { return tri; }
            set
            {
                if (tri != value)
                {
                    tri = value;
                    OnPropertyChanged("Tri");
                }
            }
        }

        public string Štiri
        {
            get { return štiri; }
            set
            {
                if (štiri != value)
                {
                    štiri = value;
                    OnPropertyChanged("Štiri");
                }
            }
        }

        public string Pet
        {
            get { return pet; }
            set
            {
                if (pet != value)
                {
                    pet = value;
                    OnPropertyChanged("Pet");
                }
            }
        }

        public string Šest
        {
            get { return šest; }
            set
            {
                if (šest != value)
                {
                    šest = value;
                    OnPropertyChanged("Šest");
                }
            }
        }

        public string Sedem
        {
            get { return sedem; }
            set
            {
                if (sedem != value)
                {
                    sedem = value;
                    OnPropertyChanged("Sedem");
                }
            }
        }

        public string Osem
        {
            get { return osem; }
            set
            {
                if (osem != value)
                {
                    osem = value;
                    OnPropertyChanged("Osem");
                }
            }
        }

        public string Devet
        {
            get { return devet; }
            set
            {
                if (devet != value)
                {
                    devet = value;
                    OnPropertyChanged("Devet");
                }
            }
        }

        public string Nič
        {
            get { return nič; }
            set
            {
                if (nič != value)
                {
                    nič = value;
                    OnPropertyChanged("Nič");
                }
            }
        }

        public string Apostrof
        {
            get { return apostrof; }
            set
            {
                if (apostrof != value)
                {
                    apostrof = value;
                    OnPropertyChanged("Apostrof");
                }
            }
        }

        public string Plus
        {
            get { return plus; }
            set
            {
                if (plus != value)
                {
                    plus = value;
                    OnPropertyChanged("Plus");
                }
            }
        }

        public string Sklop
        {
            get { return sklop; }
            set
            {
                if (sklop != value)
                {
                    sklop = value;
                    OnPropertyChanged("Sklop");
                }
            }
        }

        public bool IsCapsLock
        {
            get { return _isCapsLock; }
            set
            {
                if (value != _isCapsLock)
                {
                    _isCapsLock = value;
                    OnPropertyChanged("IsCapsLock");
                }
            }
        }

        public bool JeNarobe
        {
            get { return _jeNarobe; }
            set
            {
                if (value != _jeNarobe)
                {
                    _jeNarobe = value;
                    OnPropertyChanged("JeNarobe");
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler propertyChanged = PropertyChanged;
            if (propertyChanged != null)
                propertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
