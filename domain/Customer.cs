using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace domain
{
    public class Customer
    {
        
        [Key]
        public Guid CustomerId { get; set; } = new Guid();

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public  string UserName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
