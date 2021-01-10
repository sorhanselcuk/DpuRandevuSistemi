using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DRS.WebUI.admin
{
    public partial class admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
                Response.Redirect("../adminGiris.aspx");
        }

        protected void lnkBtnCikis_Click(object sender, EventArgs e)
        {
            Session.Remove("Admin");
            Response.Redirect("../default.aspx");
        }

        protected void lnkBtnProfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx");
        }

        protected void btnAnasayfa_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx");
        }

        protected void btnFakulteAyarlari_Click(object sender, EventArgs e)
        {
            Response.Redirect("fakulteAyarlari.aspx");
        }

        protected void btnBolumAyarlari_Click(object sender, EventArgs e)
        {
            Response.Redirect("bolumAyarlari.aspx");
        }
    }
}