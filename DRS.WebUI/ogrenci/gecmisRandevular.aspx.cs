using DRS.Is.Abstract;
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
    public partial class gecmisRandevular : System.Web.UI.Page
    {
        private IGecmisRandevuServis _gecmisRandevuServis;
        private static int _randevuId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Ogrenci"] == null)
                Response.Redirect("../default.aspx");
            _gecmisRandevuServis = InstanceFactory.GetInstance<IGecmisRandevuServis>();
            var adSoyad = Utilities.GetOgrenciAdSoyad(Convert.ToInt32(Session["Ogrenci"]));
            Page.Title = adSoyad;
            lblKullaniciAdi.Text = adSoyad;
            RandevulariYukle();
        }

        private void RandevulariYukle()
        {
           
            var gecmisRandevular = _gecmisRandevuServis.OgrenciGecmisRandevuHepsiniGetir(Convert.ToInt32(Session["Ogrenci"]));
            int i = 0;
            foreach (var randevu in gecmisRandevular)
            {
              
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
                saat.Text = randevu.Saat.ToString();
                tableRow.Controls.Add(saat);

                TableCell konu = new TableCell();
                konu.Text = randevu.Konu;
                tableRow.Controls.Add(konu);

                TableCell butonlar = new TableCell();


                LinkButton lnkBtnBilgiAl = new LinkButton();
                lnkBtnBilgiAl.ID = "i" + randevu.Id.ToString();
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
            
            var randevu = _gecmisRandevuServis.GecmisRandevuGetir(id);
            RandevuDetaylandir(randevu);

            string script = "$('#randevuDetay').modal('show')";
            ScriptManager.RegisterStartupScript(this, GetType(), null, script, true);

            // Buraya script yazılacak ve randevu detay modalı açılacak 
        }

        private void RandevuDetaylandir(GecmisRandevu randevu)
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
            detayTablo += "<td>" + randevu.Saat + "</td>";
            detayTablo += "</tr>";


            detayTablo += "</table>";
            literalRandevuDetay.Text = detayTablo;
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

       
    }
}
