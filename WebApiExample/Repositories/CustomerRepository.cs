using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiExample.Contracts;
using WebApiExample.Models;

namespace WebApiExample.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private ApiExampleContext _ctx;
        public CustomerRepository(ApiExampleContext context)
        {
            _ctx = context;
        }

        public async Task<Customers> Add(Customers customer)
        {
            await _ctx.Customers.AddAsync(customer);
            await _ctx.SaveChangesAsync();
            return customer;
        }

        public async Task<int> CountCustomer()
        {
            var result = await _ctx.Customers.CountAsync();
            return result;
        }

        public async Task<Customers> Find(int id)
        {
            return await _ctx.Customers.Include(c => c.Orders).SingleOrDefaultAsync(c => c.Id == id);
        }

        public IEnumerable<Customers> GetAll()
        {
            return _ctx.Customers.ToList();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _ctx.Customers.AnyAsync(c => c.Id == id);
        }

        public async Task<Customers> Remove(int id)
        {
            var customer = await _ctx.Customers.SingleAsync(c => c.Id == id);
            _ctx.Customers.Remove(customer);
            await _ctx.SaveChangesAsync();
            return customer;
        }

        public async Task<Customers> Update(Customers customer)
        {
            _ctx.Update(customer);
            await _ctx.SaveChangesAsync();
            return customer;
        }
    }
}
