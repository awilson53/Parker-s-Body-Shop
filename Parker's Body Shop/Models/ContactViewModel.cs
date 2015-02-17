using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parker_s_Body_Shop.Models
{
    public class ContactViewModel
    {
        public string SMTPUrl { get; set; }
        public string ContactEmail { get; set; }
        public string SMTPUser { get; set; }
        public string SMTPPass { get; set; }
    }
}