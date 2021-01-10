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
    public class AkademisyenGirisYonetimi : IAkademisyenGirisServis
    {
        private IAkademisyenGirisDal _akademisyenGirisDal;
        public AkademisyenGirisYonetimi(IAkademisyenGirisDal akademisyenGirisDal)
        {
            _akademisyenGirisDal = akademisyenGirisDal;
        }
        public bool GirisYap(GirisBilgileri girisBilgileri)
        {
            if (_akademisyenGirisDal.GirisYap(girisBilgileri))
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
