using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DRS.WebUI.akademisyen
{
    public partial class profil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Akademisyen"] == null)
                Response.Redirect("../default.aspx");
            var adSoyad = Utilities.GetAkademisyenAdSoyad(Convert.ToInt32(Session["Akademisyen"]));
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
            Session.Remove("Akademisyen");
            Response.Redirect("../default.aspx");
        }

        protected void lnkbtnProfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("profil.aspx");
        }

        protected void btnMusaitlikler_Click(object sender, EventArgs e)
        {
            Response.Redirect("musaitlik.aspx");
        }
    }
}