using Contracts;

namespace OrderNotificationApi.Services.Interfaces
{
    public interface INotificationService
    {
        Task SendNotification(OrderAddedEvent order);
    }
}
