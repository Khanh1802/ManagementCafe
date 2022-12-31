namespace ManagerCafe.Data.Interface
{
    public interface IAutoEntity
    {
        public DateTime CreateTime { get; set; }
        public DateTime ?DeletetionTime { get; set; }
        public DateTime ?LastModificationTime { get; set; }
        public bool IsDeleted { get; set; }
    }
}
