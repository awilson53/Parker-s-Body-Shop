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
                WebMail.SmtpServer = ConfigurationManager.AppSettings["SMTPUrl"];
                WebMail.SmtpPort = Convert.ToInt32(ConfigurationManager.AppSettings["SMTPPort"]);
                WebMail.UserName = ConfigurationManager.AppSettings["SMPTUser"];
                WebMail.Password = ConfigurationManager.AppSettings["SMTPPass"];                

                return View();

            }
            catch(Exception ex)
            {

            }
        }
    }
}