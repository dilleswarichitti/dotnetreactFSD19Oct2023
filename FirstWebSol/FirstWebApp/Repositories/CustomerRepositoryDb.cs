using FirstWebApp.Context;
using FirstWebApp.Interface;
using FirstWebApp.Models;

namespace FirstWebApp.Repositories
{
    public class CustomerRepositoryDb : IRepository<string, Customer>
    {
        private readonly ShoppingContext _context;

        public CustomerRepositoryDb(ShoppingContext context)
        {
            _context = context;
        }
        public Customer Add(Customer item)
        {
            _context.Customers.Add(item);//Add local collection
            _context.SaveChanges();//THis is make teh change in DB
            return item;
        }

        public Customer Delete(string key)
        {
            var customer = Get(key);
            _context.Customers.Remove(customer);//removes from local collection
            _context.SaveChanges();//Makes the delete in database
            return customer;
        }

        public Customer Get(string key)
        {
            var customer = _context.Customers.SingleOrDefault(p => p.Email == key);
            return customer;
        }

        public IList<Customer> GetAll()
        {
            var customer = _context.Customers.ToList();
            return customer;
        }

        public Customer Update(Customer item)
        {
            var customer = Get(item.Email);
            if (customer != null)
            {
                _context.Entry<Customer>(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return customer;
            }
            return null;
        }
    }
}
