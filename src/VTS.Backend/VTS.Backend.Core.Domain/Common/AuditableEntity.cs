using System;
using System.ComponentModel.DataAnnotations;

namespace VTS.Backend.Core.Domain.Common
{
    public class AuditableEntity
    {
        [Key]
        public long Id { get; set; }
        public double CreatedDateTimeStampInSeconds { get; set; }
    }
}
