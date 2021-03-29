using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace domain
{
   public class Store {

       [Key]
       public Guid StoreId { get; set; } = new Guid();

       public string LocationName { get; set; }
       public ICollection<Product> Products { get; set; } = new List<Product>();
       public ICollection<Order> Orders { get; set; } = new List<Order>();
   }
}
