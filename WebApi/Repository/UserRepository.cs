using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DataContext;
using WebApi.Interface;

namespace WebApi.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApiDbContext _Context;
        public UserRepository(ApiDbContext context)
        {
            _Context = context;
        }
        public async Task<User> AddUser(User user)
        {
            var result = await _Context.Users.AddAsync(user);
            await _Context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<User> DeleteUser(int Id)
        {
            var result = await _Context.Users.Where(a => a.Id == Id).FirstOrDefaultAsync();
            if (result != null)
            {
                _Context.Users.Remove(result);
                await _Context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<User> GetUser(int Id)
        {
          return  await _Context.Users.Where(a => a.Id == Id).FirstOrDefaultAsync();
           
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _Context.Users.ToListAsync();
        }

        public async Task<IEnumerable<User>> Search(string FirstName)
        {
            IQueryable<User> query = _Context.Users;
            if (!string.IsNullOrEmpty(FirstName))
            {
                query = query.Where(a => a.FirstName.Contains(FirstName));
            }
            return await query.ToListAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            var result = await _Context.Users.Where(a => a.Id == user.Id).FirstOrDefaultAsync();
            if (result != null)
            { 
                result.FirstName = user.FirstName;
                result.LastName = user.LastName;
                result.Age = user.Age;
                result.Email = user.Email;
                result.Password = user.Password;
                _Context.SaveChanges();
                return result;
            }
            return null;
        }
    }
}
