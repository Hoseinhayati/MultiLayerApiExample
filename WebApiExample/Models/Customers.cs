using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebApiExample.Models
{
    public partial class Customers
    {
        public Customers()
        {
            Orders = new HashSet<Orders>();
        }

        public int Id { get; set; }
        [MaxLength(120, ErrorMessage = "the length of {0} is to much")]
        [StringLength(120, MinimumLength = 4, ErrorMessage = "The {0} Its big")]
        [DisplayName("FName")]
        [Required(ErrorMessage = "Please Enter {0}")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Phone]
        public string Phone { get; set; }
        public string Adress { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }

        public virtual ICollection<Orders> Orders { get; set; }
    }
}
