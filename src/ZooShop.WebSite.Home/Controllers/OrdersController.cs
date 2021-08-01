using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ZooShop.Website.Home.Business.Contracts;
using ZooShop.Website.Home.Data.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZooShop.Website.Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }


        // GET: api/<OrdersController>
        [HttpGet]
        public IEnumerable<OrderEntity> Get
            (
            [FromQuery] int? userId,
            [FromQuery] int? statusId,
            [FromQuery] string firstname,
            [FromQuery] string surname,
            [FromQuery] string lastname,
            [FromQuery] string email,
            [FromQuery] string phone,
            [FromQuery] string country,
            [FromQuery] string city,
            [FromQuery] string street,
            [FromQuery] string house,
            [FromQuery] string flat
        )
        {
            
            return _orderService.GetAll();
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public OrderEntity Get(int id)
        {
            return _orderService.Get(id);
        }

        // POST api/<OrdersController>
        [HttpPost]
        public void Post([FromBody] OrderEntity order)
        {
            _orderService.Create(order);
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] OrderEntity order)
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
