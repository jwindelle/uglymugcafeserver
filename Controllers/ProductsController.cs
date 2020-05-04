using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebTestApi.Controllers
{
    [Route("api/Products")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // api/Products
        //[EnableCors("CorsPolicy")]
        [Route("all")]
        [HttpGet(Name="Get Products")]
        public IEnumerable<string> Get()
        {
            IEnumerable<string> list = new string[] { "Product_1", "Product_2", "Product_3" };

            return list.ToArray();
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            string[] list = { "Product_1", "Product_2", "Product_3" };

            return list[id];
        }


    }
}