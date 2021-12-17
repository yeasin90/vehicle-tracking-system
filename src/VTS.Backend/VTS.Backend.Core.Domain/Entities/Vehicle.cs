using System;
using System.Collections.Generic;
using VTS.Backend.Core.Domain.Common;

namespace VTS.Backend.Core.Domain.Entities
{
    public class Vehicle : AuditableEntity
    {
        public string SerialNumber { get; set; }
        public Guid UserId { get; set; }
        public List<VehiclePosition> Positions { get; set; }
    }
}
