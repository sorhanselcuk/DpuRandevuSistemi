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
    public class SaatYonetimi : ISaatServis
    {
        private ISaatDal _saatDal;
        private Kullanici _kullanici;
        public SaatYonetimi(ISaatDal saatDal)
        {
            _saatDal = saatDal;
            _kullanici = Kullanici.GetInstance();
        }
        public void Ekle(Saat veri)
        {
            ValidationTool.Validate(new YetkiValidator(), Kullanici.GetInstance());
            _saatDal.Ekle(veri);
        }

        public Saat Getir(int id)
        {
            return _saatDal.Getir(id);
        }

        public void Guncelle(Saat veri)
        {
            ValidationTool.Validate(new YetkiValidator(), Kullanici.GetInstance());
            _saatDal.Guncelle(veri);
        }

        public List<Saat> HepsiniGetir()
        {
            return _saatDal.HepsiniGetir();
        }

        public void Sil(int id)
        {
            ValidationTool.Validate(new YetkiValidator(),Kullanici.GetInstance());
            _saatDal.Sil(id);
        }
    }
}
