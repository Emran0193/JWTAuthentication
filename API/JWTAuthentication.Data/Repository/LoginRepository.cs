using JWTAuthentication.Persistance.Context;
using JWTAuthentication.Persistance.Entities;
using JWTAuthentication.Persistance.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuthentication.Persistance.Repository
{
    public class LoginRepository : Repository<UserLoginDetails>,ILoginRepository
    {
        private readonly DBContext _context;
        public LoginRepository(DBContext context) : base(context)
        {
            _context = context;
        }
    }
}
