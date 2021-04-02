using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace domain
{
    public class Order {

        [Key]
        public Guid OrderId { get; set; } = new Guid();

        public Guid CustomerId { get; set; }
        public Customer Customer { get; set; }
        public DateTime DateTime { get; set; } = new DateTime();

        public Guid ProductId { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
        public Guid StoreId { get; set; }
        public Store Store { get; set; }
    }
}
