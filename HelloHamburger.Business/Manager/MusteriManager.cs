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
    public class MusteriManager : IMusteriService
    {
        private List<Musteri> _tumMusteriler;
        private List<Musteri> _bugunGelenler;
        private Random _rastgele;


        public MusteriManager()
        {
            _tumMusteriler = new List<Musteri>();
            _bugunGelenler = new List<Musteri>();
            _rastgele = new Random();

            MusterileriOlustur();
        }

        private void MusterileriOlustur()
        {
            // 1. STANDART MÜŞTERİ
            Siparis siparis1 = new Siparis { BurgerAdi = "Çıtır Tavuk Burger", SatisFiyati = FiyatListesi.CitirTavukSatis, SecilenEt = "Tavuk", SecilenEkmek = "Beyaz Ekmek", SecilenEkstra = "Patates Kızartması", SecilenIcecek = "Ayran" };
            Musteri musteri1 = new Musteri("Müşteri 1") { IstenenSiparis = siparis1 };
            musteri1.Diyaloglar.Add("Selam! Bütün gün dersteydim, kurt gibi açım. Hemen bir şeyler yemem lazım!"); 
            musteri1.Diyaloglar.Add("Şu an çok yoğunuz, bence başka bir yere bakın."); 
            musteri1.Diyaloglar.Add("Nasıl bir esnaflık bu ya? Gidiyorum!"); 
            musteri1.Diyaloglar.Add("Hoş geldiniz, hemen enerjinizi yerine getirelim. Ne alırdınız?");
            musteri1.Diyaloglar.Add("Bana güzel bir Çıtır Tavuk Burger hazırlar mısınız?");
            musteri1.Diyaloglar.Add("Beyaz Ekmek olsun."); 
            musteri1.Diyaloglar.Add("Ekstra olarak Patates kızartması istiyorum."); 
            musteri1.Diyaloglar.Add("İçecek de Ayran alayım."); 
            _tumMusteriler.Add(musteri1);

            // 2. KALORİ HESAPLAYAN MÜŞTERİ
            Siparis siparis2 = new Siparis { BurgerAdi = "Vegan Burger", SatisFiyati = FiyatListesi.VeganSatis, SecilenEt = "Vegan Köfte", SecilenEkmek = "Tam Buğday", SecilenEkstra = "Yok", SecilenIcecek = "Limonata" };
            Musteri musteri2 = new Musteri("Müşteri 2") { IstenenSiparis = siparis2 };
            musteri2.Diyaloglar.Add("Merhaba, diyetteyim de yediğim her şeyin kalorisini hesaplamam gerekiyor. Hafif bir şeyler var mı?");
            musteri2.Diyaloglar.Add("Burası hamburgerci, salatacı değil maalesef.");
            musteri2.Diyaloglar.Add("Çok kabasınız! Bir daha adımımı atmam.");
            musteri2.Diyaloglar.Add("Elbette, kalorisi düşük çok lezzetli bir menümüz var.");
            musteri2.Diyaloglar.Add("Harika! O zaman bana bir Vegan Burger verebilir misiniz?");
            musteri2.Diyaloglar.Add("Ekmek Tam Buğday olsun lütfen.");
            musteri2.Diyaloglar.Add("Ekstra istemiyorum, teşekkürler.");
            musteri2.Diyaloglar.Add("Yanına sadece Limonata alayım.");
            _tumMusteriler.Add(musteri2);

            // 3. ÇOCUK MÜŞTERİ
            Siparis siparis3 = new Siparis { BurgerAdi = "Klasik Köfte Hamburger", SatisFiyati = FiyatListesi.KlasikKofteSatis, SecilenEt = "Köfte", SecilenEkmek = "Beyaz Ekmek", SecilenEkstra = "Soğan Halkası", SecilenIcecek = "Kola" };
            Musteri musteri3 = new Musteri("Müşteri 3") { IstenenSiparis = siparis3 };
            musteri3.Diyaloglar.Add("Merhaba! Ben sipariş vermek istiyorum.");
            musteri3.Diyaloglar.Add("Çocuklara satış yapmıyoruz.");
            musteri3.Diyaloglar.Add("Bu ne saçma bir kural? Başka yere giderim o zaman.");
            musteri3.Diyaloglar.Add("Harika! Hemen hazırlayayım, hangi burgeri isterdin?");
            musteri3.Diyaloglar.Add("Klasik Köfte Hamburger! Bayılırım.");
            musteri3.Diyaloglar.Add("Beyaz Ekmek olsun.");
            musteri3.Diyaloglar.Add("Soğan Halkası da koyalım yanına.");
            musteri3.Diyaloglar.Add("Kola olur mu.");
            _tumMusteriler.Add(musteri3);

            // 4. GURME MÜŞTERİ
            Siparis siparis4 = new Siparis { BurgerAdi = "Pastırmalı Burger", SatisFiyati = FiyatListesi.PastirmaliSatis, SecilenEt = "Pastırma", SecilenEkmek = "Tam Buğday", SecilenEkstra = "Peynir Topları", SecilenIcecek = "Yok" };
            Musteri musteri4 = new Musteri("Müşteri 4") { IstenenSiparis = siparis4 };
            musteri4.Diyaloglar.Add("Sıradan şeyler yemekten çok sıkıldım. Bana şöyle iddialı ve farklı bir şeyler yapabilir misiniz?");
            musteri4.Diyaloglar.Add("Menüdekiler dışında özel bir şey yapamayız, kusura bakmayın.");
            musteri4.Diyaloglar.Add("Vizyonsuzluk... Neyse kolay gelsin.");
            musteri4.Diyaloglar.Add("Tam ağzınıza layık, dükkanımızın imza lezzetlerinden biri var.");
            musteri4.Diyaloglar.Add("O zaman Pastırmalı Burgerinizi denemek isterim.");
            musteri4.Diyaloglar.Add("Tam Buğday ekmeğine yakışır bence.");
            musteri4.Diyaloglar.Add("Yanına da Peynir Topları alayım.");
            musteri4.Diyaloglar.Add("İçecek istemiyorum, teşekkürler.");
            _tumMusteriler.Add(musteri4);

            // 5. SABIRSIZ MÜŞTERİ
            Siparis siparis5 = new Siparis { BurgerAdi = "Çıtır Tavuk Burger", SatisFiyati = FiyatListesi.CitirTavukSatis, SecilenEt = "Tavuk", SecilenEkmek = "Beyaz Ekmek", SecilenEkstra = "Yok", SecilenIcecek = "Kola" };
            Musteri musteri5 = new Musteri("Müşteri 5") { IstenenSiparis = siparis5 };
            musteri5.Diyaloglar.Add("Acelem var, hemen otobüse yetişmem lazım! En hızlı pişen şey neyse onu verin bana!");
            musteri5.Diyaloglar.Add("Sıranızı beklemek zorundasınız, acele iş yapmıyoruz.");
            musteri5.Diyaloglar.Add("Geç kaldım zaten, kalsın!");
            musteri5.Diyaloglar.Add("Hemen hallediyorum, saniyeler içinde elinizde olacak.");
            musteri5.Diyaloglar.Add("Çok sağ olun, bana bir Çıtır Tavuk Burger yapın o zaman.");
            musteri5.Diyaloglar.Add("Beyaz Ekmek.");
            musteri5.Diyaloglar.Add("Ekstra bekleyemem, yok.");
            musteri5.Diyaloglar.Add("Bir tane de Kola verin.");
            _tumMusteriler.Add(musteri5);


        }
        public void GunlukListeyiSifirla()
        {
            _bugunGelenler.Clear();
        }

        public Musteri RastgeleMusteriGetir()
        {
           List<Musteri> gelmeyenler = _tumMusteriler.Where(m => !_bugunGelenler.Contains(m)).ToList();

           if (gelmeyenler.Count == 0)
           {
                GunlukListeyiSifirla();
                gelmeyenler = _tumMusteriler;
           }

           int rastgeleIndex = _rastgele.Next(gelmeyenler.Count);
           Musteri secilenMusteri = gelmeyenler[rastgeleIndex];

           _bugunGelenler.Add(secilenMusteri);

           return secilenMusteri;
        }
    }
}
