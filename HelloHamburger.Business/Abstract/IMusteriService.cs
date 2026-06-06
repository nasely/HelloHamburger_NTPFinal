using HelloHamburger.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloHamburger.Business.Abstract
{
    public interface IMusteriService
    {
        void GunlukListeyiSifirla();

        Musteri RastgeleMusteriGetir();

    }
}
