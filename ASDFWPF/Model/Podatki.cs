using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASDFWPF
{

    public class VseVaje
    {
        public List<Class1> Vaja { get; set; }
    }

    public class Class1
    {
        public int Id { get; set; }
        public Vsebina1[] vsebina { get; set; }
        public Group group { get; set; }
        public string zadnjicReseno { get; set; }
        public bool reseno { get; set; }
        public int napake { get; set; }
        public int porabljencas { get; set; }
        public string slika { get; set; }
        public bool test { get; set; }
        public string[] crke { get; set; }
    }

    public class Group
    {
        public string backgroundImage { get; set; }
        public string description { get; set; }
        public string groupImage { get; set; }
        public string key { get; set; }
        public string rank { get; set; }
        public int recipesCount { get; set; }
        public string shortTitle { get; set; }
        public string title { get; set; }
    }

    public class Vsebina1
    {
        public int vrstica { get; set; }
        public string tekst { get; set; }
    }

}
