using System;
using System.Collections.Generic;

namespace WebApiExample.Models
{
    public partial class Products
    {
        public Products()
        {
            OrderItems = new HashSet<OrderItems>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Varienty { get; set; }
        public string Price { get; set; }
        public string Status { get; set; }

        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
