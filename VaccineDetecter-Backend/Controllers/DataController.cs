using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VaccineDetecter_Backend.Models.ModelDTO;
using VaccineDetecter_Backend.Services;

namespace VaccineDetecter_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly ISavingDataService _savingDataService;
        private readonly IEmailSenderService _emailSenderService;

        public DataController(ISavingDataService savingDataService, IEmailSenderService emailSenderService) {
            _savingDataService = savingDataService;
            _emailSenderService = emailSenderService;
        }
        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] DataDTO data) {
            var res = await _savingDataService.SaveData(data);
            if (res.Succeeded) {
                _emailSenderService.SendEmail(data.person.Email, data.Message.MessageSubject, data.Message.MessageBody);
                return Ok(res.Succeeded);
            }
            else return BadRequest(res.Errors);
        }
    }
}
