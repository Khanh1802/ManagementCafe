using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using ManagerCafe.Data.Interface;

namespace ManagerCafe.Data.Models
{
    public class WareHouse : IAutoEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        [NotMapped]
        public string Code { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime? DeletetionTime { get; set; }
        public DateTime? LastModificationTime { get; set; }
        public bool IsDeleted { get; set; }
        // Con thieu
        //public int CodeIdentity { get; set; }
        public List<Invetory> Invetories { get; set; }
    }
}
