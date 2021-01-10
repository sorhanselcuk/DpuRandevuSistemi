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
    public partial class akademisyenGiris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Akademisyen"] != null)
                Response.Redirect("akademisyen/profil.aspx");

        }

        protected void btnGirisYap_Click(object sender, EventArgs e)
        {
            IAkademisyenGirisServis akademisyenGirisServis = InstanceFactory.GetInstance<IAkademisyenGirisServis>();
            var result = akademisyenGirisServis.GirisYap(new GirisBilgileri {
            KullaniciAdi=tbxEPosta.Text,
            Parola=tbxParola.Text
            });
            if (result)
            {
                Session["Akademisyen"] = Kullanici.GetInstance().KullaniciId;
                Response.Redirect("akademisyen/profil.aspx");
            }
            else
            {
                // js ile hatalı parola alerti

                string script = "window.onload  = girisAlerti;";
                ScriptManager.RegisterStartupScript(this, GetType(), null, script, true);
            }
        }
    }
}