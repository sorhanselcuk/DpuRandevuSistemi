using DRS.Is.Abstracts;
using DRS.Is.DependencyResolves.Ninject;
using DRS.Veriler.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DRS.WebUI.ogrenci
{
    public partial class onayBekleyenRandevular : System.Web.UI.Page
    {
        private IRandevuServis _randevuServis;
        private static int _randevuId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Ogrenci"] == null)
                Response.Redirect("../default.aspx");
            _randevuServis = InstanceFactory.GetInstance<IRandevuServis>();
            var adSoyad = Utilities.GetOgrenciAdSoyad(Convert.ToInt32(Session["Ogrenci"]));
            lblKullaniciAdi.Text = adSoyad;
            Page.Title = adSoyad;
            RandevulariYukle();
        }

        private void RandevulariYukle()
        {
            int i = 0;
            foreach (var randevu in _randevuServis.OgrenciRandevulariniGetir(Convert.ToInt32(Session["Ogrenci"])))
            {
                if (randevu.AktifMi)
                    continue;
                TableRow tableRow = new TableRow();
                TableHeaderCell tableHeaderCell = new TableHeaderCell();
                tableHeaderCell.Scope = TableHeaderScope.Row;
                tableHeaderCell.Text = (++i).ToString();
                tableRow.Controls.Add(tableHeaderCell);

                TableCell adSoyad = new TableCell();
                adSoyad.Text = randevu.Akademisyen.Ad + " " + randevu.Akademisyen.Soyad;
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
                durum.Text = "<i style='color: darkorange;' class = 'fa fa-clock-o'></i>";
                tableRow.Controls.Add(durum);

                TableCell butonlar = new TableCell();

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

        private void RandevuDetay_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            int id = Convert.ToInt32(linkButton.ID.Substring(1));
            var randevu = _randevuServis.Getir(id);
            RandevuDetaylandir(randevu);

            string script = "$('#randevuDetay').modal('show')";
            ScriptManager.RegisterStartupScript(this, GetType(), null, script, true);

            // randevu detay modalı açılacak
        }

        private void RandevuDetaylandir(Randevu randevu)
        {
            string detayTablo = "<table class='table table-striped table-hover'>";

            detayTablo += "<tr>";
            detayTablo += "<td>Akademisyen : &nbsp;<td>";
            detayTablo += "<td>" + randevu.Akademisyen.Ad + " " + randevu.Akademisyen.Soyad + "</td>";
            detayTablo += "</tr>";

            detayTablo += "<tr>";
            detayTablo += "<td>Bölüm : &nbsp;<td>";
            detayTablo += "<td>" + randevu.Akademisyen.Fakulte.FakulteAd + " / " + randevu.Akademisyen.Bolum.BolumAd + "</td>";
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
            detayTablo += "<td>" + randevu.Saat.saat.ToString() + "</td>";
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

        private void RandevuReddet_Click(object sender, EventArgs e)
        {
            LinkButton linkButton = (LinkButton)sender;
            int id = Convert.ToInt32(linkButton.ID.Substring(1));
            _randevuId = id;
            string script = "IptalEt();";
            ScriptManager.RegisterStartupScript(this, GetType(), null, script, true);

            // Onaylanırsa btnIslem'in click eventi çalıştırılacak
        }

        protected void lnkBtnCikisYap_Click(object sender, EventArgs e)
        {
            Session.Remove("Ogrenci");
            Response.Redirect("../default.aspx");
        }

        protected void lnkbtnProfil_Click(object sender, EventArgs e)
        {
            Response.Redirect("profil.aspx");
        }

        protected void btnIslem_Click(object sender, EventArgs e)
        {
            try
            {
                _randevuServis.Sil(_randevuId);
                Page.Response.Redirect(Page.Request.Url.ToString());
            }
            catch (Exception exception)
            {
                // alert ile randevu silme hatası verilecek !
                string script = "window.onload  = randevuSilmeHatası;";
                ScriptManager.RegisterStartupScript(this, GetType(), null, script, true);
            }
        }
    }
}