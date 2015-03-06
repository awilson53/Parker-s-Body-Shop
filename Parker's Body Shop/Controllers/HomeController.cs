using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Helpers;
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
                WebMail.SmtpServer = ConfigurationManager.AppSettings["SMTPServer"];
                WebMail.SmtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPort"]);
                WebMail.UserName = ConfigurationManager.AppSettings["SMPTUser"];
                WebMail.Password = ConfigurationManager.AppSettings["SMTPPass"];
                WebMail.From = ConfigurationManager.AppSettings["SMTPFromAddress"];
                WebMail.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["SMTPUseSSL"]);
                

                string to = ConfigurationManager.AppSettings["ContactEmail"];
                string subject = ConfigurationManager.AppSettings["SMTPSubject"];
                string body = "You have received a message from the website:" + "\n" +
                    "First Name: " + contactInfo.FirstName.CheckProvided() + "\n" +
                    "Last Name: " + contactInfo.LastName.CheckProvided() + "\n" +
                    "Email: " + contactInfo.Email.CheckProvided() + "\n" +
                    "Phone Number: " + contactInfo.PhoneNumber.CheckProvided() + "\n" +
                    "Message: " + contactInfo.Message.CheckProvided();

                WebMail.Send(to, subject, body);

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