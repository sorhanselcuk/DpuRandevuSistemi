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
using DRS.Is.Exceptions;

namespace DRS.Is.Concrete
{
    public class OgrenciYonetimi : IOgrenciServis
    {
        private IOgrenciDal _ogrenciDal;
        public OgrenciYonetimi(IOgrenciDal ogrenciDal)
        {
            _ogrenciDal = ogrenciDal;
        }
        public void Ekle(Ogrenci veri)
        {
            HataYonetimi.HataYakala(() =>
            {
                ValidationTool.Validate(new OgrenciValidator(), veri);
            });
            var ogrenciler = _ogrenciDal.HepsiniGetir().Select(o=>o.EPosta);
            if (ogrenciler.Contains(veri.EPosta))
                throw new SameDataException();
            _ogrenciDal.Ekle(veri);
        }

        public Ogrenci Getir(int id)
        {
            return _ogrenciDal.Getir(id);
        }

        public void Guncelle(Ogrenci veri)
        {
            _ogrenciDal.Guncelle(veri);
        }

        public List<Ogrenci> HepsiniGetir()
        {
            HataYonetimi.HataYakala(() =>
            {
                ValidationTool.Validate(new YetkiValidator(), Kullanici.GetInstance());
            });
            return _ogrenciDal.HepsiniGetir();
        }

        public void Sil(int id)
        {
            _ogrenciDal.Sil(id);
        }
    }
}
