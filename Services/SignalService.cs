using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UglyMugCafeServer.Services;
using UglyMugCafeServer.Models;
using UglyMugCafeServer.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace UglyMugCafeServer.Services
{
    public class SignalService : ISignalService
    {
        private readonly MainDbContext _context;

        public SignalService(MainDbContext context)
        {
            _context = context;
        }

        //public async Task<bool> SaveSignalAsync(User user)
        //{
        //    try
        //    {
        //        User _user = new User();
        //            _user.Name = user.Name;
        //            _user.Type = user.Type;
        //            _user.Orders = user.Orders;
        //            _user.Status = user.Status;

        //        _context.Users.Add(_user);

        //        var t = await _context.SaveChangesAsync();

        //        return t > 0;
        //    }
        //    catch (Exception exception)
        //    {
        //        return false;
        //    }
        //}

        public async Task<User> SaveSignalAsync(User user)
        {
            try
            {
                User _user = new User();
                _user.Name = user.Name;
                _user.Type = user.Type;
                _user.Orders = user.Orders;
                _user.Status = user.Status;

                _context.Users.Add(_user);

                var t = await _context.SaveChangesAsync();

                return _user;
            }
            catch (Exception exception)
            {
                return null;
            }
        }

        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<ActionResult<User>> UpdateUser(int id, User user)
        {
            if (id != user.Id)
            {
                return null;
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }

            return user;
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
