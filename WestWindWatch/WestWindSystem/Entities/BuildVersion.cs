using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations.Schema; // for Table
using System.ComponentModel.DataAnnotations; // for Key

namespace WestWindSystem.Entities
{
    [Table("BuildVersion")]
    public class BuildVersion
    {
        [Key]
        public int Id { get; set; }
        public int Major { get; set; }
        public int Minor { get; set; }
        public int Build { get; set; }
        public DateTime ReleaseDate { get; set; }
    }
}
