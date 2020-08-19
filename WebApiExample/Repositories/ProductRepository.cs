using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiExample.Contracts;
using WebApiExample.Models;

namespace WebApiExample.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApiExampleContext _ctx;
        public ProductRepository(ApiExampleContext context)
        {
            _ctx = context;
        }

        public async Task<Products> Add(Products product)
        {
            await _ctx.Products.AddAsync(product);
            await _ctx.SaveChangesAsync();
            return product;
        }

        public async Task<Products> Find(int id)
        {
            return await _ctx.Products.Include(c => c.OrderItems).SingleOrDefaultAsync(c => c.Id == id);
        }

        public async Task<ActionResult<IEnumerable<Products>>> GetAll()
        {
            return await _ctx.Products.ToListAsync();
        }

        public async Task<bool> IsExists(int id)
        {
            return await _ctx.Products.AnyAsync(c => c.Id == id);
        }

        public async Task<Products> Remove(int id)
        {
            var product = await _ctx.Products.SingleAsync(c => c.Id == id);
            _ctx.Products.Remove(product);
            await _ctx.SaveChangesAsync();
            return product;
        }

        public async Task<Products> Update(Products product)
        {
            _ctx.Update(product);
            await _ctx.SaveChangesAsync();
            return product;
        }
    }
}
