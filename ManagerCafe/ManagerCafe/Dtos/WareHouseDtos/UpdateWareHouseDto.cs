using ManagerCafe.Data.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace ManagerCafe.Dtos.WareHouseDtos
{
    public class UpdateWareHouseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
