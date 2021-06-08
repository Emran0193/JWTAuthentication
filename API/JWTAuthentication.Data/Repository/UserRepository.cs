using JWTAuthentication.Persistance.Context;
using JWTAuthentication.Persistance.Entities;
using JWTAuthentication.Persistance.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTAuthentication.Persistance.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DBContext _context;
        public UserRepository(DBContext context)
        {
            _context = context;
        }
        public async Task CreateUser(AppUser user)
        {
            await _context.AppUsers.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> UserExits(string username)
        {
            return await _context.AppUsers.AnyAsync(x => x.UserName == username.ToLower());
        }
        public async Task<AppUser> GetUserDetails(AppUser user)
        {
            return await _context.AppUsers.SingleOrDefaultAsync(x => x.UserName == user.UserName);
        }
        public async Task<List<AppUser>> GetAll()
        {
            return await _context.AppUsers.ToListAsync();
        }

        public async Task<AppUser> GetUser(int id)
        {
            return await _context.AppUsers.FindAsync(id);
        }
    }
}
