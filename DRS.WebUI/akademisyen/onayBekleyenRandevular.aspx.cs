using DRS.Is.Abstracts;
using DRS.Is.DependencyResolves.Ninject;
using DRS.Veriler.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DRS.WebUI.akademisyen
{
    public partial class onayBekleyenRandevular : System.Web.UI.Page
    {
        private IRandevuServis _randevuServis;
        private static int _randevuId;
        private static bool _randevuDurum;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Akademisyen"] == null)
                Response.Redirect("../default.aspx");
            _randevuServis = InstanceFactory.GetInstance<IRandevuServis>();
            var adSoyad = Utilities.GetAkademisyenAdSoyad(Convert.ToInt32(Session["Akademisyen"]));
            Page.Title = adSoyad;
            lblKullaniciAdi.Text = adSoyad;
            RandevulariYukle();
        }

        private void RandevulariYukle()
        {
            int i = 0;
            foreach (var randevu in _randevuServis.AkademisyenRandevulariniGetir(Convert.ToInt32(Session["Akademisyen"])))
            {
                if (randevu.AktifMi)
                    continue;
                TableRow tableRow = new TableRow();
                TableHeaderCell tableHeaderCell = new TableHeaderCell();
                tableHeaderCell.Scope = TableHeaderScope.Row;
                tableHeaderCell.Text = (++i).ToString();
                tableRow.Controls.Add(tableHeaderCell);

                TableCell adSoyad = new TableCell();
                adSoyad.Text = randevu.Ogrenci.Ad + " " + randevu.Ogrenci.Soyad;
                tableRow.Controls.Add(adSoyad);

                TableCell tarih = new TableCell();
                tarih.Text = randevu.Tarih.ToString("dd MMMM yyyy");
                tableRow.Controls.Add(tarih);

                TableCell saat = new TableCell();
                saat.Text = randevu.Saat.saat.ToString();
                tableRow.Controls.Add(saat);

                TableCell konu = new TableCell();
                konu.Text = randevu.Konu;
                tableRow.Controls.Add(konu);

                TableCell durum = new TableCell();
                durum.Text = RandevuDurum(randevu.AktifMi);
                tableRow.Controls.Add(durum);

                TableCell butonlar = new TableCell();

                LinkButton lnkBtnOnayla = new LinkButton();
                lnkBtnOnayla.ID = "t" + randevu.RandevuId.ToString();
                lnkBtnOnayla.CssClass = "btn btn-success";
                lnkBtnOnayla.Click += RandevuOnayla_Click;
                lnkBtnOnayla.Text = "<i class='fa fa-check'></i>";

                butonlar.Controls.Add(lnkBtnOnayla);

                LinkButton lnkBtnReddet = new LinkButton();
                lnkBtnReddet.ID = "f" + randevu.RandevuId.ToString();
                lnkBtnReddet.CssClass = "btn btn-danger";
                lnkBtnReddet.Click += RandevuReddet_Click;
                lnkBtnReddet.Text = "<i class='fa fa-times'></i>";

                butonlar.Controls.Add(lnkBtnReddet);

                LinkButton lnkBtnBilgiAl = new LinkButton();
                lnkBtnBilgiAl.ID = "i" + randevu.RandevuId.ToString();
                lnkBtnBilgiAl.CssClass = "btn btn-info";
                lnkBtnBilgiAl.Click += RandevuDetay_Click;
                lnkBtnBilgiAl.Text = "<i class='fa fa-info'></i> ";

                butonlar.Controls.Add(lnkBtnBilgiAl);
                tableRow.Controls.Add(butonlar);
                RandevuTablosu.Controls.Add(tableRow);
            }
        }

        protected void btnIslem_Click(object sender, EventArgs e)
        {
            try { 
            if (_randevuDurum)
                _randevuServis.RandevuKabulEt(_randevuId);
            else
                _randevuServis.RandevuReddet(_randevuId);
            SayfayiYenile();
            }catch(Exception ex)
            {
                string script = "window.onload  = randevuSilmeHatası;";
                ScriptManager.RegisterStartupScript(this, GetType(), null, script, true);
            }
        }

        protected void lnkBtnCikisYap_Click(object sender, EventArgs e)
        {
            Session.Remove("Akademisyen");
            Response.Redirect("../default.aspx");
        }

        protected void lnkbtnProfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("profil.aspx");
        }
        private void RandevuDetay_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            int id = Convert.ToInt32(linkButton.ID.Substring(1));
            var randevu = _randevuServis.Getir(id);
            RandevuDetaylandir(randevu);
            string script = "$('#randevuDetay').modal('show')";
            ScriptManager.RegisterStartupScript(this,GetType(),null,script,true);

        }
        private void RandevuDetaylandir(Randevu randevu)
        {
            string detayTablo = "<table class='table table-striped table-hover'>";

            detayTablo += "<tr>";
            detayTablo += "<td>Öğrenci No : &nbsp;<td>";
            detayTablo += "<td>" + randevu.Ogrenci.OgrNo + "</td>";
            detayTablo += "</tr>";

            detayTablo += "<tr>";
            detayTablo += "<td>Öğrenci : &nbsp;<td>";
            detayTablo += "<td>" + randevu.Ogrenci.Ad + " " + randevu.Ogrenci.Soyad + "</td>";
            detayTablo += "</tr>";

            detayTablo += "<tr>";
            detayTablo += "<td>Bölüm : &nbsp;<td>";
            detayTablo += "<td>" + randevu.Ogrenci.Fakulte.FakulteAd +" / "+ randevu.Ogrenci.Bolum.BolumAd + "</td>";
            detayTablo += "</tr>";

            detayTablo += "<tr>";
            detayTablo += "<td>Konu : &nbsp;<td>";
            detayTablo += "<td>" + randevu.Konu + "</td>";
            detayTablo += "</tr>";

            detayTablo += "<tr>";
            detayTablo += "<td>Tarih : &nbsp;<td>";
            detayTablo += "<td>" + randevu.Tarih.ToString("dd MMMM yyyy") + "</td>";
            detayTablo += "</tr>";

            detayTablo += "<tr>";
            detayTablo += "<td>Saat : &nbsp;<td>";
            detayTablo += "<td>" + randevu.Saat.saat + "</td>";
            detayTablo += "</tr>";

            detayTablo += "<tr>";
            detayTablo += "<td>Durum : &nbsp;<td>";
            string durum = "Randevu Onay Bekliyor";
            if (randevu.AktifMi) { durum = "Randevu Onaylanmış"; }

            detayTablo += "<td>" + durum + "</td>";
            detayTablo += "</tr>";
            detayTablo += "</table>";
            literalRandevuDetay.Text = detayTablo;
        }

        private void RandevuOnayla_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            int id = Convert.ToInt32(linkButton.ID.Substring(1));
            ScriptManager.RegisterStartupScript(this, GetType(), null, "KabulEt();", true);
            _randevuId = id;
            _randevuDurum = true;
        }
        private void RandevuReddet_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            int id = Convert.ToInt32(linkButton.ID.Substring(1));
            ScriptManager.RegisterStartupScript(this, GetType(), null, "IptalEt();", true);
            _randevuId = id;
            _randevuDurum = false;
        }

        private string RandevuDurum(bool aktifMi)
        {
            if (aktifMi)
                return "<i style='color: green;' class = 'fa fa-check'></i>";
            else
                return "<i style='color: darkorange;' class = 'fa fa-clock-o'></i>";
        }
        private void SayfayiYenile()
        {
            Page.Response.Redirect(Page.Request.Url.ToString());
        }
    }
}