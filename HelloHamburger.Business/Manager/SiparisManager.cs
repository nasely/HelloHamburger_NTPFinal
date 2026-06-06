using HelloHamburger.Business.Abstract;
using HelloHamburger.Core.Constants;
using HelloHamburger.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloHamburger.Business.Manager
{
    public class SiparisManager : ISiparisService
    {
        public bool SiparisDogruMu(Siparis beklenenSiparis, Siparis hazirlananSiparis)
        {
            if (beklenenSiparis.SecilenEkmek != hazirlananSiparis.SecilenEkmek) return false;
            if (beklenenSiparis.SecilenEt != hazirlananSiparis.SecilenEt) return false;
            if (beklenenSiparis.SecilenEkstra != hazirlananSiparis.SecilenEkstra) return false;
            if (beklenenSiparis.SecilenIcecek != hazirlananSiparis.SecilenIcecek) return false;


            List<string> gercekTarif = TarifDefteri.BurgerTarifleri[beklenenSiparis.BurgerAdi];

            if(gercekTarif.Count != hazirlananSiparis.Icerik.Count) return false;


            bool icerikDogruMu = gercekTarif.OrderBy(x => x).SequenceEqual(hazirlananSiparis.Icerik.OrderBy(x => x));

            return icerikDogruMu;

        }

        public List<string> TarifGetir(string burgerAdi)
        {
            if (TarifDefteri.BurgerTarifleri.ContainsKey(burgerAdi))
            {
                return TarifDefteri.BurgerTarifleri[burgerAdi];
            }
           
            return new List<string>();

        }
    }
}
