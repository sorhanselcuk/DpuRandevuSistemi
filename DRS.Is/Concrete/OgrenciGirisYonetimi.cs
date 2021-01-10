using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRS.Is.Abstracts;
using DRS.VeriErisim.Abstracts;
using DRS.Veriler.Concrete;

namespace DRS.Is.Concrete
{
    public class OgrenciGirisYonetimi:IOgrenciGirisServis
    {
        private IOgrenciGirisDal _ogrenciGirisDal;
        public OgrenciGirisYonetimi(IOgrenciGirisDal ogrenciGirisDal)
        {
            _ogrenciGirisDal = ogrenciGirisDal;
        }
        public bool GirisYap(GirisBilgileri girisBilgileri)
        {
            if (_ogrenciGirisDal.GirisYap(girisBilgileri))
            {
                Session(girisBilgileri.KullaniciId);
                return true;
            }
            return false;
        }
        private void Session(int kullaniciId)
        {
            Kullanici kullanici = Kullanici.GetInstance();
            kullanici.KullaniciId = kullaniciId;
        }
    }
}
