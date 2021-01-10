using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRS.Veriler.Abstract;

namespace DRS.Veriler.Concrete
{
    public class Randevu:IVeri
    {
        public int RandevuId { get; set; }
        public Akademisyen Akademisyen { get; set; }
        public Ogrenci Ogrenci { get; set; }
        public string Konu { get; set; }
        public DateTime Tarih { get; set; }
        public Saat Saat { get; set; }
        public bool AktifMi { get; set; }
    }
}
