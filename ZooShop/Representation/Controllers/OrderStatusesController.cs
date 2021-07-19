using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using ZooShop.Business.Interfaces;
using ZooShop.Data.Entities;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ZooShop.Representation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderStatusController : ControllerBase
    {
        private IOrderStatusService _orderStatusService;

        public OrderStatusController(IOrderStatusService orderStatusService)
        {
            _orderStatusService = orderStatusService;
        }

        [HttpGet]
        public IEnumerable<OrderStatus> Get()
        {
            return _orderStatusService.GetAll();
        }

        // GET api/<OrderStatusController>/5
        [HttpGet("{id}")]
        public OrderStatus Get(int id)
        {
            return _orderStatusService.Get(id);
        }

        // POST api/<OrderStatusController>
        [HttpPost]
        public void Post([FromBody] OrderStatus orderStatus)
        {
            _orderStatusService.Create(orderStatus);
        }

        // PUT api/<OrderStatusController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] OrderStatus orderStatus)
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
