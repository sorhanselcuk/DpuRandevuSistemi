using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRS.Veriler.Concrete;

namespace DRS.Is.Abstracts
{
    public interface IRandevuServis:INesne<Randevu>
    {
        List<Randevu> OgrenciRandevulariniGetir(int ogrenciId);
        List<Randevu> AkademisyenRandevulariniGetir(int akademisyenId);
        void RandevuKabulEt(int id);
        void RandevuReddet(int id);

    }
}
