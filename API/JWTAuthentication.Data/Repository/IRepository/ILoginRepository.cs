using JWTAuthentication.Persistance.Entities;
using System.Collections.Generic;

namespace JWTAuthentication.Persistance.Repository.IRepository
{
    public interface ILoginRepository : IRepository<UserLoginDetails>
    {
    }
}
