using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRS.Veriler.Abstract;

namespace DRS.Veriler.Concrete
{
    public class GecmisRandevu:IVeri
    {
        public int Id { get; set; }
        public Ogrenci Ogrenci { get; set; }
        public Akademisyen Akademisyen { get; set; }
        public string Konu { get; set; }
        public DateTime Tarih { get; set; }
        public TimeSpan Saat { get; set; }
    }
}
