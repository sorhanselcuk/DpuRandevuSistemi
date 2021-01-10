using DRS.Is.Abstracts;
using DRS.Is.Concrete;
using DRS.Is.DependencyResolves.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DRS.WebUI.ogrenci
{
    public partial class profil : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Ogrenci"] == null)
                Response.Redirect("../default.aspx");
            var adSoyad=Utilities.GetOgrenciAdSoyad(Convert.ToInt32(Session["Ogrenci"]));
            Page.Title = adSoyad;
            lblKullaniciAdi.Text = adSoyad;
        }

        protected void btnDuyurular_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://www.dumlupinar.edu.tr/index/duyurular");
        }

        protected void btnObs_Click(object sender, EventArgs e)
        {
            Response.Redirect("https://obs.dpu.edu.tr");
        }

        protected void btnRandevular_Click(object sender, EventArgs e)
        {
            Response.Redirect("randevular.aspx");
        }

        protected void btnGecmisRandevular_Click(object sender, EventArgs e)
        {
            Response.Redirect("gecmisRandevular.aspx");
        }

        protected void btnOnayBekleyenRandevular_Click(object sender, EventArgs e)
        {
            Response.Redirect("OnayBekleyenRandevular.aspx");
        }

        protected void lnkbtnCikis_Click(object sender, EventArgs e)
        {
            Session.Remove("Ogrenci");
            Response.Redirect("../default.aspx");
        }

        protected void lnkbtnProfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("profil.aspx");
        }

        protected void btnRandevuTalep_Click(object sender, EventArgs e)
        {
            Response.Redirect("randevuTalep.aspx");
        }
    }
}