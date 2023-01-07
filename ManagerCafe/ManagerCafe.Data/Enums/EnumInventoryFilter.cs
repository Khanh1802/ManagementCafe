using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ManagerCafe.Enums
{
    public enum EnumInventoryFilter
    {
        [Display(Name = "Còn ít số lượng nhất")]
        PriceAsc = 0,

        [Display(Name = "Còn nhiều số lượng nhất")]
        PriceDesc = 1,

        [Display(Name = "Ngày tăng dần")]
        DateAsc = 2,

        [Display(Name = "Ngày giảm dần")]
        DateDesc = 3,
    }
}
