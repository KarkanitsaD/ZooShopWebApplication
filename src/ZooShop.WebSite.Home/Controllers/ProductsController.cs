using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ZooShop.Website.Home.Business.Contracts;
using ZooShop.Website.Home.Data.Entities;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZooShop.Website.Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<ProductEntity> Get()
        {
            return _productService.GetAll();
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ProductEntity Get(int id)
        {
            return _productService.Get(id);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] ProductEntity product)
        {
            _productService.Create(product);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] ProductEntity product)
        {
            _productService.Update(product);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _productService.Delete(id);
        }
    }
}
