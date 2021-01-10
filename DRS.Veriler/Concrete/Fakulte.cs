using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRS.Veriler.Abstract;

namespace DRS.Veriler.Concrete
{
    public class Fakulte:IVeri
    {
        public int FakulteId { get; set; }
        public string FakulteAd { get; set; }
    }
}
