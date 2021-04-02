using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain;
using Microsoft.AspNetCore.Mvc;
using service;

namespace StoreManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IStoreLogic iStoreLogic;

        public ProductController(IStoreLogic iStoreLogic)
        {
            this.iStoreLogic = iStoreLogic;
        }

        [HttpGet]
        public List<Product> getAllProduct()
        {
            return iStoreLogic.getAllProducts();
        }
        [HttpGet("/{id}")]
        public IActionResult getAllProduct(Guid id)
        {
            var product = iStoreLogic.getSingleProducts(id);
            if (product == null)
            {
                return NotFound("Sorry couldn't found the product with Id: " + id);
            }

            return Ok(iStoreLogic.getSingleProducts(id));
        }
    }
}
