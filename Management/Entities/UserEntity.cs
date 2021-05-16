using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Management.Entities
{
    [Table("User")]
    public class UserEntity : BaseEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PersonalEmailId { get; set; }
        public string CompanyEmailId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string LocalAddress { get; set; }
        public int? LocalPinId { get; set; }
        public string PermeantAddress { get; set; }
        public int? PermeantPinId { get; set; }
        public byte? Gender { get; set; }
        public byte? BloodGroup { get; set; }
        public byte? MaritalStatus { get; set; }
        public byte Status { get; set; }
        public bool IsSystemUser { get; set; }

        public ICollection<UserRoleMappingEntity> UserRoleMappingEntities { get; set; }
    }
}
