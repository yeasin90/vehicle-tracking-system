﻿using VTS.Backend.Core.Domain.Common;

namespace VTS.Backend.Core.Domain.Entities
{
    public class VehiclePosition : AuditableEntity
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public Vehicle Vehilce { get; set; }
    }
}