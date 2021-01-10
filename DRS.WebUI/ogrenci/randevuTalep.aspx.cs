using DRS.Is.Abstract;
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
    public partial class randevuTalep : System.Web.UI.Page
    {
        private IFakulteServis _fakulteServis;
        private IBolumServis _bolumServis;
        private IAkademisyenServis _akademisyenServis;
        private IMusaitlikServis _musaitlikServis;
        private IRandevuServis _randevuServis;
        private static int _akademisyenId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Ogrenci"] == null)
                Response.Redirect("../default.aspx");
            var adSoyad = Utilities.GetOgrenciAdSoyad(Convert.ToInt32(Session["Ogrenci"]));
            Page.Title = adSoyad;
            lblKullaniciAdi.Text = adSoyad;
            _fakulteServis = InstanceFactory.GetInstance<IFakulteServis>();
            _bolumServis = InstanceFactory.GetInstance<IBolumServis>();
            _akademisyenServis = InstanceFactory.GetInstance<IAkademisyenServis>();
            _musaitlikServis = InstanceFactory.GetInstance<IMusaitlikServis>();
            _randevuServis = InstanceFactory.GetInstance<IRandevuServis>();
            if(!IsPostBack)
            FakulteYukle();
        }

        private void AkademisyenYukle(int bolumId)
        {
            cbxAkademisyenler.Items.Clear();
            var akademisyenler = _akademisyenServis.HepsiniGetir();
            foreach (var akademisyen in akademisyenler)
            {
                if (akademisyen.Bolum.BolumId != bolumId)
                    continue;
                cbxAkademisyenler.Items.Add(new ListItem
                {
                    Text = akademisyen.Ad + " " + akademisyen.Soyad,
                    Value = akademisyen.AkmId.ToString()
                });
            }
        }

        private void BolumYukle(int fakulteId)
        {
            cbxBolumler.Items.Clear();
            var bolumler = _bolumServis.HepsiniGetir(fakulteId);
            foreach (var bolum in bolumler)
            {
                cbxBolumler.Items.Add(new ListItem
                {
                    Text = bolum.BolumAd,
                    Value = bolum.BolumId.ToString()
                });
            }
        }

        private void FakulteYukle()
        {
            var fakulteler = _fakulteServis.HepsiniGetir();
            foreach (var fakulte in fakulteler)
            {
                cbxFakulteler.Items.Add(new ListItem
                {
                    Text = fakulte.FakulteAd,
                    Value = fakulte.FakulteId.ToString()
                });
            }
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

        protected void btnOlustur_Click(object sender, EventArgs e)
        {
            var fakulte = cbxFakulteler.SelectedValue;
            var bolum = cbxBolumler.SelectedValue;
            var akademisyen = cbxAkademisyenler.SelectedValue;
            var tarih = cbxTarihler.SelectedValue;
            var saat = cbxSaatler.SelectedValue;
            var konu = tbxKonu.Text;
            try
            {
                _randevuServis.Ekle(new Randevu
                {
                    Akademisyen = new Akademisyen { AkmId = Convert.ToInt32(akademisyen) },
                    Ogrenci = new Ogrenci { OgrId = Convert.ToInt32(Session["Ogrenci"]) },
                    Tarih = Convert.ToDateTime(tarih),
                    Saat = new Saat { SaatId = Convert.ToInt32(saat) },
                    Konu = konu
                });
                // Talep başarılı şeklinde alert verilecek
                string script = "window.onload  = basariliTalepAlerti;";
                ScriptManager.RegisterStartupScript(this, GetType(), null, script, true);
            }
            catch (Exception ex)
            {
                // Eksik bilgi alerti fırlatılacak !
                string script = "window.onload  = rendevuTalepAlerti;";
                ScriptManager.RegisterStartupScript(this, GetType(), null, script, true);
            }

        }

        protected void cbxFakulteler_TextChanged(object sender, EventArgs e)
        {
            var fakulteId = int.Parse(cbxFakulteler.SelectedValue);
            BolumYukle(fakulteId);
        }

        protected void cbxBolumler_TextChanged(object sender, EventArgs e)
        {
            var bolumId = int.Parse(cbxBolumler.SelectedValue);
            AkademisyenYukle(bolumId);
        }

        protected void cbxAkademisyenler_TextChanged(object sender, EventArgs e)
        {
            var akademisyenId = int.Parse(cbxAkademisyenler.SelectedValue);
            MusatilikleriYukle(akademisyenId);
        }

        private void MusatilikleriYukle(int akademisyenId)
        {
            cbxTarihler.Items.Clear();
            var tarihler = _musaitlikServis.HepsiniGetir(akademisyenId).Select(p => p.Tarih).Distinct();
            foreach (var musatilik in tarihler)
            {
                cbxTarihler.Items.Add(new ListItem
                {
                    Text = musatilik.ToString("dd MMMM yyyy"),
                    Value = musatilik.ToString()
                });
            }
            _akademisyenId = akademisyenId;
        }

        protected void cbxTarihler_TextChanged(object sender, EventArgs e)
        {
            var tarih = cbxTarihler.SelectedValue;
            SaatleriYukle(tarih, _akademisyenId);
        }

        private void SaatleriYukle(string tarih, int akademisyenId)
        {
            cbxSaatler.Items.Clear();
            var musatilikler = _musaitlikServis.HepsiniGetir(akademisyenId).OrderBy(p => p.Saat.saat);
            foreach (var musaitlik in musatilikler)
            {
                if (!tarih.Equals(musaitlik.Tarih.ToString()))
                    continue;
                cbxSaatler.Items.Add(new ListItem
                {
                    Text = musaitlik.Saat.saat.ToString(),
                    Value = musaitlik.Saat.SaatId.ToString()
                });
            }
        }
    }
}