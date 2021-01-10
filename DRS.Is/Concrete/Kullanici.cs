using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DRS.Is.Abstracts;
using DRS.VeriErisim.Concrete.Sql;

namespace DRS.Is.Concrete
{
    public class Kullanici
    {
        private static Kullanici _kullanici=null;
        public int KullaniciId { get; set; }
        public bool Yetki { get; set; }
        private Kullanici()
        {
            Yetki =false;
            // Yetki yalnızca admin için verilmiştir.
            // Kullanici sisteme giriş yaptığında Session'a ulaşmak için ara bir class
            // Singleton Design Pattern
        }
        public static Kullanici GetInstance()
        {
            if (_kullanici == null)
                _kullanici = new Kullanici();
            return _kullanici;

        }
    }
}
