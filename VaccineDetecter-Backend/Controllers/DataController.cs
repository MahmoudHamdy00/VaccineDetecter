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

        public DataController(ISavingDataService savingDataService) {
            _savingDataService = savingDataService;
        }
        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] DataDTO data) {
            var res = await _savingDataService.SaveData(data);
            if (res.Succeeded) {
                return Ok(res.Succeeded);
            }
            else return BadRequest(res.Errors);
        }
    }
}
