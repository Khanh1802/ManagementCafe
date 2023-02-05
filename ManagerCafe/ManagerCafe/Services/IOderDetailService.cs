using ManagerCafe.Dtos.OrderDetailDtos;

namespace ManagerCafe.Services
{
    public interface IOrderDetailService
    {
        Task AddAsync(OrderDetailDto item);
        void Delete(OrderDetailDto item);
    }
}
