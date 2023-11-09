using FirstWebApp.Interface;
using FirstWebApp.Models;
using FirstWebApp.Repositories;

namespace FirstWebApp.Services
{
    public class CustomerService : ICustomerService
    {
        IRepository<string, Customer> repository;
        public CustomerService(IRepository<string, Customer> repo)
        {
            repository = repo;
        }

        public bool Login(string username, string password)
        {
            var myCustomer = repository.Get(username);
            if (myCustomer != null)
            {
                if (myCustomer.ComparePassword(password))
                    return true;
            }

            return false;
        }

        public Customer Register(Customer customer)
        {
            var result = repository.Add(customer);
            if (result != null)
            {
                return result;
            }
            throw new Exception();
        }
    }
}
