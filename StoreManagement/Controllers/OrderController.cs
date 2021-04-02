using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using service;

namespace StoreManagement.Controllers
{
    
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IStoreLogic iStoreLogic;

        public OrderController(IStoreLogic iStoreLogic)
        {
            this.iStoreLogic = iStoreLogic;
        }

        [HttpGet]
        [Route("api/[controller]/location/{location}")]
        public IActionResult getThem( string location)
        {

            return Ok(iStoreLogic.getAllOrder(location));
        }
        [HttpGet]
        [Route("api/[controller]/{location}/{name}")]
        public IActionResult getThemByNameAndLoc( string location,string name)
        {
            return Ok(iStoreLogic.getAllOrder(name,location));
        }

        [HttpGet]
        [Route("api/[controller]/customer/{name}")]
        public IActionResult getOrderByName(string name)
        {
            return Ok(iStoreLogic.getCustomerOrder(name));
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult getAllOrders()
        {
            return Ok(iStoreLogic.getAllOrder());
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult addProducttoAcust(Order order)
        {
           iStoreLogic.addProductToAcustomer(order);
           return Created(
               HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" +
               order.OrderId, order);
        }

    }
}

