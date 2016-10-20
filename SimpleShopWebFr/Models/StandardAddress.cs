using System.ComponentModel.DataAnnotations;

namespace SimpleShopWebFr.Models
{
    public class StandardAddress : MyObject
    {
        [Required]
        public virtual string ProvinceName { get; set; }

        [Required]
        public virtual string CityName { get; set; }

        public virtual string AreaName { get; set; }
    }
}