using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;

namespace Parker_s_Body_Shop.Models
{
    public class ContactRequestViewModel
    {
        [DisplayName("First Name")]
        public string FirstName { get; set; }

        [DisplayName("Last Name")]
        public string LastName { get; set; }

        [DisplayName("Email Address")]        
        public string Email { get; set; }

        [DisplayName("Phone Number")]
        public string PhoneNumber { get; set; }

        [DisplayName("Message")]
        public string Message { get; set; }
    }
}