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
    public class BolumYonetimi : IBolumServis
    {
        private IBolumDal _bolumdal;
        public BolumYonetimi(IBolumDal bolumDal)
        {
            _bolumdal = bolumDal;
        }
        public void Ekle(Bolum veri)
        {
            YetkiKontrol();
            _bolumdal.Ekle(veri);
        }

        public Bolum Getir(int id)
        {
            return _bolumdal.Getir(id);
        }

        public void Guncelle(Bolum veri)
        {
            YetkiKontrol();
            _bolumdal.Guncelle(veri);
        }

        public List<Bolum> HepsiniGetir()
        {
            return _bolumdal.HepsiniGetir();
        }

        public List<Bolum> HepsiniGetir(int fakulteId)
        {
            return _bolumdal.HepsiniGetir(fakulteId);
        }

        public void Sil(int id)
        {
            YetkiKontrol();
            _bolumdal.Sil(id);
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
