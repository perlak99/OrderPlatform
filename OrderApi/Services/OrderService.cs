using AutoMapper;
using Contracts;
using MassTransit;
using OrderApi.DTOs;
using OrderApi.Models.Entities;
using OrderApi.Repositories.Interfaces;
using OrderApi.Services.Interfaces;
using RabbitMQ.Client;

namespace OrderApi.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IPublishEndpoint _publishEndpoint;
        private readonly IMapper mapper;

        public OrderService(IOrderRepository orderRepository, IPublishEndpoint publishEndpoint, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _publishEndpoint = publishEndpoint;
            this.mapper = mapper;
        }

        public async Task AddOrderAsync(AddOrderDto request)
        {
            var order = mapper.Map<Order>(request);
            order.CreatedAt = DateTime.Now;
            await _orderRepository.CreateAsync(order);

            await _publishEndpoint.Publish(new OrderAddedEvent
            {
                Id = order.Id,
                CreatedAt = order.CreatedAt,
                Email = order.Email,
                PhoneNumber = order.PhoneNumber
            });
        }

        public async Task SetNotificationSent(Guid orderId)
        {
            var order = await _orderRepository.GetAsync(orderId);
            order.NotificationSent = true;
            await _orderRepository.UpdateAsync(order);
        }
    }
}
