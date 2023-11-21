using HotelAPI.Context;
using HotelAPI.Interfaces;
using HotelAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace HotelAPI.Repositories
{
    public class CustomerRepository : IRepository<string, Customer>
    {
        private readonly HotelContext _context;

        public CustomerRepository(HotelContext context) 
        {
            _context = context;
        }
        public Customer Add(Customer entity)
        {
            _context.Customers.Add(entity);
            _context.SaveChanges();//this make changes in Db
            return entity;
        }
        /// <summary>
        /// Delete the customer from its id
        /// </summary>
        /// <param name="key">the customer id will be deleted</param>
        /// <returns>deleted customer</returns>
        public Customer Delete(string key)
        {
            var customer = GetById(key);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                _context.SaveChanges();
                return customer;
            }
            return null;
        }

        public IList<Customer> GetAll()
        {
            if (_context.Customers.Count() == 0)
                return null;
            return _context.Customers.ToList();
        }

        public Customer GetById(string key)
        {
            var customer = _context.Customers.SingleOrDefault(u => u.Email == key);
            return customer;
        }

        public Customer Update(Customer entity)
        {
            var customer = GetById(entity.Email);
            if (customer != null)
            {
                _context.Entry<Customer>(customer).State = EntityState.Modified;
                _context.SaveChanges();
                return customer;
            }
            return null;
        }
    }
}
