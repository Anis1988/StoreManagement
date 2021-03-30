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
       [Required]
       public string Name { get; set; }
       [Required]
       public int UnitPrice { get; set; }

       public string ProductUrl { get; set; }
       [Required]
       public int QuantityInStock { get; set; }

   }
}
