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
    public class OrderController : ControllerBase
    {
        private readonly IStoreLogic iStoreLogic;

        public OrderController(IStoreLogic iStoreLogic)
        {
            this.iStoreLogic = iStoreLogic;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult getThem( string LocationName)
        {
            return Ok(iStoreLogic.getAllOrder(LocationName));
        }
    }
}
