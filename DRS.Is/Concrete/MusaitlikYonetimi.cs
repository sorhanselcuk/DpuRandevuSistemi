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
    public class MusaitlikYonetimi : IMusaitlikServis
    {
        private IMusaitlikDal _musaitlikDal;
        public MusaitlikYonetimi(IMusaitlikDal musaitlikDal)
        {
            _musaitlikDal = musaitlikDal;
        }
        public void Ekle(Musaitlik veri)
        {
            var musaitlikler = _musaitlikDal.HepsiniGetir(veri.Akademisyen.AkmId);
            foreach (var musaitlik in musaitlikler)
            {
                if (musaitlik.Tarih==veri.Tarih && musaitlik.Saat.SaatId==veri.Saat.SaatId)
                    return;
            }
            _musaitlikDal.Ekle(veri);
        }

        public Musaitlik Getir(int id)
        {
            return _musaitlikDal.Getir(id);
        }

        public void Guncelle(Musaitlik veri)
        {
            _musaitlikDal.Guncelle(veri);
        }

        public List<Musaitlik> HepsiniGetir(int akademisyenId)
        {
            return _musaitlikDal.HepsiniGetir(akademisyenId);
        }

        public void Sil(int id)
        {
            _musaitlikDal.Sil(id);
        }
    }
}
