using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiExample.Models;

namespace WebApiExample.Contracts
{
    public interface ICustomerRepository
    {
        IEnumerable<Customers> GetAll();
        Task<Customers> Add(Customers customer);
        Task<Customers> Find(int id);
        Task<Customers> Update(Customers customer);
        Task<Customers> Remove(int id);
        Task<bool> IsExists(int id);
        Task<int> CountCustomer();
    }
}
