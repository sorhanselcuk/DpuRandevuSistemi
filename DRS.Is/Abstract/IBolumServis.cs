using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRS.Veriler.Concrete;

namespace DRS.Is.Abstracts
{
    public interface IBolumServis:INesne<Bolum>
    {
        List<Bolum> HepsiniGetir(int fakulteId);
    }
}
