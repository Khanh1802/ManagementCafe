using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ManagerCafe.Data.Interface;

namespace ManagerCafe.Data.Models
{
    public class Invetory : IAutoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public Guid WareHouseId { get; set; }
        public DateTime CreateTime { get; set; } = DateTime.Now;
        public DateTime? DeletetionTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public bool IsDeleted { get; set; }
        public int Quatity { get; set; }
        public Product Product { get; set; }
        public WareHouse WareHouse { get; set; }
    }
}
