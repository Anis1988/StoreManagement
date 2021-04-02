using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using domain;
using service;

namespace StoreManagement.Controllers
{
    
    [ApiController]
    [Route("api/[controller]")]
    public class StoreController : ControllerBase
    {
        private IStoreLogic iStoreLogic;

        public StoreController(IStoreLogic iStoreLogic)
        {
            this.iStoreLogic = iStoreLogic;
        }

        [HttpGet]
        
        public IActionResult getAll()
        {
            return Ok(iStoreLogic.getALlStores().ToList());
        }
        [HttpGet("{name}")]
        
        public IActionResult getSingle(string name)
        {
            var store = iStoreLogic.getSingleStore(name);
            if (store == null)
            {
                return NotFound("Sorry couldn't found the store you are looking for with the Name: " + name);
            }
            return Ok(iStoreLogic.getSingleStore(name));
        }
    }
}
