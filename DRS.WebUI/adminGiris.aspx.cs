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
    public partial class adminGiris : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGirisYap_Click(object sender, EventArgs e)
        {
            IAdminGirisServis adminGirisServis = InstanceFactory.GetInstance<AdminGirisYonetimi>();
            var result = adminGirisServis.GirisYap(new GirisBilgileri {
            KullaniciAdi=tbxKullaniciAdi.Text,
            Parola=tbxParola.Text
            });
            if (result)
            {
                Session["Admin"] = tbxKullaniciAdi.Text;
                Response.Redirect("admin/admin.aspx");
            }
            else
            {
                // js ile hatalı parola veya şifre alert
                string script = "window.onload  = adminAlert;";
                ScriptManager.RegisterStartupScript(this, GetType(), null, script, true);
            }
        }
    }
}