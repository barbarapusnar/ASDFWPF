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
        string[] r;
        bool p = false;

        public bool P
        {
            get { return p; }
            set { p = value; }
        }
        bool d = false;

        public bool D
        {
            get { return d; }
            set { d = value; }
        }
        bool t = false;

        public bool T
        {
            get { return t; }
            set { t = value; }
        }
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
        public TipkovnicaViewModel(int i)
        {
            r = PrivzetiViewModel.GetCrke(i);
            string[] prva = { "Q", "W", "E", "R", "T", "Z", "U", "I", "O", "P","Š", "q", "w", "e", "r", "t", "z", "u", "i", "o", "p","š" };
            string[] druga = { "A", "S", "D", "F", "G", "H", "J", "K", "L", "Č", "a", "s", "d", "f", "g", "h", "j", "k", "l", "č" };
            string[] tretja = { "Y", "X", "C", "V", "B", "N", "M", "y", "x", "c", "v", "b", "n", "m",",",".","-" };
            foreach (string a in r)
            {

                if (prva.Contains(a))
                {
                    p = true;
                    OnPropertyChanged("P");
                    switch (a)
                    { 
                        case "Q":
                        case "q":
//                             OzadjeQ = Color.FromArgb(0xFF, 0x71, 0x6F, 0x64);
                             OzadjeQ = Colors.LightBlue;
                             OnPropertyChanged("OzadjeQ");
                             tekstQ = true;
                             OnPropertyChanged("tekstQ");
                             break;
                        case "W":
                        case "w":
                             OzadjeW = Colors.LightPink;
                             OnPropertyChanged("OzadjeW");
                             tekstW = true;
                             OnPropertyChanged("tekstW");
                             break;
                        case "E":
                        case "e":
                             OzadjeE = Colors.LightGreen;
                             OnPropertyChanged("OzadjeE");
                             tekstE = true;
                            OnPropertyChanged("tekstE");
                             break;
                        case "R":
                        case "r":
                             OzadjeR = Colors.LightGray;
                             OnPropertyChanged("OzadjeR");
                             tekstR = true;
                            OnPropertyChanged("tekstR");
                             break;
                        case "T":
                        case "t":
                             OzadjeT = Colors.LightGray;
                             OnPropertyChanged("OzadjeT");
                             tekstT = true;
                            OnPropertyChanged("tekstT");
                             break;
                        case "Z":
                        case "z":
                             OzadjeZ = Colors.LightSeaGreen;
                             OnPropertyChanged("OzadjeZ");
                             tekstZ = true;
                            OnPropertyChanged("tekstZ");
                             break;
                        case "U":
                        case "u":
                             OzadjeU = Colors.LightSeaGreen;
                             OnPropertyChanged("OzadjeU");
                             tekstU = true;
                            OnPropertyChanged("tekstU");
                             break;
                        case "I":
                        case "i":
                             OzadjeI = Colors.LightGreen;
                             OnPropertyChanged("OzadjeI");
                             tekstI = true;
                            OnPropertyChanged("tekstI");
                             break;
                        case "O":
                        case "o":
                             OzadjeO = Colors.LightPink;
                             OnPropertyChanged("OzadjeO");
                             tekstO = true;
                            OnPropertyChanged("tekstO");
                             break;
                        case "P":
                        case "p":
                             OzadjeP = Colors.LightBlue;
                             OnPropertyChanged("OzadjeP");
                             tekstP = true;
                            OnPropertyChanged("tekstP");
                             break;
                        case "Š":
                        case "š":
                             OzadjeSs = Colors.LightBlue;
                             OnPropertyChanged("OzadjeSs");
                             tekstSs = true;
                            OnPropertyChanged("tekstSs");
                             break;
                        case "Đ":
                        case "đ":
                             OzadjeDz = Colors.LightBlue;
                             OnPropertyChanged("OzadjeDz");
                             tekstDz = true;
                             OnPropertyChanged("tekstDz");
                             break;
                    }
                   
                   
                }
                if (druga.Contains(a))
                {
                    d = true;
                    OnPropertyChanged("D");
                    switch (a)
                    {
                        case "A":
                        case "a":
                            OzadjeA = Colors.LightBlue;
                            OnPropertyChanged("OzadjeA");
                            break;
                        case "S":
                        case "s":
                            OzadjeS = Colors.LightPink;
                            OnPropertyChanged("OzadjeS");
                            break;
                        case "D":
                        case "d":
                            OzadjeD = Colors.LightGreen;
                            OnPropertyChanged("OzadjeD");
                            break;
                        case "F":
                        case "f":
                            OzadjeF = Colors.LightGray;
                            OnPropertyChanged("OzadjeF");
                            break;
                        case "G":
                        case "g":
                            OzadjeG = Colors.LightGray;
                            OnPropertyChanged("OzadjeG");
                            crkaG = "G";
                            OnPropertyChanged("crkaG");
                            tekstG = true;
                            OnPropertyChanged("tekstG");
                            break;
                        case "H":
                        case "h":
                            OzadjeH = Colors.LightSeaGreen;
                            OnPropertyChanged("OzadjeH");
                            crkaH = "H";
                            OnPropertyChanged("crkaH");
                            tekstH = true;
                            OnPropertyChanged("tekstH");
                            break;
                        case "J":
                        case "j":
                            OzadjeJ = Colors.LightSeaGreen;
                            OnPropertyChanged("OzadjeJ");
                            break;
                        case "K":
                        case "k":
                            OzadjeK = Colors.LightGreen;
                            OnPropertyChanged("OzadjeK");
                            break;
                        case "L":
                        case "l":
                            OzadjeL = Colors.LightPink;
                            OnPropertyChanged("OzadjeL");
                            break;
                        case "Č":
                        case "č":
                            OzadjeCc = Colors.LightBlue;
                            OnPropertyChanged("OzadjeCc");
                            break;
                      
                    }
                }
                if (tretja.Contains(a))
                {
                    t = true;
                    OnPropertyChanged("T");
                    switch (a)
                    {
                        case "Y":
                        case "y":
                            OzadjeY = Colors.LightBlue;
                            OnPropertyChanged("OzadjeY");
                            tekstY = true;
                            OnPropertyChanged("tekstY");
                            break;
                        case "X":
                        case "x":
                            OzadjeX = Colors.LightPink;
                            OnPropertyChanged("OzadjeX");
                            tekstX = true;
                            OnPropertyChanged("tekstX");
                            break;
                        case "C":
                        case "c":
                            OzadjeC = Colors.LightGreen;
                            OnPropertyChanged("OzadjeC");
                              tekstC = true;
                             OnPropertyChanged("tekstC");
                            break;
                        case "V":
                        case "v":
                            OzadjeV = Colors.LightGray;
                            OnPropertyChanged("OzadjeV");
                              tekstV = true;
                             OnPropertyChanged("tekstV");
                            break;
                        case "B":
                        case "b":
                            OzadjeB = Colors.LightGray;
                            OnPropertyChanged("OzadjeB");
                              tekstB = true;
                             OnPropertyChanged("tekstB");
                            break;
                        case "N":
                        case "n":
                            OzadjeN = Colors.LightSeaGreen;
                            OnPropertyChanged("OzadjeN");
                              tekstN = true;
                             OnPropertyChanged("tekstN");
                            break;
                        case "M":
                        case "m":
                            OzadjeM = Colors.LightSeaGreen;
                            OnPropertyChanged("OzadjeM");
                              tekstM = true;
                             OnPropertyChanged("tekstM");
                            break;
                        case ",":
                            OzadjeVejica = Colors.LightGreen;
                            OnPropertyChanged("OzadjeVejica");
                            tekstVejica = true;
                            OnPropertyChanged("tekstVejica");
                            break;
                        case ".":
                            OzadjePika = Colors.LightPink;
                            OnPropertyChanged("OzadjePika");
                            tekstPika = true;
                            OnPropertyChanged("tekstPika");
                            break;
                        case "-":
                            OzadjeMinus = Colors.LightBlue;
                            OnPropertyChanged("OzadjeMinus");
                            tekstMinus = true;
                            OnPropertyChanged("tekstMinus");
                            break;
                    }
                }
                //Ozadje = Color.FromArgb(0xFF, 0xFF, 0xFF, 0xFF);
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
