using VaccineDetecter_Backend.Models;
using VaccineDetecter_Backend.Models.ModelDTO;

namespace VaccineDetecter_Backend.Services
{
    public interface ISavingDataService
    {
        Task<Response> SaveData(DataDTO data);
    }
}