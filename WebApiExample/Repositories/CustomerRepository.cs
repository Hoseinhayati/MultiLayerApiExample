using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using WebApiExample.Contracts;
using WebApiExample.Models;

namespace WebApiExample.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private ApiExampleContext _ctx;
        private IMemoryCache _cache;

        public CustomerRepository(ApiExampleContext ctx, IMemoryCache cache)
        {
            _ctx = ctx;
            _cache = cache;
        }

        public async Task<Customer> Add(Customer customer)
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

        public async Task<Customer> Find(int id)
        {
            var cacheCustomer = _cache.Get<Customer>(id);
            if (cacheCustomer != null)
            {
                return cacheCustomer;
            }
            else
            {
                var customer =await _ctx.Customers.Include(c => c.Orders).SingleOrDefaultAsync(c => c.Id == id);
                var cacheOption = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromSeconds(60)); 
                _cache.Set(customer.Id,customer,cacheOption);
                return customer;
            }
        }

        public IEnumerable<Customer> GetAll()
        {
            return _ctx.Customers.ToList();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _ctx.Customers.AnyAsync(c => c.Id == id);
        }

        public async Task<Customer> Remove(int id)
        {
            var customer = await _ctx.Customers.SingleAsync(c => c.Id == id);
            _ctx.Customers.Remove(customer);
            await _ctx.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> Update(Customer customer)
        {
            _ctx.Update(customer);
            await _ctx.SaveChangesAsync();
            return customer;
        }
    }
}
