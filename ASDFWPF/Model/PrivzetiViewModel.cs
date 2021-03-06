using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

using System.Runtime.Serialization.Json;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Net.Http;

namespace ASDFWPF
{
   
    public enum NačinDela
    {
        Ignoriraj, Ponovno, Briši, Uredi, LahekTest, Test, Neodvisno
    }
    class PrivzetiViewModel 
    {
        private static PrivzetiViewModel _pvm = new PrivzetiViewModel();

        private ObservableCollection<Vaje> _vaje = new ObservableCollection<Vaje>();
        private static string uporabnik;
        public static string Uporabnik
        {
            get { return uporabnik; }
            set { uporabnik = value; }
        }
        private static ImageSource uporabnikSlika;
        public static ImageSource UporabnikSlika
        {
            get { return uporabnikSlika; }
            set { uporabnikSlika = value; }
        }
        public ObservableCollection<Vaje> Vaja
        {
            get { return this._vaje; }
          
        }
        private ObservableCollection<Rezultati> _rezultat=new ObservableCollection<Rezultati>();
        public  ObservableCollection<Rezultati> Rezultat
        {
            get { return _rezultat; }
        }
        
        public static IEnumerable<Vaje> GetItems()
        {
            // Simple linear search is acceptable for small data sets
            return _pvm.Vaja;
            
        }
        public static Vaje GetItem(int i)
        {
            // Simple linear search is acceptable for small data sets
            return _pvm.Vaja.Where(a=>a.Id==i).FirstOrDefault();

        }
        public static Rezultati GetItemR(int i)
        {
            // Simple linear search is acceptable for small data sets
            return _pvm.Rezultat.Where(a => a.idVaje == i).FirstOrDefault();
        }
        public static void SetItemR(int i, int n, decimal pc,int h)
        {
            Rezultati item = new Rezultati();
            item.idVaje = i;
            item.napake = n;
            item.porabljencas = pc;
            item.zadnjicReseno = DateTime.Now;
            item.udarci = h;
            Rezultati r1 = _pvm.Rezultat.Where(a => a.idVaje == i).FirstOrDefault();
            if (r1 != null)
                _pvm.Rezultat.Remove(r1);
            _pvm.Rezultat.Add(item);
        }
        public static IEnumerable<Rezultati> GetVsiRezultati()
        {
            return _pvm.Rezultat;
        }
        public static int GetNapake(int i)
        {
            var x = _pvm.Rezultat.Where(a => a.idVaje == i).Select(b => b.napake).FirstOrDefault();
            return (int)x;
        }
        public static int GetUdarcevNaMinuto(int i)
        {
            var x = _pvm.Rezultat.Where(a => a.idVaje == i).Select(b => b.udarci).FirstOrDefault();
            return x;
            
        }
        
        public static IEnumerable<Vsebina> GetVsebina(int i)
        {
            var matches = _pvm.Vaja.Where(a=>a.Id==i).SelectMany(b=>b.vsebina);            
            return matches;
        }
        public static string[] GetCrke(int i)
        {
            var x = _pvm.Vaja.Where(a => a.Id == i).SelectMany(b => b.crke).ToList();

            return x.ToArray<string>();
        }
        private ObservableCollection<TipkanjeDataGroup> _allGroups = new ObservableCollection<TipkanjeDataGroup>();
        public ObservableCollection<TipkanjeDataGroup> AllGroups
        {
            get { return this._allGroups; }
         
        }

        public static IEnumerable<TipkanjeDataGroup> GetGroups(string Id)
        {
            if (!Id.Equals("AllGroups")) throw new ArgumentException("Only 'AllGroups' is supported as a collection of groups");

            return _pvm.AllGroups;
        }

        public static TipkanjeDataGroup GetGroup(string Id)
        {
            var matches = _pvm.AllGroups.Where((group) => group.Id.Equals(Id));
            if (matches.Count() == 1) return matches.First();
            return null;
        }
        public static async Task PišiRezultate(int idVaje)
        {
            Rezultati a = GetItemR(idVaje);
            var x = _pvm.Rezultat.OrderBy(z=>z.idVaje);
            string jsonContents = JsonConvert.SerializeObject(x,Formatting.Indented);
            string imeDatoteke=
                 Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)+"\\rešitve"+Uporabnik+".json";

            StreamWriter sw = new StreamWriter(imeDatoteke);
            await sw.WriteAsync(jsonContents);
            sw.Close();    
        }
        
        public static async Task NaložiRezultate()
        {
           //    naloži vaje
              FileInfo file = new FileInfo("vaje.json");
              var result =  File.ReadAllText("vaje.json");

            List<Class1> TotalList = new List<Class1>();
            var task = Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<Class1>>(result));
            TotalList = await task;
            //TotalList = JsonConvert.DeserializeObject<List<Class1>>(result);         
            foreach (var d in TotalList)
            {
                Vaje r = new Vaje();
                TipkanjeDataGroup group = null;
                r.vsebina = new ObservableCollection<Vsebina>();
                r.Id = d.Id;
                foreach (var a in d.vsebina)
                {
                    Vsebina v = new Vsebina();
                    v.vrstica = a.vrstica;
                    v.tekst = a.tekst;
                    r.vsebina.Add(v);
                }
                try
                {
                    r.zadnjicReseno = DateTime.Parse(d.zadnjicReseno);
                }
                catch { r.zadnjicReseno = null; }
                r.reseno = d.reseno;
                r.napake = d.napake;
                r.porabljencas = d.porabljencas;
                r.slika = new BitmapImage(new Uri(d.slika,UriKind.Relative)); //iz stringa v sliko
                r.test = d.test;
                var list1 = d.crke;
                r.crke = new string[list1.Count()];
                int št = 0;
                foreach (var a in list1)
                {
                    r.crke[št] = a;
                    št++;
                }
                var skupina = d.group;
                group = _pvm.AllGroups.FirstOrDefault(s => s.Id.Equals(d.group.key));
                if (group== null)
                    group = CreateTipkanjeGroup(skupina);
                r.Group = group;       
                if (group != null)
                    group.Items.Add(r);
                _pvm.Vaja.Add(r);
            }
        }
        private static TipkanjeDataGroup CreateTipkanjeGroup1(Group skupina, ObservableCollection<TipkanjeDataGroup> grupe)
        {
            TipkanjeDataGroup group = new TipkanjeDataGroup();

            group.Id = skupina.key;
            group.Title = skupina.title;
            group.ShortTitle = skupina.shortTitle;
            group.Description = skupina.description;
            group.Image = new BitmapImage(new Uri(skupina.backgroundImage, UriKind.Relative));
            group.GroupImage = new BitmapImage(new Uri(skupina.groupImage, UriKind.Relative));
            grupe.Add(group);
            return group;
        }
        private static TipkanjeDataGroup CreateTipkanjeGroup(Group skupina)
        {
            TipkanjeDataGroup group = new TipkanjeDataGroup();

            group.Id = skupina.key;
            group.Title = skupina.title;
            group.ShortTitle = skupina.shortTitle;
            group.Description = skupina.description;
            group.Image= new BitmapImage(new Uri(skupina.backgroundImage, UriKind.Relative));
            group.GroupImage=new BitmapImage(new Uri(skupina.groupImage, UriKind.Relative));
           _pvm.AllGroups.Add(group);
            return group;
        }

        public static async void NaložiStareRezultateAsync()
        {
            string folder =
                   Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) ;
            FileInfo file = new FileInfo(folder+"\\rešitve"+Uporabnik+".json");
            if (!file.Exists)
                return;
            var result = File.ReadAllText(folder + "\\rešitve" + Uporabnik + ".json");

            List<Rezultati> TotalList = new List<Rezultati>();
            var task = Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<Rezultati>>(result));
            TotalList = await task;
            _pvm._rezultat = new ObservableCollection<Rezultati>();
            foreach (Rezultati x in TotalList)
            {
                _pvm.Rezultat.Add(x);
            }

        }

        public static Rezultati GetItemRUp(int i, string p)
        {
            // Simple linear search is acceptable for small data sets
             return _pvm.Rezultat.Where(a => a.idVaje == i).FirstOrDefault();
            //return _pvm.Rezultat.FirstOrDefault(a => a.idVaje == i && a.ImeRac == p); ta je prava
        }
        public static IEnumerable<Rezultati> GetVsiRezultatiUp(string p)
        {
            return _pvm.Rezultat.Where(e => e.ImeRac == p);
        }
        public static string GetSkupinaVaje(int i)
        {
            var matches = _pvm.Vaja.Where(a => a.Id == i).Select(b => b.Group.Id).FirstOrDefault();
            return matches;
        }
        public static Rezultati SetItemR(int i, int n, decimal pc, int h, int v, string na, string ime, string opis)
        {
            var item = new Rezultati
            {
                napake = n,
                porabljencas = pc,
                zadnjicReseno = DateTime.Now,
                udarci = h,
                idVaje = i,
                stCrk = v,
                način = na,
                ImeRac = ime
            };
            //to bo treba popraviti, ker se ne ujema prav , sedaj je divaje in id
            // item.Id = i;
            //če dela prosto, naj bo skupina prosto
            var del = na.Split(' ');
            if (del[1] == "prof")
            {
                item.skupina = new Skupina();
                item.skupina.OpisSkupine = opis;
            }
            else
            {
                item.skupina = new Skupina();
                item.skupina.OpisSkupine = "prosto";

            }
            var r1 = _pvm.Rezultat.FirstOrDefault(a => a.idVaje == i && a.način == na && a.ImeRac == item.ImeRac);
            if (r1 != null)
                _pvm.Rezultat.Remove(r1);
            _pvm.Rezultat.Add(item);
            return item;
        }
        public static void PišiRezultate()
        {
            var x = _pvm.Rezultat.OrderBy(z => z.idVaje).ThenByDescending(z => z.zadnjicReseno);
            var jsonContents = JsonConvert.SerializeObject(x, Formatting.Indented);
            string folder =
                 Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) ;
            FileInfo fi = new FileInfo(folder+"\\rešitve"+Uporabnik+".json");
            if (fi.Exists)
                fi.Delete();
            using (var textStream =  fi.OpenWrite())
            {
                using (var textWriter = new StreamWriter(textStream))
                {
                  textWriter.Write(jsonContents);
                }
            }
        }
        public static void Briši(Rezultati s)
        {
            _pvm.Rezultat.Remove(s);
        }
        public static IEnumerable<Vaje> GetVajeZaDanPoŠtevilki(int i,int st)
        {
            //tukaj je null rezultat
            IEnumerable<Vaje> matches=null;
            matches = _pvm.Vaja.Where(a => a.Id>=i &&a.Id<=st);
            return matches;
        }
    }
}
