using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ZooShop.Website.Home.Business.Contracts;
using ZooShop.Website.Home.Data.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZooShop.Website.Home.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusController : ControllerBase
    {
        private readonly IOrderStatusService _orderStatusService;

        public OrderStatusController(IOrderStatusService orderStatusService)
        {
            _orderStatusService = orderStatusService;
        }

        [HttpGet]
        public IEnumerable<OrderStatusEntity> Get()
        {
            return _orderStatusService.GetAll();
        }

        // GET api/<OrderStatusController>/5
        [HttpGet("{id}")]
        public OrderStatusEntity Get(int id)
        {
            return _orderStatusService.Get(id);
        }

        // POST api/<OrderStatusController>
        [HttpPost]
        public void Post([FromBody] OrderStatusEntity orderStatus)
        {
            _orderStatusService.Create(orderStatus);
        }

        // PUT api/<OrderStatusController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] OrderStatusEntity orderStatus)
        {
            _orderStatusService.Update(orderStatus);
        }

        // DELETE api/<OrderStatusController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _orderStatusService.Delete(id);
        }
    }
}
