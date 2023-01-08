using ManagerCafe.Data.Enums;
using ManagerCafe.Data.Models;
using ManagerCafe.Enums;

namespace ManagerCafe.Dtos.InventoryTransactionDtos
{
    public class FilterInventoryTransactionDto
    {
        public EnumInventoryTransation Type { get; set; }
        public EnumInventoryTransactionTypeDate TypeDate { get; set; }

    }
}
