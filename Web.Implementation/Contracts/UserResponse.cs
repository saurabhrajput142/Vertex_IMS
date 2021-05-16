using Management.Enums;
using System;

namespace Web.Implementation.Contracts
{
    public class UserResponse
    {
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
        public UserStatus Status { get; set; }
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
