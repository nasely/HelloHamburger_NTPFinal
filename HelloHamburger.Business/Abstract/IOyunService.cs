using HelloHamburger.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloHamburger.Business.Abstract
{
    public interface IOyunService
    {
        OyunVerisi OyunuYukle();
        void OyunuKaydet(OyunVerisi veri);      

        int GunlukMusteriSayisiGetir(int takipciSayisi);

        void GunSonuHesapla(OyunVerisi veri, int kazanilanPara, int harcanaMaliyet, int memnunMusteri, int kacanMusteri);

    }
}
