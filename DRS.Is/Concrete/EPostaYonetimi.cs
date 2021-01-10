using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using DRS.Is.Abstracts;
using DRS.Veriler.Concrete;
using System.Net;

namespace DRS.Is.Concrete
{
     class EPostaYonetimi : IEPostaServis
    {
        private string _mailKonu;
        private string _mailIcerik;
        private string _ogrenciMail;
        public void RandevuKabulEPostaGonder(Randevu randevu)
        {
            _ogrenciMail = randevu.Ogrenci.EPosta;
            _mailKonu = "Randevunuz Talebiniz Onaylanmıştır.";
            _mailIcerik = "Sayın : " + randevu.Ogrenci.Ad + " " + randevu.Ogrenci.Soyad;
            _mailIcerik += " " + randevu.Tarih.ToString("dd MMMM yyyy") + " " + randevu.Saat.saat.ToString()
                + " tarihinde " + randevu.Akademisyen.Ad + " " + randevu.Akademisyen.Soyad
                + " ile "+randevu.Konu+" konulu olan randevu talebiniz kabul edilmiştir. Lütfen randevu saatini geciktirmeyiniz.";
            
            EPostaGonder();
        }
        
        public void RandevuRedEPostaGonder(Randevu randevu)
        {
            _ogrenciMail = randevu.Ogrenci.EPosta;
            _mailKonu = "Randevunuz Talebiniz Reddedilmiştir.";
            _mailIcerik = "Sayın : " + randevu.Ogrenci.Ad + " " + randevu.Ogrenci.Soyad;
            _mailIcerik += " " + randevu.Tarih.ToString("dd MMMM yyyy") + " " + randevu.Saat.saat.ToString()
                + " tarihinde " + randevu.Akademisyen.Ad + " " + randevu.Akademisyen.Soyad
                + " ile "+randevu.Konu+" konulu olan randevu talebiniz reddedilmiştir.";

            EPostaGonder();
        }
        
        private void EPostaGonder()
        {
            SmtpClient smtpClient = new SmtpClient();
            smtpClient.Host = "smtp.gmail.com";
            smtpClient.Port =587;
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = new NetworkCredential("dpurandevusistem@gmail.com","dpurandevusistem123");
            smtpClient.EnableSsl = true;
            MailMessage mailMessage = new MailMessage("dpurandevusistem@gmail.com", _ogrenciMail);
            mailMessage.IsBodyHtml = true;
            mailMessage.Subject = _mailKonu;
            mailMessage.Body = _mailIcerik;
            mailMessage.BodyEncoding = UTF8Encoding.UTF8;
            mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
            smtpClient.Send(mailMessage);
        }
       
    }
}
