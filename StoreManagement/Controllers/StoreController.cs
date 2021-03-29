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
    }
}
