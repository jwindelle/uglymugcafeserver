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

        [HttpPost]
        [Route("deliveryPoint")]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(bool))]
        public async Task<IActionResult> SignalArrived(User user)
        {
            var saveResult = await _signalService.SaveSignalAsync(user);

            if (saveResult)
            {
                SignalViewModel signalViewModel = new SignalViewModel
                {
                    Name = user.Name,
                    SignalStamp = Guid.NewGuid().ToString()
                };

                await _hubContext.Clients.All.SendAsync("SignalMessageReceived", signalViewModel);
            }

            return StatusCode(200, saveResult);
        }
    }
}