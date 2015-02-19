using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Parker_s_Body_Shop.Models
{
    public class ContactViewModel
    {
        public int ContactViewModelId { get; set; }
        public string SMTPUrl { get; set; }
        public string ContactEmail { get; set; }
        public string SMTPUser { get; set; }
        public string SMTPPass { get; set; }
    }

    public class ContactViewModelContext : DbContext
    {
        public System.Data.Entity.DbSet<Parker_s_Body_Shop.Models.ContactViewModel> ContactViewModels { get; set; }
    }
}
