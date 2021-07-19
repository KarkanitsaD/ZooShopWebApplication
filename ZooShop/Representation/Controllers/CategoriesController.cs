using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ZooShop.Business.Interfaces;
using ZooShop.Data.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZooShop.Representation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        // GET: api/<CategoriesController>
        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _categoryService.GetAll();
        }

        // GET api/<CategoriesController>/5
        [HttpGet("{id}")]
        public Category Get(int id)
        {
            return _categoryService.Get(id);
        }

        // POST api/<CategoriesController>
        [HttpPost]
        public void Post([FromBody] Category category)
        {
            _categoryService.Create(category);
        }

        // PUT api/<CategoriesController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Category category)
        {
            _categoryService.Update(category);
        }

        // DELETE api/<CategoriesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _categoryService.Delete(id);
        }
    }
}
