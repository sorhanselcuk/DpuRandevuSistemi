using DRS.Veriler.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRS.Is.Abstract
{
    public interface IGecmisRandevuServis
    {
        GecmisRandevu GecmisRandevuGetir(int id);
        List<GecmisRandevu> OgrenciGecmisRandevuHepsiniGetir(int ogrenciId);
        List<GecmisRandevu> AkademisyenGecmisRandevuHepsiniGetir(int akademisyenId);
    }
}
