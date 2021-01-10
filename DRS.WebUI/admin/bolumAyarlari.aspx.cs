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
    public partial class bolumAyarlari : System.Web.UI.Page
    {
        private IBolumServis _bolumServis;
        private IFakulteServis _fakulteServis;
        private static int _bolumId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin"] == null)
                Response.Redirect("../adminGiris.aspx");
            _bolumServis = InstanceFactory.GetInstance<IBolumServis>();
            _fakulteServis = InstanceFactory.GetInstance<IFakulteServis>();
            BolumleriYukle();
            if(!IsPostBack)
            FakulteleriYukle();
            if (Request.QueryString["f"] != null) { 
                ScriptManager.RegisterStartupScript(this,GetType(),null,"$('#geriDon').toggle();",true);
            }
            else
                ScriptManager.RegisterStartupScript(this, GetType(), null, "$('#bolumEkle').toggle();", true);

        }

        private void FakulteleriYukle()
        {
            var fakulteler = _fakulteServis.HepsiniGetir();
            foreach (var fakulte in fakulteler)
            {
                cbxFakulteler.Items.Add(new ListItem { 
                Text=fakulte.FakulteAd,
                Value=fakulte.FakulteId.ToString()
                });
            }
        }

        private void BolumleriYukle()
        {
            int i = 0;
            var bolumler = _bolumServis.HepsiniGetir();
            foreach (var bolum in bolumler)
            {
                if (Request.QueryString["f"] != null && bolum.FakulteId != Convert.ToInt32(Request.QueryString["f"]))
                    continue;
                TableRow tableRow = new TableRow();
                TableHeaderCell tableHeaderCell = new TableHeaderCell();
                tableHeaderCell.Scope = TableHeaderScope.Row;
                tableHeaderCell.Text = (++i).ToString();
                tableRow.Controls.Add(tableHeaderCell);

                TableCell bolumAd = new TableCell();
                bolumAd.Text = bolum.BolumAd;
                tableRow.Controls.Add(bolumAd);


                TableCell butonlar = new TableCell();

                LinkButton lnkBtnSil = new LinkButton();
                lnkBtnSil.ID = "s" + bolum.BolumId.ToString();
                lnkBtnSil.CssClass = "btn btn-danger";
                lnkBtnSil.Click += LnkBtnSil_Click;
                lnkBtnSil.Text = "<i class='fa fa-times'></i>";

                butonlar.Controls.Add(lnkBtnSil);

                tableRow.Controls.Add(butonlar);
                BolumTablosu.Controls.Add(tableRow);
            }
        }

        private void LnkBtnSil_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            int id = Convert.ToInt32(linkButton.ID.Substring(1));
            _bolumId = id;
            string script = "OnayBolumSil();";
            ScriptManager.RegisterStartupScript(this, GetType(), null, script, true);
        }

        protected void btnIslem_Click(object sender, EventArgs e)
        {
            _bolumServis.Sil(_bolumId);
            SayfayiYenile();
        }

        protected void lnkBtnProfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("admin.aspx");
        }

        protected void lnkBtnCikis_Click(object sender, EventArgs e)
        {
            Session.Remove("Admin");
            Response.Redirect("../default.aspx");
        }

        protected void btnBolumEkle_Click(object sender, EventArgs e)
        {
            var fakulteId = cbxFakulteler.SelectedValue;
            _bolumServis.Ekle(new Veriler.Concrete.Bolum { 
            FakulteId=Convert.ToInt32(fakulteId),
            BolumAd=tbxBolumAd.Text
            });
            SayfayiYenile();
        }
        private void SayfayiYenile()
        {
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
    }
}