using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ClassLibrary1;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Pagin_Codemaze.Data;
using Pagin_Codemaze.Query_Parameters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pagin_Codemaze.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ValuesController : Controller
    {

        // Like
        // https://localhost:5001/api/values/FindProducts?pageNumber=10&pageSize=2
        [HttpGet]
        public IActionResult FindProducts([FromQuery] QueryParameters parameters)
        {
            var repo = new Repository();
            var products = repo.GetProducts(parameters);
            return Ok(products);
        }

        


        [HttpGet] 
        public IActionResult FindProductsRefined([FromQuery] QueryParameters parameters)
        {
            var repo = new Repository();
            PagedList<Product> pagedList = repo.GetProducts_Refined(parameters);

            var metadata = new
            {
                pagedList.TotalPages,
                pagedList.TotalCount,
                pagedList.PageSize,
                pagedList.HasPrevious,
                pagedList.CurrentPage
            };

            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(pagedList);
        }
    }
}
