using System.Security.Cryptography;
using System.Text;
using HotelAPI.Interfaces;
using HotelAPI.Models;
using HotelAPI.Models.DTO;
using static HotelAPI.Models.DTO.CustomerDTO;

namespace HotelAPI.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly IRepository<string, Customer> _repository;
        private readonly ITokenService _tokenService;

        public CustomerService(IRepository<string, Customer> repository, ITokenService tokenService)
        {
            _repository = repository;
            _tokenService = tokenService;
        }
        public CustomerDTO Login(CustomerDTO customerDTO)
        {
            var customer = _repository.GetById(customerDTO.Email);
            if (customer != null)
            {
                HMACSHA512 hmac = new HMACSHA512(customer.Key);
                var customerpass = hmac.ComputeHash(Encoding.UTF8.GetBytes(customerDTO.Password));
                for (int i = 0; i < customerpass.Length; i++)
                {
                    if (customer.Password[i] != customerpass[i])
                        return null;
                }
                customerDTO.Token = _tokenService.GetToken(customerDTO);
                customerDTO.Password = "";
                return customerDTO;
            }
            return null;
        }

        public CustomerDTO Register(CustomerDTO customerDTO)
        {
            HMACSHA512 hmac = new HMACSHA512();
            Customer customer = new Customer()
            {
                Email = customerDTO.Email,
                Name = customerDTO.Name,
                PhoneNumber = customerDTO.PhoneNumber,
                Address = customerDTO.Address,
                Password = hmac.ComputeHash(Encoding.UTF8.GetBytes(customerDTO.Password)),
                Key = hmac.Key,
                Role = customerDTO.Role
            };
            var result = _repository.Add(customer);
            if (result != null)
            {
                customerDTO.Password = "";
                return customerDTO;
            }
            return null;

        }
    }
}
