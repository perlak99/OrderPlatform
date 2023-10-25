using Contracts;
using MassTransit;
using OrderApi.Services.Interfaces;

namespace OrderApi.Consumers
{
    public class OrderNotificationSentConsumer : IConsumer<OrderNotificationSentEvent>
    {
        private readonly IOrderService orderService;

        public OrderNotificationSentConsumer(IOrderService orderService)
        {
            this.orderService = orderService;
        }

        public async Task Consume(ConsumeContext<OrderNotificationSentEvent> context)
        {
            await orderService.SetNotificationSent(context.Message.Id);
        }
    }
}