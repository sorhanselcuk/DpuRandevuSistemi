using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRS.Is.Abstracts;
using DRS.Is.Utilities;
using DRS.Is.ValidationRules.FluentValidation;
using DRS.VeriErisim.Abstracts;
using DRS.Veriler.Concrete;

namespace DRS.Is.Concrete
{
    public class RandevuYonetimi : IRandevuServis
    {
        private IRandevuDal _randevuDal;
        private IEPostaServis _ePostaServis;
        public RandevuYonetimi(IRandevuDal randevuDal)
        {
            _randevuDal = randevuDal;
            _ePostaServis = new EPostaYonetimi();
        }

        public List<Randevu> AkademisyenRandevulariniGetir(int akademisyenId)
        {
            return _randevuDal.AkademisyenRandevulariniGetir(akademisyenId);
        }

        public void Ekle(Randevu veri)
        {
            HataYonetimi.HataYakala(() =>
            {
                ValidationTool.Validate(new RandevuValidator(), veri);
            });
            _randevuDal.Ekle(veri);
        }

        public Randevu Getir(int id)
        {
            return _randevuDal.Getir(id);
        }

        public void Guncelle(Randevu veri)
        {
            HataYonetimi.HataYakala(() =>
            {
                ValidationTool.Validate(new RandevuValidator(), veri);
            });
            _randevuDal.Guncelle(veri);
        }

        public List<Randevu> HepsiniGetir()
        {
            HataYonetimi.HataYakala(() =>
            {
                ValidationTool.Validate(new YetkiValidator(), Kullanici.GetInstance());
            });
            return _randevuDal.HepsiniGetir();
        }

        public List<Randevu> OgrenciRandevulariniGetir(int ogrenciId)
        {
            return _randevuDal.OgrenciRandevulariniGetir(ogrenciId);
        }

        public void RandevuKabulEt(int id)
        {
            var randevu = Getir(id);
            randevu.AktifMi = true;
            Guncelle(randevu);
            _ePostaServis.RandevuKabulEPostaGonder(randevu);
            var randevular = _randevuDal.AkademisyenRandevulariniGetir(randevu.Akademisyen.AkmId);
            var reddedilecekRandevular = randevular.Where(p => p.Tarih == randevu.Tarih &&
            p.Saat.SaatId == randevu.Saat.SaatId);
            foreach (var r in reddedilecekRandevular)
            {
                if (id == r.RandevuId)
                    continue;
                _ePostaServis.RandevuRedEPostaGonder(r);
                _randevuDal.Sil(r.RandevuId);
            }
        }

        public void RandevuReddet(int id)
        {
            var randevu = Getir(id);
            Sil(id);
            _ePostaServis.RandevuRedEPostaGonder(randevu);
        }

        public void Sil(int id)
        {
            var randevu = Getir(id);
            HataYonetimi.HataYakala(() =>
            {
                ValidationTool.Validate(new RandevuIptalValidator(), randevu);
            });
            _randevuDal.Sil(id);
        }
    }
}
