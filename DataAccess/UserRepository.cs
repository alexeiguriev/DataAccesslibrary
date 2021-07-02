using DataAccesslibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesslibrary.DataAccess
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        public UserRepository(UserContext context)
        {
            _context = context;
        }
        public async Task<UserModel> Create(UserModel user)
        {
            _context.User.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }
        public async Task Delete(int id)
        {
            var userToDelete = await _context.User.FindAsync(id);
            _context.User.Remove(userToDelete);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<UserModel>> Get()
        {
            return await _context.User.ToListAsync();
        }
        public async Task<UserModel> Get(int id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task Update(UserModel user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
