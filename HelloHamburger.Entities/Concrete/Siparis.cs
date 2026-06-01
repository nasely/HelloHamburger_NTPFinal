using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloHamburger.Entities.Concrete
{
    public class Siparis
    {
        public string BurgerAdi { get; set; }
        public int SatisFiyati { get; set; }

        // Hamburgerin içindeki malzemeleri (Köfte, Turşu vs.) tutacak liste
        public List<string> Icerik { get; set; }

        // Menüdeki diğer seçimler
        public string SecilenEt { get; set; }
        public string SecilenEkmek { get; set; }
        public string SecilenEkstra { get; set; }
        public string SecilenIcecek { get; set; }

        // Constructor: Sipariş oluşturulduğunda listeyi hazır hale getirir
        public Siparis()
        {
            Icerik = new List<string>();
        }

    }
}
