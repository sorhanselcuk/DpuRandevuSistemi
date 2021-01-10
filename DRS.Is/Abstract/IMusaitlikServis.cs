using DRS.Is.Abstracts;
using DRS.Veriler.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRS.Is.Abstract
{
    public interface IMusaitlikServis
    {
        void Ekle(Musaitlik veri);
        void Sil(int id);
        void Guncelle(Musaitlik veri);
        List<Musaitlik> HepsiniGetir(int akademisyenId);
        Musaitlik Getir(int id);
    }
}
