using System;
using VTS.Backend.Core.Domain.Common;

namespace VTS.Backend.Core.Domain.Entities
{
    public class VehiclePosition : AuditableEntity
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public long VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
    }
}
