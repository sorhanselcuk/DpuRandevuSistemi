using DRS.Is.Abstracts;
using DRS.Is.Concrete;
using DRS.Is.DependencyResolves.Ninject;
using DRS.Is.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace DRS.WebUI
{
    public partial class kayitOl : System.Web.UI.Page
    {
        private IFakulteServis _fakulteServis;
        private IBolumServis _bolumServis;
        private IOgrenciServis _ogrenciServis;
        private IAkademisyenServis _akademisyenServis;
        private IOgrenciGirisServis _ogrenciGirisServis;
        private IAkademisyenGirisServis _akademisyenGirisServis;
        protected void Page_Load(object sender, EventArgs e)
        {
            _fakulteServis = InstanceFactory.GetInstance<IFakulteServis>();
            _bolumServis = InstanceFactory.GetInstance<IBolumServis>();
            _ogrenciServis = InstanceFactory.GetInstance<IOgrenciServis>();
            _akademisyenServis = InstanceFactory.GetInstance<IAkademisyenServis>();
            _ogrenciGirisServis = InstanceFactory.GetInstance<IOgrenciGirisServis>();
            _akademisyenGirisServis = InstanceFactory.GetInstance<IAkademisyenGirisServis>();
           radioBtnAkademisyen.Checked = true;
         //   radioBtnOgrenci.Checked = false;
            if (!IsPostBack)
                FakulteleriYukle();
        }

        private void FakulteleriYukle()
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

        protected void btnKayitOl_Click(object sender, EventArgs e)
        {
            try
            {
                if (radioBtnAkademisyen.Checked == true)
                {
                    AkademisyenKayit();

                }
                else
                {
                    OgrenciKayit();

                }

            }
            catch (SameDataException exception)
            {
                string script = "window.onload = SameDataAlert;";
                ScriptManager.RegisterStartupScript(this,GetType(),null,script,true);
            }
            catch (Exception exception)
            {
               // Eksik bilgi durumlarında fırlatılacak hata
                string script = "window.onload = SameDataAlert2;";
                ScriptManager.RegisterStartupScript(this, GetType(), null, script, true);
            }
        }

        private void OgrenciKayit()
        {
            _ogrenciServis.Ekle(new Veriler.Concrete.Ogrenci
            {
                Ad = tbxAd.Text,
                Soyad = tbxSoyad.Text,
                OgrNo = tbxOgrNo.Text,
                EPosta = tbxEPosta.Text,
                Parola = tbxParola.Text,
                Fakulte = new Veriler.Concrete.Fakulte
                {
                    FakulteId = Convert.ToInt32(cbxFakulteler.SelectedValue)
                },
                Bolum = new Veriler.Concrete.Bolum
                {
                    BolumId = Convert.ToInt32(cbxBolumler.SelectedValue)
                }
            });
            _ogrenciGirisServis.GirisYap(new Veriler.Concrete.GirisBilgileri
            {
                KullaniciAdi = tbxEPosta.Text,
                Parola = tbxParola.Text
            });

            Session["Ogrenci"] = Kullanici.GetInstance().KullaniciId;
            Response.Redirect("ogrenci/profil.aspx");

        }

        private void AkademisyenKayit()
        {
            _akademisyenServis.Ekle(new Veriler.Concrete.Akademisyen
            {
                Ad = tbxAd.Text,
                Soyad = tbxSoyad.Text,
                EPosta = tbxEPosta.Text,
                Parola = tbxParola.Text,
                Fakulte = new Veriler.Concrete.Fakulte
                {
                    FakulteId = Convert.ToInt32(cbxFakulteler.SelectedValue)
                },
                Bolum = new Veriler.Concrete.Bolum
                {
                    BolumId = Convert.ToInt32(cbxBolumler.SelectedValue)
                }
            });
            _akademisyenGirisServis.GirisYap(new Veriler.Concrete.GirisBilgileri
            {
                KullaniciAdi = tbxEPosta.Text,
                Parola = tbxParola.Text
            });

            Session["Akademisyen"] = Kullanici.GetInstance().KullaniciId;
            Response.Redirect("akademisyen/profil.aspx");
        }

        protected void radioBtnAkademisyen_CheckedChanged(object sender, EventArgs e)
        {
            radioBtnOgrenci.Checked = false;
        }

        protected void radioBtnOgrenci_CheckedChanged(object sender, EventArgs e)
        {
            radioBtnAkademisyen.Checked = false;
        }

        protected void cbxFakulteler_TextChanged(object sender, EventArgs e)
        {
            var fakulteId = Convert.ToInt32(cbxFakulteler.SelectedValue);
            BolumYukle(fakulteId);
        }

        private void BolumYukle(int fakulteId)
        {
            var bolumler = _bolumServis.HepsiniGetir(fakulteId);
            cbxBolumler.Items.Clear();
            foreach (var bolum in bolumler)
            {
                cbxBolumler.Items.Add(new ListItem
                {
                    Text = bolum.BolumAd,
                    Value = bolum.BolumId.ToString()
                });
            }
        }
    }
}