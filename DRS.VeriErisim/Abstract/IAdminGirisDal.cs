using DRS.Veriler.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DRS.VeriErisim.Abstracts
{
    public interface IAdminGirisDal
    {
        bool GirisYap(GirisBilgileri girisBilgileri);
    }
}
