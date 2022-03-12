using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VaccineDetecter_Backend.Models;
using VaccineDetecter_Backend.Services;

namespace VaccineDetecter_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSenderService _emailSenderService;
        public EmailController(IEmailSenderService emailSenderService) {
            _emailSenderService = emailSenderService;
        }
        [HttpPost("sendMail")]
        public async Task<IActionResult> SignUp([FromBody] Message message) {
            _emailSenderService.SendEmail(message.email, message.MessageSubject, message.MessageBody);
            return Ok();
        }
    }
}
