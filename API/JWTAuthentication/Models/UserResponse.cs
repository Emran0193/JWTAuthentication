﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuthentication.Models
{
    public class UserResponse
    {
        public string UserName { get; set; }
        public string Token { get; set; }
    }
}
