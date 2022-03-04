using System.ComponentModel.DataAnnotations.Schema; // for Table
using System.ComponentModel.DataAnnotations; // for Key, Required, StringLength

namespace WestWindSystem.Entities
{
    [Table("Regions")]
    public class Region
    {
        [Key]
        public int RegionId { get; set; }
        [Required(ErrorMessage = "Region Description is required")]
        [StringLength(50, ErrorMessage = "Region Description is limited to 50 characters")]
        public string RegionDescripton { get; set; }
    }
}
