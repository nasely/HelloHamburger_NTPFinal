using HelloHamburger.Business.Manager;
using HelloHamburger.Core.Constants;
using HelloHamburger.DataAccess.Concrete;
using HelloHamburger.Entities.Concrete;

namespace HelloHamburger_NTPFinal
{
    public class Program
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
                string secim = SecimYaptir("Seç: ", new List<string> { "B", "R", "Q", "b", "r", "q" }).ToUpper();

                if (secim == "B")
                {
                    baslangicSecimYapildi = true;
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


            }

            while (true)
            {
                int bugunkuMusteriLimiti = oyunManager.GunlukMusteriSayisiGetir(mevcutOyun.TakipciSayisi);
                int gunlukKazanilanPara = 0;
                int gunlukHarcananMaliyet = 0;
                int memnunMusteriSayisi = 0;
                int kacanMusteriSayisi = 0;

                List<Tuple<string, ConsoleColor>> gunSonuRaporu = new List<Tuple<string, ConsoleColor>>();

                // Gün başı - Dükkan yönetimi
                bool dukkanYonetimBitti = false;
                while (!dukkanYonetimBitti)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("╔══════════════════════════════════╗");
                    Console.WriteLine("║         DÜKKAN YÖNETİMİ          ║");
                    Console.WriteLine("╚══════════════════════════════════╝");
                    Console.ResetColor();

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine($"Kasa: {mevcutOyun.Coin} Coin | Takipçi: {mevcutOyun.TakipciSayisi}");
                    Console.ResetColor();
                    Console.WriteLine("\n1. Sosyal Medyada Reklam Ver (1500 Coin) -> [+10 Takipçi]");
                    Console.WriteLine("2. Dekorasyonu Yenile (1000 Coin) -> [Yapım Aşamasında]");
                    Console.WriteLine("3. Dükkanı Aç (Müşterileri Almaya Başla)");

                    string dukkanSecim = SecimYaptir("\nSeç: ", new List<string> { "1", "2", "3" });

                    if (dukkanSecim == "1")
                    {
                        if (mevcutOyun.Coin >= 1500)
                        {
                            mevcutOyun.Coin -= 1500;
                            mevcutOyun.TakipciSayisi += 10;
                            Console.WriteLine("\nReklam verildi! Takipçi sayınız arttı. Devam etmek için bir tuşa basın...");
                            Console.ReadLine();
                        }
                        else
                        {
                            Console.WriteLine("\nYeterli coin yok! Devam etmek için bir tuşa basın...");
                            Console.ReadLine();
                        }
                    }
                    else if (dukkanSecim == "2")
                    {
                        Console.WriteLine("\nBu özellik yapım aşamasında! Devam etmek için bir tuşa basın...");
                        Console.ReadLine();
                    }
                    else if (dukkanSecim == "3")
                    {
                        dukkanYonetimBitti = true;
                    }

                }

                //Müşteri yönetimi

                for (int i = 0; i < bugunkuMusteriLimiti; i++)
                {
                    Console.Clear();
                    int kalanMusteri = bugunkuMusteriLimiti - i;
                    Console.WriteLine($"Coin: {mevcutOyun.Coin} | Takipçi: {mevcutOyun.TakipciSayisi} | Kalan Müşteri: {kalanMusteri}");
                    Console.WriteLine("------------------------------------------------------");

                    Musteri gelenMusteri = musteriManager.RastgeleMusteriGetir();

                    Console.WriteLine($"\nMüşteri: {gelenMusteri.Diyaloglar[0]}");

                    string ilkSecim = SecimYaptir($"Kasa: 1. {gelenMusteri.Diyaloglar[1]} / 2. {gelenMusteri.Diyaloglar[3]}", new List<string> { "1", "2" });

                    if (ilkSecim == "1")
                    {
                        Console.WriteLine($"\nMüşteri: {gelenMusteri.Diyaloglar[2]} ");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Müşteri sinirlenip dükkandan çıktı! Para kazanamadın. (Enter'a bas)");
                        Console.ResetColor();
                        Console.ReadLine();

                        kacanMusteriSayisi++;
                        continue;
                    }

                    Console.WriteLine($"\nMüşteri: {gelenMusteri.Diyaloglar[4]} ");
                    SecimYaptir($"Kasa: 1. Hemen hazırlıyorum, Ekmek ne olsun? ", new List<string> { "1" });

                    Console.WriteLine($"\nMüşteri: {gelenMusteri.Diyaloglar[5]} ");
                    SecimYaptir($"Kasa: 1. Ekstralardan alır mısın? ", new List<string> { "1" });

                    Console.WriteLine($"\nMüşteri: {gelenMusteri.Diyaloglar[6]} ");
                    SecimYaptir($"Kasa: 1. İçecek ister misin? ", new List<string> { "1" });

                    Console.WriteLine($"\nMüşteri: {gelenMusteri.Diyaloglar[7]} ");

                    //Ücret hesaplama
                    int alinacakUcret = gelenMusteri.IstenenSiparis.SatisFiyati;

                    if (gelenMusteri.IstenenSiparis.SecilenEkstra == "Patates Kızartması") alinacakUcret += FiyatListesi.EkstraPatatesSatis;
                    else if (gelenMusteri.IstenenSiparis.SecilenEkstra == "Soğan Halkası") alinacakUcret += FiyatListesi.EkstraSoganSatis;
                    else if (gelenMusteri.IstenenSiparis.SecilenEkstra == "Peynir Topları") alinacakUcret += FiyatListesi.EkstraPeynirSatis;

                    if (gelenMusteri.IstenenSiparis.SecilenIcecek == "Kola") alinacakUcret += FiyatListesi.IcecekKolaSatis;
                    else if (gelenMusteri.IstenenSiparis.SecilenIcecek == "Ayran") alinacakUcret += FiyatListesi.IcecekAyranSatis;
                    else if (gelenMusteri.IstenenSiparis.SecilenIcecek == "Limonata") alinacakUcret += FiyatListesi.IcecekLimonataSatis;

                    gunlukKazanilanPara += alinacakUcret;
                    Console.WriteLine($"\n>> Kasa: Tamamdır. {alinacakUcret} Coin tutyor. Para alındı mutfağa geçiliyor... (Enter'a bas)");
                    Console.ReadLine();


                    //MUTFAK

                    Siparis hazirlananSiparis = new Siparis();

                    //Burger
                    bool burgerSecildi = false;
                    while (!burgerSecildi)
                    {
                        Console.Clear();
                        Console.WriteLine("--- MUTFAK ---");
                        Console.WriteLine("T: Tarif Defterine Bak");
                        Console.WriteLine("1. Klasik Köfte Hamburger");
                        Console.WriteLine("2. Çıtır Tavuk Burger");
                        Console.WriteLine("3. Pastırmalı Burger");
                        Console.WriteLine("4. Vegan Burger");
                        Console.Write("Seç: ");

                        string bSecim = SecimYaptir("Seçiminiz: ", new List<string> { "T", "t", "1", "2", "3", "4" }).ToUpper();

                        if (bSecim == "T")
                        {
                            Console.WriteLine("\nHangi tarife bakmak istersin?");
                            Console.WriteLine("1. Klasik Köfte \n2. Çıtır Tavuk \n3. Pastırmalı \n4. Vegan");

                            string tSecim = SecimYaptir("Seçiminiz: ", new List<string> { "1", "2", "3", "4" });
                            string bakilacakAd = "";

                            if (tSecim == "1") bakilacakAd = "Klasik Köfte Hamburger";
                            else if (tSecim == "2") bakilacakAd = "Çıtır Tavuk Burger";
                            else if (tSecim == "3") bakilacakAd = "Pastırmalı Burger";
                            else if (tSecim == "4") bakilacakAd = "Vegan Burger";

                            Console.WriteLine($"\n-- {bakilacakAd} TARİFİ --");
                            foreach (var m in siparisManager.TarifGetir(bakilacakAd))
                            {
                                Console.WriteLine("- " + m);
                            }

                            Console.WriteLine("\nGeri dönmek için Enter'a bas...");
                            Console.ReadLine();
                        }
                        else if (bSecim == "1") { hazirlananSiparis.BurgerAdi = "Klasik Köfte Hamburger"; burgerSecildi = true; }
                        else if (bSecim == "2") { hazirlananSiparis.BurgerAdi = "Çıtır Tavuk Burger"; burgerSecildi = true; }
                        else if (bSecim == "3") { hazirlananSiparis.BurgerAdi = "Pastırmalı Burger"; burgerSecildi = true; }
                        else if (bSecim == "4") { hazirlananSiparis.BurgerAdi = "Vegan Burger"; burgerSecildi = true; }
                    }

                    //Ekmek
                    Console.WriteLine("\nEkmek Seçin:");
                    Console.WriteLine("1. Beyaz Ekmek \n2. Tam Buğday");
                    string ekmekSecim = SecimYaptir("Seçiminiz:", new List<string> { "1", "2" });
                    if (ekmekSecim == "1") hazirlananSiparis.SecilenEkmek = "Beyaz Ekmek";
                    else if (ekmekSecim == "2") hazirlananSiparis.SecilenEkmek = "Tam Buğday";

                    //Et
                    Console.WriteLine("\nEtini Pişir:");
                    Console.WriteLine("1. Köfte \n2. Tavuk \n3. Pastırma \n4. Vegan Köfte");
                    string etSecim = SecimYaptir("Seçiminiz:", new List<string> { "1", "2", "3", "4" });
                    if (etSecim == "1") hazirlananSiparis.SecilenEt = "Köfte";
                    else if (etSecim == "2") hazirlananSiparis.SecilenEt = "Tavuk";
                    else if (etSecim == "3") hazirlananSiparis.SecilenEt = "Pastırma";
                    else if (etSecim == "4") hazirlananSiparis.SecilenEt = "Vegan Köfte";

                    Console.WriteLine("\nİç Malzemeleri Ekle (Bitirmek için 6'ya bas):");
                    while (true)
                    {
                        Console.WriteLine("1. Marul | 2. Domates | 3. Turşu | 4. Cheddar Peyniri | 5. Burger Sos | 6. BİTTİ");

                        string malzSecim = SecimYaptir("", new List<string> { "1", "2", "3", "4", "5", "6"});

                        if (malzSecim == "6") break;
                        else if (malzSecim == "1") hazirlananSiparis.Icerik.Add("marul");
                        else if (malzSecim == "2") hazirlananSiparis.Icerik.Add("domates");
                        else if (malzSecim == "3") hazirlananSiparis.Icerik.Add("turşu");
                        else if (malzSecim == "4") hazirlananSiparis.Icerik.Add("cheddar peyniri");
                        else if (malzSecim == "5") hazirlananSiparis.Icerik.Add("burger sos");
                    }

                    Console.WriteLine("\nEkstra Seç:");
                    Console.WriteLine("1. Patates Kızartması \n2. Soğan Halkası \n3. Peynir Topları \n4. Yok");
                    string eksSecim = SecimYaptir("Seçiminiz:", new List<string> { "1", "2", "3", "4" });
                    if (eksSecim == "1") hazirlananSiparis.SecilenEkstra = "Patates Kızartması";
                    else if (eksSecim == "2") hazirlananSiparis.SecilenEkstra = "Soğan Halkası";
                    else if (eksSecim == "3") hazirlananSiparis.SecilenEkstra = "Peynir Topları";
                    else hazirlananSiparis.SecilenEkstra = "Yok";

                    Console.WriteLine("\nİçecek Seç:");
                    Console.WriteLine("1. Kola \n2. Ayran \n3. Limonata \n4. Yok");
                    string icSecim = SecimYaptir("Seçiminiz:", new List<string> { "1", "2", "3", "4" });
                    if (icSecim == "1") hazirlananSiparis.SecilenIcecek = "Kola";
                    else if (icSecim == "2") hazirlananSiparis.SecilenIcecek = "Ayran";
                    else if (icSecim == "3") hazirlananSiparis.SecilenIcecek = "Limonata";
                    else hazirlananSiparis.SecilenIcecek = "Yok";

                    // --- SİPARİŞ KONTROLÜ VE MALİYET HESAPLAMASI ---
                    Console.Clear();
                    Console.WriteLine("Sipariş Müşteriye Teslim Edildi...");

                    int siparisMaliyeti = 0;
                    List<string> kullanilanMalzemelerRaporu = new List<string>();

                    siparisMaliyeti += FiyatListesi.MaliyetEkmek;
                    kullanilanMalzemelerRaporu.Add($"{hazirlananSiparis.SecilenEkmek.ToLower()} (1 adet): -{FiyatListesi.MaliyetEkmek}");

                    if (hazirlananSiparis.SecilenEt == "Köfte") { siparisMaliyeti += FiyatListesi.MaliyetKofte; kullanilanMalzemelerRaporu.Add($"köfte (1 adet): -{FiyatListesi.MaliyetKofte}"); }
                    else if (hazirlananSiparis.SecilenEt == "Tavuk") { siparisMaliyeti += FiyatListesi.MaliyetTavuk; kullanilanMalzemelerRaporu.Add($"tavuk (1 adet): -{FiyatListesi.MaliyetTavuk}"); }
                    else if (hazirlananSiparis.SecilenEt == "Pastırma") { siparisMaliyeti += FiyatListesi.MaliyetPastirma; kullanilanMalzemelerRaporu.Add($"pastırma (1 adet): -{FiyatListesi.MaliyetPastirma}"); }
                    else if (hazirlananSiparis.SecilenEt == "Vegan Köfte") { siparisMaliyeti += FiyatListesi.MaliyetVeganKofte; kullanilanMalzemelerRaporu.Add($"vegan köfte (1 adet): -{FiyatListesi.MaliyetVeganKofte}"); }

                    foreach (var malzeme in hazirlananSiparis.Icerik)
                    {
                        int mFiyat = 10;
                        if (malzeme == "marul") mFiyat = FiyatListesi.MaliyetMarul;
                        else if (malzeme == "domates") mFiyat = FiyatListesi.MaliyetDomates;
                        else if (malzeme == "turşu") mFiyat = FiyatListesi.MaliyetTursu;
                        else if (malzeme == "cheddar peyniri") mFiyat = FiyatListesi.MaliyetCheddar;
                        else if (malzeme == "burger sos") mFiyat = FiyatListesi.MaliyetBurgerSos;


                        siparisMaliyeti += mFiyat;
                        kullanilanMalzemelerRaporu.Add($"{malzeme} (1 adet): -{mFiyat}");
                    }

                    if (hazirlananSiparis.SecilenEkstra == "Patates Kızartması") { siparisMaliyeti += FiyatListesi.MaliyetPatates; kullanilanMalzemelerRaporu.Add($"patates kızartması (1 adet): -{FiyatListesi.MaliyetPatates}"); }
                    else if (hazirlananSiparis.SecilenEkstra == "Soğan Halkası") { siparisMaliyeti += FiyatListesi.MaliyetSogan; kullanilanMalzemelerRaporu.Add($"soğan halkası (1 adet): -{FiyatListesi.MaliyetSogan}"); }
                    else if (hazirlananSiparis.SecilenEkstra == "Peynir Topları") { siparisMaliyeti += FiyatListesi.MaliyetPeynir; kullanilanMalzemelerRaporu.Add($"peynir topları (1 adet): -{FiyatListesi.MaliyetPeynir}"); }

                    if (hazirlananSiparis.SecilenIcecek == "Kola") { siparisMaliyeti += FiyatListesi.MaliyetKola; kullanilanMalzemelerRaporu.Add($"kola (1 adet): -{FiyatListesi.MaliyetKola}"); }
                    else if (hazirlananSiparis.SecilenIcecek == "Ayran") { siparisMaliyeti += FiyatListesi.MaliyetAyran; kullanilanMalzemelerRaporu.Add($"ayran (1 adet): -{FiyatListesi.MaliyetAyran}"); }
                    else if (hazirlananSiparis.SecilenIcecek == "Limonata") { siparisMaliyeti += FiyatListesi.MaliyetLimonata; kullanilanMalzemelerRaporu.Add($"limonata (1 adet): -{FiyatListesi.MaliyetLimonata}"); }

                    gunlukHarcananMaliyet += siparisMaliyeti;

                    bool dogruMu = siparisManager.SiparisDogruMu(gelenMusteri.IstenenSiparis, hazirlananSiparis);

                    if (dogruMu)
                    {
                        Console.WriteLine("Müşteri: Harika! Tam istediğim gibi olmuş.");
                        memnunMusteriSayisi++;
                        gunSonuRaporu.Add(new Tuple<string, ConsoleColor>($"{i + 1}.sipariş ({gelenMusteri.Ad}) : +{alinacakUcret}", ConsoleColor.Green));
                    }
                    else
                    {
                        Console.WriteLine("Müşteri: Bu benim siparişim değil! Beğenmedim, paramı geri ver!");
                        gunlukKazanilanPara -= alinacakUcret; // Yanlışsa alınan parayı iade et
                        kacanMusteriSayisi++;
                        gunSonuRaporu.Add(new Tuple<string, ConsoleColor>($"{i + 1}.sipariş ({gelenMusteri.Ad}) : +0 (İptal - Yanlış Sipariş)", ConsoleColor.Red));
                    }

                    foreach (var metin in kullanilanMalzemelerRaporu)
                    {
                        gunSonuRaporu.Add(new Tuple<string, ConsoleColor>(metin, ConsoleColor.Red));
                    }

                    Console.WriteLine("\nSıradaki müşteriye geçmek için Enter'a bas...");
                    Console.ReadLine();

                }


                // Gün sonu raporu

                Console.Clear();
                Console.WriteLine($"=== GÜN {mevcutOyun.KalinanGun} BİTTİ ===\n");

                foreach (var satir in gunSonuRaporu)
                {
                    Console.ForegroundColor = satir.Item2;
                    Console.WriteLine(satir.Item1);
                }
                Console.ResetColor();

                int netKazanc = gunlukKazanilanPara - gunlukHarcananMaliyet;

                Console.WriteLine("\n-------------------------");
                Console.Write("Günün Net Kazancı: ");

                if (netKazanc >= 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"+{netKazanc}");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"{netKazanc}");
                }
                Console.ResetColor();
                Console.WriteLine("-------------------------\n");

                Console.WriteLine($"Memnun Müşteri (+5 Takipçi): {memnunMusteriSayisi}");
                Console.WriteLine($"Kaçan Müşteri (-5 Takipçi): {kacanMusteriSayisi}");

                oyunManager.GunSonuHesapla(mevcutOyun, gunlukKazanilanPara, gunlukHarcananMaliyet, memnunMusteriSayisi, kacanMusteriSayisi);
                musteriManager.GunlukListeyiSifirla();

                Console.WriteLine($"\nNet Kasan: {mevcutOyun.Coin} Coin");
                Console.WriteLine($"Yeni Takipçi Sayın: {mevcutOyun.TakipciSayisi}");
                oyunManager.OyunuKaydet(mevcutOyun);

                Console.WriteLine("\nSonraki güne geçmek için G tuşuna, çıkmak için Q tuşuna bas.");
                string bitisSecimi = SecimYaptir("", new List<string> { "G", "Q", "g", "q" }).ToUpper();
                if (bitisSecimi == "Q") Environment.Exit(0);

            }
        }

        static string SecimYaptir(string mesaj, List<string> gecerliSecenekler)
        {
            while (true)
            {
                if (mesaj != "") Console.WriteLine(mesaj);
                string girdi = Console.ReadLine();

                if (gecerliSecenekler.Contains(girdi))
                {
                    return girdi;
                }
                else
                {
                    Console.WriteLine("Uyarı: Lütfen seçeneklerden birinizi seçin!");
                }
            }

        }
    }
}

