using ManagerCafe.Data.Models;
using ManagerCafe.Enums;

namespace ManagerCafe.Dtos.InventoryTransactionDtos
{
    public class CreateInventoryTransactionDto
    {
        public Guid Id { get; set; }
        public Guid InventoryId { get; set; }

        public int Quatity { get; set; }
        public EnumInventoryTransation Type { get; set; }
        public DateTime CreateTime { get; set; }
        public Inventory Inventory { get; set; }
    }
}
