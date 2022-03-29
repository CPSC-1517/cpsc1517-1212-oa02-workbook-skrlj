#nullable disable
using System.ComponentModel.DataAnnotations;    // for [Key]
using System.ComponentModel.DataAnnotations.Schema; // for [Table]

namespace WestWindSystem.Entities
{
    [Table("Territories")]
    public class Territory
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "TerritoryID is required")]
        [StringLength(maximumLength:20, ErrorMessage = "TerritoryID is limited to 2 characters")]
        public string TerritoryID { get; set; }
        public string TerritoryDescription { get; set; }
        public int RegionID { get; set; }
    }
}