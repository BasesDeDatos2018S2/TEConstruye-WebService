﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class LoginRequest
    {
        public int id_employee { get; set; }
        public string password { get; set; }
    }
}