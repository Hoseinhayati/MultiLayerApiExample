using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiExample.Contracts;
using WebApiExample.Models;

namespace WebApiExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductsController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            return await _productRepository.GetAll();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Products>> GetProducts(int id)
        {
            var products = await _productRepository.Find(id);

            if (products == null)
            {
                return NotFound();
            }

            return products;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(int id, Products products)
        {
            if (id != products.Id)
            {
                return BadRequest();
            }

            await _productRepository.Update(products);

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!ProductsExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return NoContent();
        }

        // POST: api/Products
        [HttpPost]
        public async Task<ActionResult<Products>> PostProducts(Products products)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _productRepository.Add(products);

            return CreatedAtAction("GetProducts", new { id = products.Id }, products);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Products>> DeleteProducts(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var products = await _productRepository.Find(id);
            if (products == null)
            {
                return NotFound();
            }

            await _productRepository.Remove(id);

            return products;
        }

        private async Task<bool> ProductsExists(int id)
        {
            return await _productRepository.IsExists(id);
        }
    }
}
