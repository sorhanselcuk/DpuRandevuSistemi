using DRS.VeriErisim.Abstracts;
using DRS.Veriler.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRS.VeriErisim.Abstract
{
    public interface IMusaitlikDal
    {
        void Ekle(Musaitlik veri);
        void Sil(int id);
        void Guncelle(Musaitlik veri);
        Musaitlik Getir(int id);
        List<Musaitlik> HepsiniGetir(int akademisyenId);
    }
}
