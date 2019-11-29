using BHDLearning.Data.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BHDLearning.Api.Data.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController
        : ControllerBase
    {

        DataService service;
        public DataController()
        {
            service = new DataService();
        }

        [HttpGet("gettypes")]
        public async Task<IActionResult> GetTypes(string filter)
        {
            return Ok(await service.GetTypes(filter));
        }

        [HttpGet("getproducts")]
        public async Task<IActionResult> GetProducts(string filter)
        {
            return Ok(await service.GetProducts(filter));
        }

    }
}
