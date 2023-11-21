using HotelAPI.Context;
using HotelAPI.Interfaces;
using HotelAPI.Models;
using HotelAPI.Models.DTO;
using HotelAPI.Repositories;
using HotelAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Text;

namespace EShoppintTest
{
    public class CustomerServiceTest 
    {
        IRepository<string, Customer> repository;
        [SetUp]
        public void Setup()
        {
            var dbOptions = new DbContextOptionsBuilder<HotelContext>()
                                .UseInMemoryDatabase("dbTestCustomer")//a database that gets created temp for testing purpose
                                .Options;
            HotelContext context = new HotelContext(dbOptions);
            repository = new CustomerRepository(context);

        }

        [Test]
        [TestCase("Test", "11123")]
        public void LoginTest(string un, string pass)
        {

            //Arrange
            var appSettings = @"{""SecretKey"": ""Anything will work here this is just for testing""}";
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonStream(new MemoryStream(Encoding.UTF8.GetBytes(appSettings)));
            var tokenService = new TokenService(configurationBuilder.Build());
            ICustomerService customerService = new CustomerService(repository, tokenService);
            customerService.Register(new CustomerDTO
            {
                Email = un,
                Name = pass,
                Address = pass,
                PhoneNumber = pass,
                Password = pass,
                Role = "customer"
            });
            //Action
            var resulut = customerService.Login(new CustomerDTO { Email = "Test", Password = "11123", Role = "customer" });
            //Assert
            Assert.AreEqual("Test", resulut.Email);
        }
    }
}