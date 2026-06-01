using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloHamburger.Entities.Concrete
{
    public class Malzeme
    {
        public string Ad { get; set; } 
        public int Maliyet { get; set; }
        public string Kategori { get; set; }

        public Malzeme(string ad, int maliyet, string kategori)
        {
            Ad = ad;
            Maliyet = maliyet;
            Kategori = kategori;
        }


    }
}
