using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiExample.Models;

namespace WebApiExample.Contracts
{
    public interface IProductRepository
    {
        Task<ActionResult<IEnumerable<Product>>> GetAll();
        Task<Product> Add(Product products);
        Task<Product> Find(int id);
        Task<Product> Update(Product products);
        Task<Product> Remove(int id);
        Task<bool> IsExists(int id);
    }
}
