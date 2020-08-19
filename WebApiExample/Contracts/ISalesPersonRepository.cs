using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiExample.Models;

namespace WebApiExample.Contracts
{
    public interface ISalesPersonRepository
    {
        IEnumerable<SalesPerson> GetAll();
        Task<SalesPerson> Add(SalesPerson salesPerson);
        Task<SalesPerson> Find(int id);
        Task<SalesPerson> Update(SalesPerson salesPerson);
        Task<SalesPerson> Remove(int id);
        Task<bool> IsExists(int id);
    }
}
