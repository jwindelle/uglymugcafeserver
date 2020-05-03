using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UglyMugCafeServer.Services;
using UglyMugCafeServer.Models;
using UglyMugCafeServer.Persistence;


namespace UglyMugCafeServer.Services
{
    public class SignalService : ISignalService
    {
        private readonly MainDbContext _context;

        public SignalService(MainDbContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveSignalAsync(User user)
        {
            try
            {
                User studentInfo = new User();
                studentInfo.Name = user.Name;

                _context.Users.Add(studentInfo);

                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception exception)
            {
                return false;
            }
        }
    }
}
