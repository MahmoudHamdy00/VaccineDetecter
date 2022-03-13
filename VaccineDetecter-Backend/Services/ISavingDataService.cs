using VaccineDetecter_Backend.Models.ModelDTO;

namespace VaccineDetecter_Backend.Services
{
    public interface ISavingDataService
    {
        Task<bool> SaveData(DataDTO data);
    }
}