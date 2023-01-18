namespace ManagerCafe.Dtos.UserTypeDtos
{
    public class FilterUserTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
