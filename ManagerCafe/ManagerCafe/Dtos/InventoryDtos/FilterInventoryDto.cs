namespace ManagerCafe.Dtos.InventoryDtos
{
    public class FilterInventoryDto
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid WareHouseId { get; set; }
        public int Quatity { get; set; }
    }
}
