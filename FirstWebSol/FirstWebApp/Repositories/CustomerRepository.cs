using FirstWebApp.Interface;
using FirstWebApp.Models;

namespace FirstWebApp.Repositories
{
    public class CustomerRepository : IRepository<string, Customer>
    {
        static Dictionary<string, Customer> customers = new Dictionary<string, Customer>();
        public Customer Add(Customer item)
        {
            customers.Add(item.Email, item);
            return item;
        }

        public Customer Delete(string id)
        {
            var customer = Get(id);
            if (customer != null)
            {
                customers.Remove(customer.Email);
                return customer;
            }
            return null;
        }

        public Customer Get(string id)
        {
            if (customers.ContainsKey(id))
            {
                return customers[id];
            }
            return null;
        }

        public Customer Update(Customer item)
        {
            var customer = Get(item.Email);
            if (customer != null)
            {
                customers[item.Email] = item;
                return item;
            }
            return null;
        }

        IList<Customer> IRepository<string, Customer>.GetAll()
        {
            if (customers.Count == 0)
                return null;
            return customers.Values.ToList();
        }
    }
}


