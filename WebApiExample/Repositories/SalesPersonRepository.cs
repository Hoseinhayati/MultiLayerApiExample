using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiExample.Contracts;
using WebApiExample.Models;

namespace WebApiExample.Repositories
{
    public class SalesPersonRepository : ISalesPersonRepository
    {
        private ApiExampleContext _ctx;
        public SalesPersonRepository(ApiExampleContext context)
        {
            _ctx = context;
        }

        public async Task<SalesPerson> Add(SalesPerson salesPerson)
        {
            await _ctx.SalesPerson.AddAsync(salesPerson);
            await _ctx.SaveChangesAsync();
            return salesPerson;
        }

        public async Task<SalesPerson> Find(int id)
        {
            return await _ctx.SalesPerson.SingleOrDefaultAsync(c => c.Id == id);
        }

        public IEnumerable<SalesPerson> GetAll()
        {
            return _ctx.SalesPerson.ToList();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _ctx.SalesPerson.AnyAsync(c => c.Id == id);
        }

        public async Task<SalesPerson> Remove(int id)
        {
            var salesPerson = await _ctx.SalesPerson.SingleAsync(c => c.Id == id);
            _ctx.SalesPerson.Remove(salesPerson);
            await _ctx.SaveChangesAsync();
            return salesPerson;
        }

        public async Task<SalesPerson> Update(SalesPerson salesPerson)
        {
            _ctx.Update(salesPerson);
            await _ctx.SaveChangesAsync();
            return salesPerson;
        }
    }
}
