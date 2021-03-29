using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain;
using Microsoft.AspNetCore.Mvc;
using service;

namespace StoreManagement.Controllers
{
    
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private IStoreLogic iStoreLogic;


        public CustomerController(IStoreLogic iStoreLogic)
        {
            this.iStoreLogic = iStoreLogic;
        }

        [Route("api/[controller]/{id}")]
        public IActionResult getSingle(Guid id)
        {
            return Ok(iStoreLogic.getSingleCustomer(id));
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult getThemAll()
        {
            return Ok(iStoreLogic.getAllCustomers().ToList());
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult postCustomer(Customer customer)
        {
            iStoreLogic.addCustomer(customer);
            return Created(
                HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" +
                customer.CustomerId, customer);
        }

        [HttpDelete]
        [Route("api/[controller]/delete/{id}")]
        public IActionResult deleteCustomer(Guid id)
        {
            iStoreLogic.deleteCustomer(id);
            return Ok();
        }

        
    }
}