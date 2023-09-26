using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using YourNamespace.Hubs; // Import your SignalR hub

namespace YourNamespace.Controllers
{
    [Route("api/chat")]
    [ApiController]
    [Authorize] // Require authentication for chat operations
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost("send")]
        public async Task<IActionResult> SendMessage([FromBody] SendMessageDto messageDto)
        {
            try
            {
                // Validate messageDto and get sender information
                var senderId = Guid.Parse(User.Identity.Name); // Assuming user ID is in claims

                // Send the message to the SignalR hub for broadcasting
                await _hubContext.Clients.All.SendAsync("ReceiveMessage", senderId, messageDto.Content);

                return Ok(new { Message = "Message sent successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Failed to send message", Error = ex.Message });
            }
        }
    }
}
