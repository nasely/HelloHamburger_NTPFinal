using HelloHamburger.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloHamburger.DataAccess.Abstract
{
    public interface IOyunVerisiDal
    {
        void Kaydet(OyunVerisi veri);

        OyunVerisi Yukle();

    }
}
