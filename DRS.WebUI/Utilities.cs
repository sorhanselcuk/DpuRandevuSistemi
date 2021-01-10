using DRS.Is.Abstracts;
using DRS.Is.Concrete;
using DRS.Is.DependencyResolves.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DRS.WebUI
{
     static class Utilities
    {
        private static IOgrenciServis _ogrenciServis= InstanceFactory.GetInstance<IOgrenciServis>();
        private static IAkademisyenServis _akademisyenServis = InstanceFactory.GetInstance<IAkademisyenServis>();
        public static string GetOgrenciAdSoyad(int ogrenciId)
        {
            var ogrenci = _ogrenciServis.Getir(ogrenciId);
            string adSoyad = ogrenci.Ad + " " + ogrenci.Soyad.ToUpper();
            return adSoyad;
        }
        public static string GetAkademisyenAdSoyad(int akademisyenId)
        {
            var akademisyen = _akademisyenServis.Getir(akademisyenId);
            string adSoyad = akademisyen.Ad + " " + akademisyen.Soyad.ToUpper();
            return adSoyad;
        }
        
    }
}