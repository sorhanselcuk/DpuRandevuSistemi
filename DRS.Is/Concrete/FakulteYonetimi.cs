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
    public class FakulteYonetimi : IFakulteServis
    {
        private IFakulteDal _fakulteDal;
        public FakulteYonetimi(IFakulteDal fakulteDal)
        {
            _fakulteDal = fakulteDal;
        }
        public void Ekle(Fakulte veri)
        {
            YetkiKontrol();
            _fakulteDal.Ekle(veri);
        }

        public Fakulte Getir(int id)
        {
            return _fakulteDal.Getir(id);
        }

        public void Guncelle(Fakulte veri)
        {
            YetkiKontrol();
            _fakulteDal.Guncelle(veri);
        }

        public List<Fakulte> HepsiniGetir()
        {
            return _fakulteDal.HepsiniGetir();
        }

        public void Sil(int id)
        {
            YetkiKontrol();
            _fakulteDal.Sil(id);
        }
        private void YetkiKontrol()
        {
            HataYonetimi.HataYakala(() =>
            {
                ValidationTool.Validate(new YetkiValidator(), Kullanici.GetInstance());
            });
        }
    }
}
