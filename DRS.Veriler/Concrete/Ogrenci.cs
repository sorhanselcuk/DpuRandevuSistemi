using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRS.Veriler.Abstract;

namespace DRS.Veriler.Concrete
{
    public class Ogrenci:IVeri
    {
        public int OgrId { get; set; }
        public string OgrNo { get; set; }
        public string EPosta { get; set; }
        public string Parola { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public Fakulte Fakulte { get; set; }
        public Bolum Bolum { get; set; }
    }
}
