using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VaccineDetecter_Backend.Models;
using VaccineDetecter_Backend.Models.ModelDTO;
using VaccineDetecter_Backend.Services;
using VaccineDetecter_Backend.Utility;

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
        public IActionResult Save([FromBody] DataDTO data) {
            if (!Validator.IsValidEmail(data.person.Email)) {
                var ret = new Response();
                ret.Succeeded = false;
                ret.Errors.Add(new Error() { Code = "EmailIsIncorrect" });
                return BadRequest(ret);
            }
            var res = _savingDataService.SaveData(data);
            if (res.Succeeded) {
                _emailSenderService.SendEmail(data.person.Email, data.Message.MessageSubject, data.Message.MessageBody);
                return Ok(res.Succeeded);
            }
            else return BadRequest(res.Errors);
        }
    }
}
