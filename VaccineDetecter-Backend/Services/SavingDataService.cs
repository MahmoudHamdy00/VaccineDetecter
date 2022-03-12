using VaccineDetecter_Backend.Data;
using VaccineDetecter_Backend.Models;
using VaccineDetecter_Backend.Models.ModelDTO;

namespace VaccineDetecter_Backend.Services
{
    public class SavingDataService : ISavingDataService
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public SavingDataService(ApplicationDbContext applicationDbContext) {
            _applicationDbContext = applicationDbContext;
        }
        public async Task<bool> SaveData(DataDTO data) {
            try {
                var person = new Person() {
                    NationalId = data.person.NationalId,
                    Name = data.person.Name,
                    Age = data.person.Age,
                    Gender = data.person.Gender,
                    Email = data.person.Email,
                    MobileNumber = data.person.MobileNumber,
                };
                var nationalId = await AddPerson(person);

                var test = new MedicalTest() {
                    WhiteBloodCell = data.Test.WhiteBloodCell,
                    RedBloodCell = data.Test.RedBloodCell,
                    TestDate = data.Test.TestDate,
                    PersonId = person.NationalId
                };
                await _applicationDbContext.Tests.AddAsync(test);
                await _applicationDbContext.SaveChangesAsync();
            }
            catch (Exception ex) {
                return false;
            }
            return true;
        }
        public async Task<string> AddPerson(Person person) {
            try {
                var res = await _applicationDbContext.Persons.FindAsync(person.NationalId);
                if (res == null) {
                    await _applicationDbContext.Persons.AddAsync(person);
                    await _applicationDbContext.SaveChangesAsync();
                    return person.NationalId;
                }
                return res.NationalId;
            }
            catch (Exception ex) {
                return "-1";
            }
        }
    }
}
