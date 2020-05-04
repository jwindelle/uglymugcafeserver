using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UglyMugCafeServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace UglyMugCafeServer.Services
{
    public interface ISignalService
    {
        //Task<bool> SaveSignalAsync(User user);
        Task<User> SaveSignalAsync(User user);
        Task<ActionResult<IEnumerable<User>>> GetUsers();
        Task<ActionResult<User>> DeleteUser(int id);
        Task<ActionResult<User>> UpdateUser(int id, User user);
    }
}
