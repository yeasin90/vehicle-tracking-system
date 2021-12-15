using System;
using System.ComponentModel.DataAnnotations;

namespace VTS.Backend.Core.Domain.Common
{
    public class AuditableEntity
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
