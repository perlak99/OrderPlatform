using Contracts;
using MassTransit;
using OrderNotificationApi.Services.Interfaces;

namespace OrderNotificationApi.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public NotificationService(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task SendNotification(OrderAddedEvent order)
        {
            Console.WriteLine("---> Sending notification to order {0}", order.Id);

            await Task.Delay(2000);

            await _publishEndpoint.Publish(new OrderNotificationSentEvent
            {
                Id = order.Id,
                CreatedAt = order.CreatedAt
            });
        }
    }
}