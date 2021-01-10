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
    public class AkademisyenYonetimi : IAkademisyenServis
    {
        private IAkademisyenDal _akademisyenDal;
        public AkademisyenYonetimi(IAkademisyenDal akademisyenDal)
        {
            _akademisyenDal = akademisyenDal;
        }
        public void Ekle(Akademisyen veri)
        {
            HataYonetimi.HataYakala(()=> {
                ValidationTool.Validate(new AkademisyenValidator(), veri);
            });
            var akademisyenler = _akademisyenDal.HepsiniGetir().Select(a=>a.EPosta);
            if (akademisyenler.Contains(veri.EPosta))
                throw new SameDataException();
            _akademisyenDal.Ekle(veri);
        }

        public Akademisyen Getir(int id)
        {
            return _akademisyenDal.Getir(id);
        }

        public void Guncelle(Akademisyen veri)
        {
            _akademisyenDal.Guncelle(veri);
        }

        public List<Akademisyen> HepsiniGetir()
        {
            return _akademisyenDal.HepsiniGetir();
        }

        public void Sil(int id)
        {
            _akademisyenDal.Sil(id);
        }
    }
}
