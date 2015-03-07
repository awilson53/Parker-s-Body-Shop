using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
using System.Net.Mail;
using Parker_s_Body_Shop.Models;

namespace Parker_s_Body_Shop.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Contact()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult SubmitContact(ContactRequestViewModel contactInfo)
        {
            try
            {               
                var smtp = new SmtpClient
                {
                    Host = ConfigurationManager.AppSettings["SMTPServer"],
                    Port = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPort"]),
                    EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["SMTPUseSSL"]),
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(ConfigurationManager.AppSettings["SMPTUser"], ConfigurationManager.AppSettings["SMTPPass"])
                };

                var fromAddress = new MailAddress(ConfigurationManager.AppSettings["SMTPFromAddress"], "Website Contact");
                var toAddress = new MailAddress(ConfigurationManager.AppSettings["ContactEmail"]);

                using(var message = new MailMessage(fromAddress, toAddress))
                {
                    message.Subject = ConfigurationManager.AppSettings["SMTPSubject"];
                    message.Body = "You have received a message from the website:" + "\n" +
                        "First Name: " + contactInfo.FirstName.CheckProvided() + "\n" +
                        "Last Name: " + contactInfo.LastName.CheckProvided() + "\n" +
                        "Email: " + contactInfo.Email.CheckProvided() + "\n" +
                        "Phone Number: " + contactInfo.PhoneNumber.CheckProvided() + "\n" +
                        "Message: " + contactInfo.Message.CheckProvided();

                    smtp.Send(message);
                }

                //WebMail.SmtpServer = ConfigurationManager.AppSettings["SMTPServer"];
                //WebMail.SmtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPort"]);
                //WebMail.UserName = ConfigurationManager.AppSettings["SMPTUser"];
                //WebMail.Password = ConfigurationManager.AppSettings["SMTPPass"];
                //WebMail.From = ConfigurationManager.AppSettings["SMTPFromAddress"];
                //WebMail.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["SMTPUseSSL"]);                
                //string to = ConfigurationManager.AppSettings["ContactEmail"];
                //string subject = ConfigurationManager.AppSettings["SMTPSubject"];
                //string body = "You have received a message from the website:" + "\n" +
                //    "First Name: " + contactInfo.FirstName.CheckProvided() + "\n" +
                //    "Last Name: " + contactInfo.LastName.CheckProvided() + "\n" +
                //    "Email: " + contactInfo.Email.CheckProvided() + "\n" +
                //    "Phone Number: " + contactInfo.PhoneNumber.CheckProvided() + "\n" +
                //    "Message: " + contactInfo.Message.CheckProvided();

                //WebMail.Send(to, subject, body);

                return View();

            }
            catch(Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                ViewBag.StackTrace = ex.StackTrace;
                return View();
            }
        }


    }    

    public static class Extensions
    {
        public static string CheckProvided(this String str)
        {
            if (str != null && str.Length > 0)
            {
                return str;
            }
            else
            {
                return "Not Provided";
            }
        }
    }
}