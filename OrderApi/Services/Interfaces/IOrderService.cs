using OrderApi.DTOs;
using OrderApi.Models.Entities;

namespace OrderApi.Services.Interfaces
{
    public interface IOrderService
    {
        Task AddOrderAsync(AddOrderDto order);
        Task SetNotificationSent(Guid id);
    }
}
