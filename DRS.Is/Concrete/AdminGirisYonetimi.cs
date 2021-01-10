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
    public class AdminGirisYonetimi : IAdminGirisServis
    {
        private IAdminGirisDal _adminGirisDal;
        public AdminGirisYonetimi(IAdminGirisDal adminGirisDal)
        {
            _adminGirisDal = adminGirisDal;
        }
        public bool GirisYap(GirisBilgileri girisBilgileri)
        {
            if (_adminGirisDal.GirisYap(girisBilgileri))
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
            kullanici.Yetki = true;
        }
    }
}
