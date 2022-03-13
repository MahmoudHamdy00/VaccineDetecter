using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using VaccineDetecter_Backend.Data;
using VaccineDetecter_Backend.Models;
using VaccineDetecter_Backend.Services;

namespace TestProject
{
    public class Tests
    {
        private static DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
          .UseInMemoryDatabase(databaseName: "BookDbTest")
          .Options;
        ApplicationDbContext dbContext;
        SavingDataService savingDataService;

        [OneTimeSetUp]
        public void Setup() {
            dbContext = new ApplicationDbContext(dbContextOptions);
            dbContext.Database.EnsureCreated();
            SeedDatabae();
            savingDataService = new SavingDataService(dbContext);
        }

        [Test]
        public void Test1() {
            var result = dbContext.Persons.Where(x => x.Age != 4).Count();
            Assert.That(result, Is.EqualTo(3));
        }
        [Test]
        public void TestAddPerson() {
            var person = new Person() {
                Age = 55,
                Email = "aya@gmail.com",
                Gender = "FeMale"
            };
            savingDataService.AddPerson(person);
            var result = dbContext.Persons.Where(x => x.Age != 4).Count();
            Assert.That(result, Is.EqualTo(4));
        }
        [OneTimeTearDown]
        public void CleanUp() {
            dbContext.Database.EnsureDeleted();
        }
        private void SeedDatabae() {
            var persons = new List<Person>()
            {
                new Person() {
                    Age=17,
                    Email="mahmoudh.morsy@gmail.com",
                    Gender="Male"
                },
                new Person() {
                    Age=32,
                    Email="mahmoudh@gmail.com",
                    Gender="Male"
                },new Person() {
                    Age=50,
                    Email="ahmed@gmail.com",
                    Gender="Male"
                }
            };
            dbContext.Persons.AddRange(persons);
            dbContext.SaveChanges();
        }
    }
}