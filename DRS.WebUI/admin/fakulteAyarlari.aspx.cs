using DRS.Is.Abstracts;
using DRS.Is.DependencyResolves.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DRS.WebUI.admin
{
    public partial class fakulteAyarlari : System.Web.UI.Page
    {
        private IFakulteServis _fakulteServis;
        private static int _fakulteId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
                Response.Redirect("../adminGiris.aspx");
            _fakulteServis = InstanceFactory.GetInstance<IFakulteServis>();
            FakulteleriYukle();
        }

        private void FakulteleriYukle()
        {
            int i = 0;
            var fakulteler = _fakulteServis.HepsiniGetir();
            foreach (var fakulte in fakulteler)
            {
                TableRow tableRow = new TableRow();
                TableHeaderCell tableHeaderCell = new TableHeaderCell();
                tableHeaderCell.Scope = TableHeaderScope.Row;
                tableHeaderCell.Text = (++i).ToString();
                tableRow.Controls.Add(tableHeaderCell);

                TableCell fakulteAd = new TableCell();
                fakulteAd.Text = fakulte.FakulteAd;
                tableRow.Controls.Add(fakulteAd);

                TableCell butonlar = new TableCell();

                LinkButton lnkBtnSil = new LinkButton();
                lnkBtnSil.ID = "s" + fakulte.FakulteId.ToString();
                lnkBtnSil.CssClass = "btn btn-danger";
                lnkBtnSil.Click += LnkBtnSil_Click;
                lnkBtnSil.Text = "<i class='fa fa-times'></i>";

                butonlar.Controls.Add(lnkBtnSil);

                LinkButton lnkBtnBilgiAl = new LinkButton();
                lnkBtnBilgiAl.ID = "i" + fakulte.FakulteId.ToString();
                lnkBtnBilgiAl.CssClass = "btn btn-info";
                lnkBtnBilgiAl.Click += LnkBtnBilgiAl_Click; ;
                lnkBtnBilgiAl.Text = "<i class='fa fa-info'></i> ";

                butonlar.Controls.Add(lnkBtnBilgiAl);
                tableRow.Controls.Add(butonlar);
                FakulteTablosu.Controls.Add(tableRow);
            }
        }

        private void LnkBtnBilgiAl_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            int id = Convert.ToInt32(linkButton.ID.Substring(1));
            Response.Redirect("bolumAyarlari.aspx?f="+id);
        }

        private void LnkBtnSil_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            int id = Convert.ToInt32(linkButton.ID.Substring(1));
            _fakulteId = id;
            string script = "OnayFakulteSil();";
            ScriptManager.RegisterStartupScript(this,GetType(),null,script,true);
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

        protected void btnIslem_Click(object sender, EventArgs e)
        {
            _fakulteServis.Sil(_fakulteId);
            SayfayiYenile();
        }

        protected void btnFakulteEkle_Click(object sender, EventArgs e)
        {
            _fakulteServis.Ekle(new Veriler.Concrete.Fakulte
            {
                FakulteAd = tbxFakulteAd.Text
            });
            SayfayiYenile();
        }
        private void SayfayiYenile()
        {
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
    }
}