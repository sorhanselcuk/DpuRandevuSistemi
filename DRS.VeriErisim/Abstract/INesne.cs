using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DRS.Veriler.Abstract;

namespace DRS.VeriErisim.Abstracts
{
    public interface INesne<T> where T: class, IVeri, new()
    {
        void Ekle(T veri);
        void Sil(int id);
        void Guncelle(T veri);
        T Getir(int id);
        List<T> HepsiniGetir();

    }
}
