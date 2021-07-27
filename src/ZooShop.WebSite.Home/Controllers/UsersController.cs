using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ZooShop.Website.Home.Business.Contracts;
using ZooShop.Website.Home.Business.Models;
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
        public IEnumerable<UserDto> Get
            (
            [FromQuery]string firstname,
            [FromQuery] string surname,
            [FromQuery] string lastname,
            [FromQuery] string email
            )
        {
            if (firstname == null && surname == null && lastname == null & email == null)
            {
                return _userService.GetAll();
            }

            return _userService.GetWithFilter(firstname, surname, lastname, email);
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
            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.PasswordHash))
            {
                throw new ArgumentException("Not valid model");
            }
            _userService.Create(user); 
            Response.StatusCode = 201;
            
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] UserEntity user)
        {
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
