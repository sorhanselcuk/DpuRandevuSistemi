using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRS.Veriler.Abstract;

namespace DRS.Veriler.Concrete
{
    public class Bolum : IVeri
    {
        public int BolumId { get; set; }
        public int FakulteId { get; set; }
        public string BolumAd { get; set; }
    }
}
