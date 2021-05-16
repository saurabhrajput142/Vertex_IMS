using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management.Entities
{
    [Table("User_RoleMapping")]
    public class UserRoleMappingEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserRoleMappingId { get; set; }
        public int UserId { get; set; }
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual RoleEntity RoleEntity { get; set; }

        [ForeignKey("UserId")]
        public virtual UserEntity UserEntity { get; set; }

    }
}
