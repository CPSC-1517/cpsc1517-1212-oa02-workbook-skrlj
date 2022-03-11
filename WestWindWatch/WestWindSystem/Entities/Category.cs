using System.ComponentModel.DataAnnotations; // for [Key], [Column]
using System.ComponentModel.DataAnnotations.Schema; // for [Table], [Required], [StringLength]

namespace WestWindSystem.Entities
{
    [Table("Categories")]
    public class Category
    {
        [Key]
        public int CategoryID { get; set; }

        // [Column("CategoryName")]
        // If we want to have different property names
        // eg:
        // public string Name { get; set; } = null!;
        [Required(ErrorMessage = "CategoryName is required")]
        [StringLength(15, ErrorMessage = "CategoryName must contain 15 or less characters")]
        public string CategoryName { get; set; } = null!;

        // Default mapping for string is to a varchar, we are telling the computer that this property maps to a ntext instead
        [Column(TypeName = "ntext")]
        public string? Description { get; set; }
    }
}
