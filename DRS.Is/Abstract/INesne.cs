using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRS.Is.Abstracts
{
    public interface INesne<T>
    {
        void Ekle(T veri);
        void Sil(int id);
        void Guncelle(T veri);
        T Getir(int id);
        List<T> HepsiniGetir();
    }
}
