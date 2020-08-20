using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiExample.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderItems = new HashSet<OrderItem>();
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Varienty { get; set; }
        public string Price { get; set; }
        public string Status { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
