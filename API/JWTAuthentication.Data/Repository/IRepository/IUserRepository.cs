using JWTAuthentication.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuthentication.Persistance.Repository.IRepository
{
    public interface IUserRepository
    {
        Task CreateUser(AppUser user);
        Task<bool> UserExits(string username);
        Task<AppUser> GetUserDetails(AppUser user);
        //Task UpdateUser(User user);
    }
}
