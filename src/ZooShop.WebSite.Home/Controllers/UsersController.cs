using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ZooShop.Business.DTOs;
using ZooShop.Business.Contracts;
using ZooShop.Data.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZooShop.Representation
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<UserDto> Get()
        {
            return _userService.GetAll();
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public UserEntity Get(int id)
        {
            return _userService.Get(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] UserEntity user)
        {
            _userService.Create(user);
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] UserEntity user)
        {
            _userService.Update(user);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userService.Delete(id);
        }
    }
}
