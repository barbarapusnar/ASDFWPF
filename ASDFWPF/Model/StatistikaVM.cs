using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ASDFWPF
{
    internal class StatistikaVM
    {
        private static readonly StatistikaVM _pvm = new StatistikaVM();
        private ObservableCollection<SkupineRezultatov> _allGroups = new ObservableCollection<SkupineRezultatov>();

        private ObservableCollection<SkupineRezultatovDatum> _allGroupsD =
            new ObservableCollection<SkupineRezultatovDatum>();

        private ObservableCollection<RezultatiZaVajo> _vaje = new ObservableCollection<RezultatiZaVajo>();

        public ObservableCollection<RezultatiZaVajo> VajaR
        {
            get { return _vaje; }
            set { _vaje = value; }
        }

        public ObservableCollection<SkupineRezultatov> AllGroups
        {
            get { return _allGroups; }
            set { _allGroups = value; }
        }

        public ObservableCollection<SkupineRezultatovDatum> AllGroupsD
        {
            get { return _allGroupsD; }
            set { _allGroupsD = value; }
        }

        public static IEnumerable<RezultatiZaVajo> GetItems()
        {
            // Simple linear search is acceptable for small data sets
            return _pvm.VajaR;
        }

        public static IEnumerable<RezultatiZaVajo> GetItemsPoDatumu(string s, string n)
        {
            var x = (from a in _pvm.AllGroupsD
                where a.Title == s && a.NačinDela == n
                select a).FirstOrDefault();
            //var y = from b in x.Items
            //        select b;
            return x.Items;
        }

        public static RezultatiZaVajo GetItem(int i)
        {
            // Simple linear search is acceptable for small data sets
            return _pvm.VajaR.FirstOrDefault(a => a.Id == i);
        }

        public static void NaložiRezultateAsync()
        {
            _pvm.AllGroupsD = new ObservableCollection<SkupineRezultatovDatum>();
            _pvm.AllGroups = new ObservableCollection<SkupineRezultatov>();
            _pvm.VajaR = new ObservableCollection<RezultatiZaVajo>();
            var lokalniR = PrivzetiViewModel.GetVsiRezultati();
            var načini = lokalniR.Where(e => e.ImeRac == PrivzetiViewModel.Uporabnik).Select(e => e.način).Distinct();
            foreach (var a in načini)
            {
                var b = new SkupineRezultatov();
                b.Title = a;
                _pvm.AllGroups.Add(b);
            }

            //dodani skupine in če je prosto datumi
            var dat =
                lokalniR.Where(e => e.ImeRac == PrivzetiViewModel.Uporabnik)
                    .Select(e => new {Datum = e.zadnjicReseno.Value.Date, S = e.skupina.OpisSkupine, e.način})
                    .Distinct();
            foreach (var a in dat)
            {
                var b = new SkupineRezultatovDatum();
                if (a.S != "prosto")
                {
                    b.Title = a.S;
                    b.NačinDela = a.način;
                }
                else
                {
                    var d = a.Datum;
                    var d1 = string.Format("{0:dd/MMM/yy}", d.Date);
                    b.Title = d1;
                    b.NačinDela = a.način;
                }
                _pvm.AllGroupsD.Add(b);
            }
            foreach (var item in lokalniR)
            {
                var r = new RezultatiZaVajo();
                r.Cas = item.porabljencas;
                r.Id = item.idVaje;
                r.ImeRac = item.ImeRac;
                r.NacinDela = item.način;
                r.Napake = item.napake;
                r.Skupina = item.skupina;
                r.StCrk = item.stCrk;
                r.Udarci = item.udarci;
                r.Procent = (decimal) r.Napake/r.StCrk;
                if (item.zadnjicReseno != null) r.ZadnjičRešeno = (DateTime) item.zadnjicReseno;
                if (r.ImeRac == PrivzetiViewModel.Uporabnik)
                {
                    _pvm.VajaR.Add(r);
                    if (r.Skupina.OpisSkupine == "prosto")
                    {
                        //dodaj v datum
                        var d = r.ZadnjičRešeno;
                        var d1 = string.Format("{0:dd/MMM/yy}", d.Date);
                        var izbrana = _pvm.AllGroupsD.FirstOrDefault(e => e.Title == d1);
                        izbrana.Items.Add(r);
                    }
                    else
                    {
                        //dodaj v skupino
                        var izbrana =
                            _pvm.AllGroupsD.FirstOrDefault(
                                e => e.Title == r.Skupina.OpisSkupine && e.NačinDela == r.NacinDela);
                        izbrana.Items.Add(r);
                    }
                    //dodaj v skupino za način dela
                    var izbrana1 = _pvm.AllGroups.FirstOrDefault(e => e.Title == r.NacinDela);
                    izbrana1.Items.Add(r);
                }
            }
            //napolnjene vse vaje
            foreach (var a in _pvm.AllGroupsD)
            {
                var izbrana1 = _pvm.AllGroups.FirstOrDefault(e => e.Title == a.NačinDela);
                izbrana1.ItemsD.Add(a);
            }
            // IzdelajPoDatumih();
            IzračunajPovprečja();
        }

        private static void IzračunajPovprečja()
        {
            foreach (var x in _pvm._allGroupsD)
            {
                if (x.Items.Count != 0)
                {
                    x.Napake = x.Items.Select(e => e.Napake).Sum();
                    x.Cas = x.Items.Select(e => e.Cas).Sum();

                    x.StCrk = x.Items.Select(e => e.StCrk).Sum();
                    x.Procent = x.Napake/(decimal) x.StCrk;
                    x.Udarci = x.Items.Select(e => e.Udarci).Sum();
                    x.Hitrost = (x.Udarci - x.Napake*25)/(double) (x.Cas/60);

                    //lahko še kaj
                    if (x.Procent <= 0.002m)
                        x.OcenaP = 5;
                    else if (x.Procent <= 0.004m)
                        x.OcenaP = 4;
                    else if (x.Procent <= 0.007m)
                        x.OcenaP = 3;
                    else if (x.Procent <= 0.0099m)
                        x.OcenaP = 2;
                    else
                        x.OcenaP = 1;
                    if (x.Hitrost >= 160)
                        x.OcenaH = 5;
                    else if (x.Hitrost >= 143)
                        x.OcenaH = 4;
                    else if (x.Hitrost >= 126)
                        x.OcenaH = 3;
                    else if (x.Hitrost >= 110)
                        x.OcenaH = 2;
                    else
                        x.OcenaH = 1;
                }
            }
            foreach (var sd in _pvm._allGroupsD)
            {
                if (sd.Items.Count != 0)
                {
                    var sd1 = sd.Items.OrderBy(e => e.Id);
                    sd.Od = sd1.FirstOrDefault().Id;
                    sd.Do = sd1.LastOrDefault().Id;
                    sd.Cas = sd.Cas/60;
                }
            }
        }

        // še ni - ali bo sploh treba iz strežnika pobirati rezultate - so samo za prof, v primeru nesreče,
        // uporabnik jih na strežniku ne more gledati, so pa isti, kot so lokalno
        public static async Task<bool> NaložiRezultateRemoteAsync()
        {
            _pvm.AllGroupsD = new ObservableCollection<SkupineRezultatovDatum>();
            _pvm.AllGroups = new ObservableCollection<SkupineRezultatov>();
            _pvm.VajaR = new ObservableCollection<RezultatiZaVajo>();

            var client = new HttpClient();
            client.MaxResponseContentBufferSize = 1024*1024; // Read up to 1 MB of data
            try
            {
                var response = await client.GetAsync(new Uri("http://gimnazija.scng.si/strojepisje/api/rezultati"));
                response.EnsureSuccessStatusCode();

                var result = await response.Content.ReadAsStringAsync();
            }
            // Parse the JSON recipe data
            //if (result != "")
            //{
            //    var rezultati = JsonArray.Parse(result);

            //    foreach (var item in rezultati)
            //    {
            //        var obj = item.GetObject();
            //        var r = new RezultatiZaVajo();
            //        foreach (var key in obj.Keys)
            //        {
            //            IJsonValue val;
            //            if (!obj.TryGetValue(key, out val))
            //                continue;

            //            switch (key)
            //            {
            //                case "idVaje":
            //                    r.Id = (int) val.GetNumber();
            //                    break;
            //                case "napake":
            //                    r.Napake = (int) val.GetNumber();
            //                    break;
            //                case "porabljencas":
            //                    r.Cas = (decimal) val.GetNumber();
            //                    break;
            //                case "zadnjicReseno":
            //                    var recipeGroup = val.GetString();
            //                    r.ZadnjičRešeno = DateTime.Parse(recipeGroup);
            //                    break;
            //                case "udarci":
            //                    r.Udarci = (int) val.GetNumber();
            //                    break;
            //                case "stCrk":
            //                    r.StCrk = (int) val.GetNumber();
            //                    break;
            //                case "način":
            //                    r.NacinDela = val.GetString();
            //                    break;
            //                case "ImeRac":
            //                    //string skupaj = val.GetString();
            //                    //string[] posebej = skupaj.Split(';');
            //                    //try
            //                    //{
            //                    //    r.ImeRac = posebej[1]; //shranimo samo ime uporabnika za prikaz rezultatov
            //                    //}
            //                    //catch
            //                    //{
            //                    //    r.ImeRac = posebej[0];
            //                    //}
            //                    r.ImeRac = val.GetString();
            //                    break;
            //                case "skupina":
            //                    var vse = val.GetObject();
            //                    var s = new Skupina();
            //                    foreach (var k in vse.Keys)
            //                    {
            //                        IJsonValue val1;
            //                        if (!vse.TryGetValue(k, out val1))
            //                            continue;
            //                        switch (k)
            //                        {
            //                            case "OpisSkupine":
            //                                s.OpisSkupine = val1.GetString();
            //                                break;
            //                        }
            //                    }
            //                    r.Skupina = s;
            //                    break;
            //            }
            //        }
            //    if (r.StCrk != 0)
            //        r.Procent = (decimal) r.Napake/r.StCrk;
            //    else
            //        r.Procent = 0;
            //    //if (r.ImeRac==PrivzetiViewModel.Uporabnik)
            //    _pvm.VajaR.Add(r);
            //}
            //napolnjene vse vaje
            // IzdelajPoDatumih();
            //    }
            //    return true;
            //}
            catch (HttpRequestException)
            {
                return false;
            }
            return true;
        }

        private static SkupineRezultatovDatum CreateTipkanjeGroupD(string obj)
        {
            var sr = new SkupineRezultatovDatum();
            sr.Title = obj;
            sr.Cas = 0;
            sr.Procent = 0;
            sr.Napake = 0; //....
            sr.Udarci = 0;
            _pvm.AllGroupsD.Add(sr);

            return sr;
        }

        public static IEnumerable<SkupineRezultatov> GetGroups(string ime)
        {
            if (!ime.Equals("AllGroups"))
                throw new ArgumentException("Only 'AllGroups' is supported as a collection of groups");
            var x = GetGroupsD("AllGroups");
            return _pvm.AllGroups;
        }

        public static IEnumerable<SkupineRezultatovDatum> GetGroupsD(string ime)
        {
            if (!ime.Equals("AllGroups"))
                throw new ArgumentException("Only 'AllGroups' is supported as a collection of groups");

            return _pvm.AllGroupsD;
        }
    }
}