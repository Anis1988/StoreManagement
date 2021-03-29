using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace domain
{
    public class Order {
        [Key]
        public Guid OrderId { get; set; } = new Guid();

        public Customer Customer { get; set; }
        public DateTime DateTime { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public Store Store { get; set; }
    }
}
