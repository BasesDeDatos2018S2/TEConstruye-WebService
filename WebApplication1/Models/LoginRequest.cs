using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class LoginRequest
    {
        public string ssn { get; set; }
        public string password { get; set; }
    }
}