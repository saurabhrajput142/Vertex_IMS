using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management.Entities
{
    [Table("Role_MenuMapping")]
    public class RoleMenuMappingEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleMenuMappingId { get; set; }
        public int MenuId { get; set; }
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual RoleEntity RoleEntity { get; set; }

        [ForeignKey("MenuId")]
        public virtual MenuEntity MenuEntity { get; set; }

    }
}
