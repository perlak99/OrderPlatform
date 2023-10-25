using Contracts;
using MassTransit;
using OrderNotificationApi.Services.Interfaces;

namespace OrderNotificationApi.Consumers
{
    public class OrderAddedConsumer : IConsumer<OrderAddedEvent>
    {
        private readonly INotificationService notificationService;

        public OrderAddedConsumer(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }

        public async Task Consume(ConsumeContext<OrderAddedEvent> context)
        {
            await notificationService.SendNotification(context.Message);
        }
    }
}
