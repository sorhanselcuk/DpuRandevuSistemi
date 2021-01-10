using DRS.Veriler.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRS.Veriler.Concrete
{
    public class Musaitlik:IVeri
    {
        public int Id { get; set; }
        public DateTime Tarih { get; set; }
        public Saat Saat { get; set; }
        public Akademisyen Akademisyen { get; set; }
    }
}
