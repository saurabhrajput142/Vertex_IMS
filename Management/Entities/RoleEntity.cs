using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management.Entities
{
    [Table("Role")]
    public class RoleEntity: BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoleId { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public byte Status { get; set; }
        public bool IsSystemRole { get; set; }

        public ICollection<RoleMenuMappingEntity> RoleMenuMappingEntities  { get; set; }
    }
}
