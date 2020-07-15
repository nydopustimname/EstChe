using MimeKit;
using MailKit.Net.Smtp;
using System.Threading.Tasks;
using MailKit;
using System;
using System.Web.Mvc;

namespace EstChe.Areas.User.Controllers
{
    public class HelpController : Controller
    {
        // GET: User/Help
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Help(string info)
        {
            info = $" {info}";
            var emailMess = new MimeMessage();
            emailMess.From.Add(new MailboxAddress("tanya.kavretskaya@mail.ru"));
            emailMess.To.Add(new MailboxAddress("t.a.dubkovskaya@gmail.com"));
            emailMess.Subject = "Usser Info";

            emailMess.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = info
            };

            using (var client = new SmtpClient())
            {
                //client.Connect()
                client.Connect("smtp.mail.ru", 465, true);
                client.Authenticate("tanya.kavretskaya@mail.ru", "KakTiZaebal568*");
                client.Send(emailMess);
                client.Disconnect(true);
            }
            return RedirectToAction("Done");
        }

        public ActionResult Done()
        {
            return View();
        }
    }
}