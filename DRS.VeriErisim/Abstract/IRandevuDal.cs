using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRS.Veriler.Concrete;

namespace DRS.VeriErisim.Abstracts
{
    public interface IRandevuDal:INesne<Randevu>
    {
        List<Randevu> OgrenciRandevulariniGetir(int ogrenciId);
        List<Randevu> AkademisyenRandevulariniGetir(int akademisyenId);
    }
}
