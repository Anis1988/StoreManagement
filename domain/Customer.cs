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

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public  string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
