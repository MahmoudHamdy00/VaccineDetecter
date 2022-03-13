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
        public async Task<Response> SaveData(DataDTO data) {
            var ret = new Response();
            try {
                var person = new Person() {
                    NationalId = data.person.NationalId,
                    Name = data.person.Name,
                    Age = data.person.Age,
                    Gender = data.person.Gender,
                    Email = data.person.Email,
                    MobileNumber = data.person.MobileNumber,
                };
                var AddPersonResult = await AddPerson(person);
                if (!AddPersonResult.Succeeded) {
                    ret.Succeeded = false;
                    ret.Errors = AddPersonResult.Errors;
                    return ret;
                }
                var PersonNationalId = AddPersonResult.Data.ToString();
                var test = new MedicalTest() {
                    WhiteBloodCell = data.Test.WhiteBloodCell,
                    RedBloodCell = data.Test.RedBloodCell,
                    TestDate = data.Test.TestDate,
                    PersonId = PersonNationalId
                };
                await _applicationDbContext.Tests.AddAsync(test);
                await _applicationDbContext.SaveChangesAsync();
                return ret;
            }
            catch (Exception ex) {
                ret.Succeeded = false;
                var err = new Error() { Code = ex.Message };
                if (ex.InnerException != null)
                    err.Description = ex.InnerException.Message;
                ret.Errors.Add(err);
                return ret;
            }
        }
        public async Task<Response> AddPerson(Person person) {
            var ret = new Response();
            try {
                var res = await _applicationDbContext.Persons.FindAsync(person.NationalId);
                if (res == null) {
                    await _applicationDbContext.Persons.AddAsync(person);
                    await _applicationDbContext.SaveChangesAsync();
                    ret.Data = person.NationalId;
                }
                ret.Data = res.NationalId;
                return ret;
            }
            catch (Exception ex) {
                ret.Succeeded = false;
                var err = new Error() { Code = ex.Message };
                if (ex.InnerException != null)
                    err.Description = ex.InnerException.Message;
                ret.Errors.Add(err);
                return ret;
            }
        }
    }
}
