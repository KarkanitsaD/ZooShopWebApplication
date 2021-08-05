using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZooShop.Website.Home.Business.Contracts;
using ZooShop.Website.Home.Business.Models;
using ZooShop.Website.Home.Business.QueryModels;
using ZooShop.Website.Home.Data.Entities;

namespace ZooShop.Website.Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<UserDto> Get([FromQuery] UserQueryModel queryModel = null)
        {
            if (queryModel==null || !queryModel.IsValidToFilter())
            {
                return _userService.GetAll();
            }

            return _userService.GetAll(queryModel);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public UserDto Get(int id)
        {
            return _userService.Get(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] UserEntity user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(UserEntity), "User can't be null");
            }
            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.PasswordHash))
            {
                throw new ArgumentException("Not valid model");
            }
            _userService.Create(user); 
            Response.StatusCode = 201;
            
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        public void Put([FromBody] UserEntity user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(UserEntity), "User can't be null");
            }
            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.PasswordHash))
            {
                throw new ArgumentException("Not valid model");
            } 
            _userService.Update(user);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            if (id > 1)
            {
                _userService.Delete(id);
            }
            else
            {
                throw new ArgumentException("Not valid user id");
            }
        }
    }
}
