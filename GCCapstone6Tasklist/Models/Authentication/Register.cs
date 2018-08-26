using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GCCapstone6Tasklist.Models.Authentication
{
    public class Register 
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }
}