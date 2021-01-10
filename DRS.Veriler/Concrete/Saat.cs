using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRS.Veriler.Abstract;

namespace DRS.Veriler.Concrete
{
    public class Saat:IVeri
    {
        public int SaatId { get; set; }
        public TimeSpan saat { get; set; }
    }
}
