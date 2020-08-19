using System;
using System.Collections.Generic;

namespace WebApiExample.Models
{
    public partial class Orders
    {
        public Orders()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int Id { get; set; }
        public DateTime? Date { get; set; }
        public double? Total { get; set; }
        public string Status { get; set; }
        public int CustomerId { get; set; }
        public int SalesPersonId { get; set; }

        public virtual Customers Customer { get; set; }
        public virtual SalesPerson SalesPerson { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
