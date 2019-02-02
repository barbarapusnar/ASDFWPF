using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASDFWPF
{
    public class ZaPagePayload
    {
        public int št { get; set; }
        public string n { get; set; }
        public int štČrkSkupaj { get; set; }
        public int napakeSkupaj { get; set; }
        public int številoUdarcevSkupaj { get; set; }
        public int časSkupaj { get; set; }
        public int vsehVajSkupaj { get; set; }
        public int[] številkeVajZaDan { get; set; }
        public int trenutnaPozicijaVaj { get; set; }
        public string opisS { get; set; }
        public string zaporedneŠtevilke { get; set; }

    }
    public class ZaPagePayload1
    {
        public string title { get; set; }
        public string n { get; set; }
    }
    public class ZaPagePayload2
    {
        public int št { get; set; }
        public string n { get; set; }
        public int štČrkSkupaj { get; set; }
        public int napakeSkupaj { get; set; }
        public int številoUdarcevSkupaj { get; set; }
        public int časSkupaj { get; set; }
        public int vsehVajSkupaj { get; set; }
        public int[] številkeVajZaDan { get; set; }
        public int trenutnaPozicijaVaj { get; set; }
        public string opisS { get; set; }
        public string imeD { get; set; }
        public string zaporedneŠtevilke { get; set; }

    }
}
