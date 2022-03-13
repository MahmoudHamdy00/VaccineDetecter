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
        public Response SaveData(DataDTO data) {
            var ret = new Response();
            try {
                var person = new Person() {
                    Age = data.person.Age,
                    Gender = data.person.Gender,
                    Email = data.person.Email,
                };
                var AddPersonResult = AddPerson(person);
                if (!AddPersonResult.Succeeded) {
                    ret.Succeeded = false;
                    ret.Errors = AddPersonResult.Errors;
                    return ret;
                }
                var PersonId = AddPersonResult.Data.ToString();
                var test = new MedicalTest() {
                    WhiteBloodCell = data.Test.WhiteBloodCell,
                    RedBloodCell = data.Test.RedBloodCell,
                    TestDate = data.Test.TestDate,
                    PersonId = PersonId
                };
                _applicationDbContext.Tests.Add(test);
                _applicationDbContext.SaveChanges();
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
        public Response AddPerson(Person person) {
            var ret = new Response();
            try {
                var res = _applicationDbContext.Persons.Find(person.Email);
                if (res == null) {
                    _applicationDbContext.Persons.Add(person);
                    _applicationDbContext.SaveChanges();
                    ret.Data = person.Email;
                }
                else
                    ret.Data = res.Email;
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
