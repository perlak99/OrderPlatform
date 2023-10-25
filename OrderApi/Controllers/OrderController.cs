using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver.Core.Connections;
using OrderApi.DTOs;
using OrderApi.Models.Entities;
using OrderApi.Services.Interfaces;

namespace OrderApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
        }

        [HttpPost("AddOrder")]
        public async Task<ActionResult> AddOrder(AddOrderDto request)
        {
            await _orderService.AddOrderAsync(request);

            return Ok();
        }
    }
}
