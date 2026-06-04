using HelloHamburger.DataAccess.Abstract;
using HelloHamburger.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HelloHamburger.DataAccess.Concrete
{
    public class JsonOyunVerisiDal : IOyunVerisiDal
    {
        private readonly string _dosyaYolu = "savegame.json";

        public void Kaydet(OyunVerisi veri)
        {
            string jsonMetni = JsonSerializer.Serialize(veri);

            File.WriteAllText(_dosyaYolu, jsonMetni);
        }

        public OyunVerisi Yukle()
        {
            if (!File.Exists(_dosyaYolu))
            {
                return new OyunVerisi(); 
            }

            string jsonMetni = File.ReadAllText(_dosyaYolu);

            return JsonSerializer.Deserialize<OyunVerisi>(jsonMetni); 
        }
    }
}
