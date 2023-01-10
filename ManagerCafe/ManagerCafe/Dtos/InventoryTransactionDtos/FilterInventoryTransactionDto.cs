using ManagerCafe.Data.Enums;
using ManagerCafe.Data.Models;
using ManagerCafe.Enums;

namespace ManagerCafe.Dtos.InventoryTransactionDtos
{
    public class FilterInventoryTransactionDto
    {
        public EnumInventoryTransation Type { get; set; }
        public EnumInventoryTransactionTypeDate TypeDate { get; set; }
        public Guid WarehouseId { get; set; }
        public DateTime FormDate { get; set; }
        public DateTime ToDate { get; set; }
        public string ProductName { get; set; }
    }
}
