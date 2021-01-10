using DRS.Is.Abstracts;
using DRS.Is.Concrete;
using DRS.Is.DependencyResolves.Ninject;
using DRS.Veriler.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DRS.WebUI
{
    public partial class ogrenciGiris : System.Web.UI.Page
    {
        private IOgrenciGirisServis _ogrenciGirisServis;
        protected void Page_Load(object sender, EventArgs e)
        {
            _ogrenciGirisServis = InstanceFactory.GetInstance<IOgrenciGirisServis>();
        }

        protected void btnGirisYap_Click(object sender, EventArgs e)
        {
            var result = _ogrenciGirisServis.GirisYap(new GirisBilgileri
            {
                KullaniciAdi = tbxEPosta.Text,
                Parola = tbxParola.Text
            });
            if (result)
            {
                Session["Ogrenci"] = Kullanici.GetInstance().KullaniciId;
                Response.Redirect("ogrenci/profil.aspx");
            }
            else
            {
                // alert atılacak !
                string script = "window.onload  = girisAlerti;";
                ScriptManager.RegisterStartupScript(this, GetType(), null, script, true);

            }
        }
    }
}