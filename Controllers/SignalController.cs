using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UglyMugCafeServer.Models;
using UglyMugCafeServer.Services;
using UglyMugCafeServer.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Cors;

namespace UglyMugCafeServer.Controllers
{
    [Route("api/v1/signals")]
    [ApiController]
    public class SignalController : ControllerBase
    {
        private readonly ISignalService _signalService;
        private readonly IHubContext<SignalHub> _hubContext;
        public SignalController(ISignalService signalService, IHubContext<SignalHub> hubContext)
        {
            _signalService = signalService;
            _hubContext = hubContext;
        }

        //[EnableCors("CorsPolicy")]
        [HttpGet]
        [Route("all")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(bool))]
        public async Task<IActionResult> GetAll()
        {
            ActionResult<IEnumerable<User>> res = await _signalService.GetUsers();

            //if (res != null)
            //{
                await _hubContext.Clients.All.SendAsync("SignalMessageReceived", res);
            //}


            return StatusCode(200, res);
        }

        //[EnableCors("CorsPolicy")]
        [HttpPost]
        [Route("order")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(bool))]
        public async Task<IActionResult> SignalArrived(User user)
        {
            //var saveResult = await _signalService.SaveSignalAsync(user);
            var usr = await _signalService.SaveSignalAsync(user);
            ActionResult<IEnumerable<User>> res;

            if (usr != null)
            {
                //SignalViewModel signalViewModel = new SignalViewModel
                //{
                //    Id = user.Id,
                //    Name = user.Name,
                //    Type = user.Type,
                //    Orders = user.Orders,
                //    SignalStamp = Guid.NewGuid().ToString()
                //};

                //await _hubContext.Clients.All.SendAsync("SignalMessageReceived", signalViewModel);

                res = await _signalService.GetUsers();
                await _hubContext.Clients.All.SendAsync("SignalMessageReceived", res);
            }

            //return StatusCode(200, saveResult);
            //return StatusCode(200, user);
            return StatusCode(200, usr);
        }

        //[EnableCors("CorsPolicy")]
        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(bool))]
        public async Task<IActionResult> SignalDelete(int id)
        {
            ActionResult<User> user = await _signalService.DeleteUser(id);
            ActionResult<IEnumerable<User>> res;

            if (user != null)
            {
                res = await _signalService.GetUsers();
                await _hubContext.Clients.All.SendAsync("SignalMessageReceived", res);
            }

            return StatusCode(200, user);
        }

        //[EnableCors("CorsPolicy")]
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(bool))]
        public async Task<IActionResult> SignalUpdate(int id, User usr)
        {
            ActionResult<User> user = await _signalService.UpdateUser(id, usr);
            ActionResult<IEnumerable<User>> res;

            if (user != null)
            {
                res = await _signalService.GetUsers();
                await _hubContext.Clients.All.SendAsync("SignalMessageReceived", res);
            }

            return StatusCode(200, user);
        }


    }
}