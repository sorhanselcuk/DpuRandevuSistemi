using DRS.Is.Abstract;
using DRS.Is.Abstracts;
using DRS.Is.DependencyResolves.Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DRS.WebUI.akademisyen
{
    public partial class musaitliklik : System.Web.UI.Page
    {
        private ISaatServis _saatServis;
        private IMusaitlikServis _musaitlikServis;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Akademisyen"] == null)
                Response.Redirect("../default.aspx");
           
            var adSoyad = Utilities.GetAkademisyenAdSoyad(Convert.ToInt32(Session["Akademisyen"]));
            lblKullaniciAdi.Text = adSoyad;
            _saatServis = InstanceFactory.GetInstance<ISaatServis>();
            _musaitlikServis = InstanceFactory.GetInstance<IMusaitlikServis>();
            Page.Title = adSoyad;
            if (!IsPostBack)
            {
                TarihleriYuke();
                SaatlerYukle();
            }
        }

        private void TarihleriYuke()
        {
            DateTime dateTime = DateTime.Today;
            for (int i = 0; i < 14; i++)
            {
                DateTime gun = dateTime.AddDays(i);
                cbxTarihler.Items.Add(new ListItem { 
                Text=gun.ToString("dd MMMM yyyy"),
                Value=gun.ToString()
                });
            }
        }

        private void SaatlerYukle()
        {
            var saatler = _saatServis.HepsiniGetir();
            foreach (var saat in saatler)
            {
                cbxSaatler.Items.Add(new ListItem { 
                Text=saat.saat.ToString(),
                Value=saat.SaatId.ToString()
                });
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

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            var tarih = cbxTarihler.SelectedValue;
            var saatId = cbxSaatler.SelectedValue.ToString();
            try { 
            _musaitlikServis.Ekle(new Veriler.Concrete.Musaitlik { 
            Akademisyen= new Veriler.Concrete.Akademisyen { AkmId= Convert.ToInt32(Session["Akademisyen"]) },
            Tarih=Convert.ToDateTime(tarih),
            Saat=new Veriler.Concrete.Saat { SaatId=Convert.ToInt32(saatId) }
            });
                // Eklendi olarak alert
            string script = "window.onload  = musaitlikAlerti;";
            ScriptManager.RegisterStartupScript(this, GetType(), null, script, true);
            }
            catch(Exception exception)
            {
                // Js uyarı 
                string script = "window.onload  = musaitlikHataAlerti;";
                ScriptManager.RegisterStartupScript(this, GetType(), null, script, true);
            }
        }
    }
}