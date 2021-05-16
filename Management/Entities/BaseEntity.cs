using System;

namespace Management.Entities
{
    public class BaseEntity
    {
        public int CreatedById { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? ModifiedById { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
