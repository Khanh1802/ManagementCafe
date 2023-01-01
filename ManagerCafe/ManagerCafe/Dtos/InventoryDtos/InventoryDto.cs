using ManagerCafe.Data.Models;

namespace ManagerCafe.Dtos.InventoryDtos
{
    public class InventoryDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid WareHouseId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? DeletetionTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public bool IsDeleted { get; set; }
        public int Quatity { get; set; }
        public Product Product { get; set; }
        public WareHouse WareHouse { get; set; }
    }
}
