using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management.Entities
{
    [Table("Mst_Menu")]
    public class MenuEntity 
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MenuId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int? ParentMenuId { get; set; }
        public byte DisplayOrder { get; set; }
        public byte Status { get; set; }
    }
}
