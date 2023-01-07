namespace ManagerCafe.Dtos.InventoryDtos
{
    public class InventoryTransationDto
    {
        public int Id { get; set; }
        public DateTime CreateTime { get; set; }
        public int Quatity { get; set; }
        public string Type { get; set; }
        public string ProductName { get; set; }
        public string WarehouseName { get; set; }
    }
}
