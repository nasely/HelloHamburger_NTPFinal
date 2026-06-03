using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloHamburger.Entities.Concrete
{
    public class Siparis
    {
        
        public int SatisFiyati { get; set; }

        // Hamburgerin içindeki malzemeleri
        public List<string> Icerik { get; set; }

        public string BurgerAdi { get; set; }
        public string SecilenEt { get; set; }
        public string SecilenEkmek { get; set; }
        public string SecilenEkstra { get; set; }
        public string SecilenIcecek { get; set; }

       
        public Siparis()
        {
            Icerik = new List<string>();
        }

    }
}
