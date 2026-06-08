using HelloHamburger.Business.Abstract;
using HelloHamburger.DataAccess.Abstract;
using HelloHamburger.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloHamburger.Business.Manager
{
    public class OyunManager : IOyunService
    {
        private readonly IOyunVerisiDal _oyunVerisiDal;

        public OyunManager(IOyunVerisiDal oyunVerisiDal)
        {
            _oyunVerisiDal = oyunVerisiDal;
        }

        public OyunVerisi OyunuYukle()
        {
            return _oyunVerisiDal.Yukle();
        }

        public void OyunuKaydet(OyunVerisi veri)
        {
            _oyunVerisiDal.Kaydet(veri);
        }



        public int GunlukMusteriSayisiGetir(int takipciSayisi)
        {
            if (takipciSayisi <= 30) return 2;
            if (takipciSayisi <= 100) return 3;
            if (takipciSayisi <= 200) return 4;
            return 5;

        }

        public void GunSonuHesapla(OyunVerisi veri, int kazanilanPara, int harcanaMaliyet, int memnunMusteri, int kacanMusteri)
        {
            int netKazanc = kazanilanPara - harcanaMaliyet;

            veri.TakipciSayisi += (memnunMusteri * 5);
            veri.TakipciSayisi -= (kacanMusteri * 5);

            if(veri.TakipciSayisi < 0)
            {
                veri.TakipciSayisi = 0;
            }

            veri.KalinanGun++;
        }

        
    }
}
