using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace domain
{
   public class Product
   {
       [Key]
       public Guid ProductId { get; set; } = new Guid();
       public string Name { get; set; }
       public int UnitPrice { get; set; }
       public int QuantityInStock { get; set; }

   }
}
