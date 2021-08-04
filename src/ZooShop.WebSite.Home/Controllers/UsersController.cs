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
        public async Task<IEnumerable<UserDto>> Get([FromQuery] UserQueryModel queryModel = null)
        {
            if (queryModel==null || !queryModel.IsValidToFilter())
            {
                return await _userService.GetAllAsync();
            }

            return await _userService.GetAllAsync(queryModel);
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public async Task<UserDto> Get(int id)
        {
            return await _userService.GetAsync(id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public async Task Post([FromBody] UserEntity user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(UserEntity), "User can't be null");
            }
            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.PasswordHash))
            {
                throw new ArgumentException("Not valid model");
            }
            await _userService.CreateAsync(user); 
            Response.StatusCode = 201;
            
        }

        // PUT api/<UsersController>/5
        [HttpPut]
        public async Task Put([FromBody] UserEntity user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(UserEntity), "User can't be null");
            }
            if (string.IsNullOrEmpty(user.FirstName) || string.IsNullOrEmpty(user.PasswordHash))
            {
                throw new ArgumentException("Not valid model");
            } 
            await _userService.UpdateAsync(user);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            if (id > 1)
            {
                await _userService.DeleteAsync(id);
            }
            else
            {
                throw new ArgumentException("Not valid user id");
            }
        }
    }
}
