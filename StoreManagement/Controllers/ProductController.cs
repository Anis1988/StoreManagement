using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    }
}
