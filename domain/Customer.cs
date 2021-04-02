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
        [MinLength(5,ErrorMessage = "First Name must be more than 5")]
        public string FirstName { get; set; }
        [Required]
        [MinLength(5,ErrorMessage = "Last Name must be more than 5")]
        public string LastName { get; set; }
        [Required]
        [MinLength(5,ErrorMessage = "User Name Name must be more than 5")]
        public  string UserName { get; set; }
        [Required]
        [MinLength(5,ErrorMessage = "Email Name must be more than 5")]
        public string Email { get; set; }
        [Required]
        [MinLength(5,ErrorMessage = "Password must be more than 8")]
        public string Password { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
