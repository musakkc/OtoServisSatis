using OtoServisSatis.Entities;
using System.Net;
using System.Net.Mail;

namespace OtoServisSatis.WebUI.Utils
{
    public class MailHelper
    {
        public static async Task SendMailAsync(Musteri musteri)
        {
            SmtpClient smtpClient = new SmtpClient("mail.siteadresi.com", 587); // mail göndermek için gerekli yapı
            smtpClient.Credentials = new NetworkCredential("MuSa KOC", "musa__bjk1903");
            smtpClient.EnableSsl = true; //Email gelmedi için true
            MailMessage message = new MailMessage();
            message.From = new MailAddress("info@siteadi.com");
            message.To.Add("info@siteadi.com");
            //message.To.Add("bilgi@siteadi.com");
            message.Subject = "Siteden mesaj geldi";
            message.Body = $"Mail Bilgileri <hr/> Ad Soyad : {musteri.Adi} {musteri.Soyadi} <hr/> İlgilendiği Araç Id : {musteri.AracId} <hr/> Email : {musteri.Email} <hr/> Telefon : {musteri.Telefon} <hr/> Notlar : {musteri.Notlar}";
            message.IsBodyHtml = true;
            //smtpClient.Send(message);
            await smtpClient.SendMailAsync(message);
            smtpClient.Dispose();
        }
    }
}
