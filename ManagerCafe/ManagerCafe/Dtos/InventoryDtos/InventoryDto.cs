using ManagerCafe.Data.Models;
using ManagerCafe.Dtos.ProductDtos;
using ManagerCafe.Dtos.WareHouseDtos;

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
        public ProductDto Product { get; set; }
        public WareHouseDto WareHouse { get; set; }
        public string ProductName { get; set; }
        public string WareHouseName { get; set; }
        public string Type { get; set; }
    }
}
