﻿using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ZooShop.Business.Interfaces;
using ZooShop.Data.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZooShop.Representation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {

        private IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<Order> Get()
        {
            return _orderService.GetAll();
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public Order Get(int id)
        {
            return _orderService.Get(id);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public void Post([FromBody] Order order)
        {
            _orderService.Create(order);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Order order)
        {
            _orderService.Update(order);
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _orderService.Delete(id);
        }
    }
}
