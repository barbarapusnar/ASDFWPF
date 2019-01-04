using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using System.Windows.Media.Imaging;

namespace ASDFWPF.Model
{
    class Imena
    {
        public string Ime { get; set; }
        public BitmapImage Slika { get; set; }
    }
    class TekstViewModel
    {
       private static TekstViewModel tvm = new TekstViewModel();
        private ObservableCollection<Vaje> _vajeT = new ObservableCollection<Vaje>();
        public ObservableCollection<Vaje> VajaT
        {
            get { return this._vajeT; }

        }
        private ObservableCollection<TipkanjeDataGroup> _allGroupsT = new ObservableCollection<TipkanjeDataGroup>();
        public ObservableCollection<TipkanjeDataGroup> AllGroupsT
        {
            get { return this._allGroupsT; }

        }
        public static IEnumerable<Vaje> GetIzbraneVaje()
        {
            //tukaj je null rezultat
            IEnumerable<Vaje> matches = null;
            matches = tvm.VajaT.Select(a=>a);
            return matches;
        }
        public static IEnumerable<Vsebina> GetVsebina(int i)
        {
            var matches = tvm.VajaT.Where(a => a.Id == i).SelectMany(b => b.vsebina);
            return matches;
        }
        public static string GetSkupinaVaje(int i)
        {
            var matches = tvm.VajaT.Where(a => a.Id == i).Select(b => b.Group.Id).FirstOrDefault();
            return matches;
        }
        public static void NaložiVajeTekst(string imeD)
        {
            //    naloži vaje
            FileInfo file = new FileInfo(imeD);
            var result = File.ReadAllText(imeD);

            List<Class1> TotalList = new List<Class1>();
            //var task = Task.Factory.StartNew(() => JsonConvert.DeserializeObject<List<Class1>>(result));
            //TotalList = await task;
            TotalList = JsonConvert.DeserializeObject<List<Class1>>(result);
            tvm._vajeT = new ObservableCollection<Vaje>();
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
                r.slika = new BitmapImage(new Uri(d.slika, UriKind.Relative)); //iz stringa v sliko
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
                group = tvm.AllGroupsT.FirstOrDefault(s => s.Id.Equals(d.group.key));
                if (group == null)
                    group = CreateTipkanjeGroup(skupina);
                r.Group = group;
                if (group != null)
                    group.Items.Add(r);
                tvm.VajaT.Add(r);
            }
        }

        private static TipkanjeDataGroup CreateTipkanjeGroup(Group skupina)
        {
            TipkanjeDataGroup group = new TipkanjeDataGroup();

            group.Id = skupina.key;
            group.Title = skupina.title;
            group.ShortTitle = skupina.shortTitle;
            group.Description = skupina.description;
            group.Image = new BitmapImage(new Uri(skupina.backgroundImage, UriKind.Relative));
            group.GroupImage = new BitmapImage(new Uri(skupina.groupImage, UriKind.Relative));
            tvm.AllGroupsT.Add(group);
            return group;
        }
    }
    } 

