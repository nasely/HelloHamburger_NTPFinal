using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloHamburger.Entities.Concrete
{
    public class OyunVerisi
    {
        public int Coin { get; set; }
        public int TakipciSayisi { get; set; }
        public int KalinanGun { get; set; }

        // başlangıç değerleri
        public OyunVerisi()
        {
            Coin = 0;          
            TakipciSayisi = 25; 
            KalinanGun = 1;     
        }

    }
}
