using FirstWebApp.Models;

namespace FirstWebApp.Interface
{
    public interface ICustomerService
    {
        public Customer Register(Customer customer);
        public bool Login(string username, string password);
    }
}

