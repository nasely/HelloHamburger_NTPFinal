using HelloHamburger.Business.Manager;
using HelloHamburger.DataAccess.Concrete;
using HelloHamburger.Entities.Concrete;

namespace HelloHamburger_NTPFinal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            JsonOyunVerisiDal dataAccess = new JsonOyunVerisiDal();
            OyunManager oyunManager = new OyunManager(dataAccess);
            MusteriManager musteriManager = new MusteriManager();
            SiparisManager siparisManager = new SiparisManager();

            OyunVerisi mevcutOyun = oyunManager.OyunuYukle();

            bool baslangicSecimYapildi = false;

            while (!baslangicSecimYapildi)
            {
                Console.Clear();
                Console.WriteLine($"Coin: {mevcutOyun.Coin}    Takipçi: {mevcutOyun.TakipciSayisi}");
                Console.WriteLine("\n         Hello Hamburger!\n");
                Console.WriteLine($"               Gün {mevcutOyun.KalinanGun}\n");
                Console.WriteLine("B: Başla");
                Console.WriteLine("R: Oyunu Sıfırla");
                Console.WriteLine("Q: Çıkış");
                Console.Write("Seç: ");
                string secim = Console.ReadLine().ToUpper();   

                if(secim == "B")
                {
                    baslangicSecimYapildi=true;
                }
                else if (secim == "R")
                {
                    if (File.Exists("savegame.json"))
                    {
                        File.Delete("savegame.json");
                    }
                    mevcutOyun = new OyunVerisi();
                    Console.WriteLine("\nOyun başarıyla sıfırlandı! Başlamak için bir tuşa basın...");
                    Console.ReadLine();
                }
                else if (secim == "Q")
                {
                    oyunManager.OyunuKaydet(mevcutOyun);
                    Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("\nUyarı: Lütfen geçerli bir seçenek girin!");
                    Console.ReadLine();
                }

            }

        }

        
    }
}
