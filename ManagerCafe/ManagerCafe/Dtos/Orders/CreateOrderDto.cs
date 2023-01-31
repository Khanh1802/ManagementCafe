using ManagerCafe.Data.Enums;

namespace ManagerCafe.Dtos.Orders
{
    public class CreateOrderDto
    {
        public Guid StaffId { get; set; }
        public Guid CustomerId { get; set; }
        public string Code { get; set; }
        public EnumOrderStatus Status { get; set; }
    }
}
