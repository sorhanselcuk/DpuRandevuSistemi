using DRS.Is.Abstract;
using DRS.VeriErisim.Abstract;
using DRS.Veriler.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRS.Is.Concrete
{
    public class GecmisRandevuYonetimi : IGecmisRandevuServis
    {
        private IGecmisRandevuDal _gecmisRanevuDal;
        public GecmisRandevuYonetimi(IGecmisRandevuDal gecmisRandevuDal)
        {
            _gecmisRanevuDal = gecmisRandevuDal;
        }
        public GecmisRandevu GecmisRandevuGetir(int id)
        {
            return _gecmisRanevuDal.GecmisRandevuGetir(id);
        }

        public List<GecmisRandevu> AkademisyenGecmisRandevuHepsiniGetir(int akademisyenId)
        {
            return _gecmisRanevuDal.AkademisyenGecmisRandevuHepsiniGetir(akademisyenId);
        }

        public List<GecmisRandevu> OgrenciGecmisRandevuHepsiniGetir(int ogrenciId)
        {
            return _gecmisRanevuDal.OgrenciGecmisRandevuHepsiniGetir(ogrenciId);
        }
    }
}
