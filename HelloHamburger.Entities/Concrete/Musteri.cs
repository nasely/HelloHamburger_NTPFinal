using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloHamburger.Entities.Concrete
{
    public class Musteri
    {
        public string Ad { get; set; }

        public List<string> Diyaloglar { get; set; }

        public Siparis IstenenSiparis { get; set; }

        
        public Musteri(string ad)
        {
            Ad = ad;
            Diyaloglar = new List<string>();
            
        }

    }
}
