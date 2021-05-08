using JWTAuthentication.Persistance.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuthentication.Persistance.Repository.IRepository
{
    public interface IUserRepository
    {
        Task CreateUser(User user);
        Task UpdateUser(User user);
    }
}
