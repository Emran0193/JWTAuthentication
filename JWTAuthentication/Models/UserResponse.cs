using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuthentication.Models
{
    public class UserResponse : User
    {
        public int UserId { get; set; }
    }
}
