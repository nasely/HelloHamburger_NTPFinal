using HelloHamburger.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloHamburger.Business.Abstract
{
    public interface ISiparisService
    {
        bool SiparisDogruMu(Siparis beklenenSiparis, Siparis hazirlananSiparis);

        List<string> TarifGetir(string burgerAdi);

    }
}
