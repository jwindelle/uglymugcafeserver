using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UglyMugCafeServer.Models;


namespace UglyMugCafeServer.Services
{
    public interface ISignalService
    {
        Task<bool> SaveSignalAsync(User user);
    }
}
