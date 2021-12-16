﻿using MediatR;
using System;

namespace VTS.Backend.Core.Application.Features.VehiclePosition.Command.RegisterPosition
{
    public class  RegisterPositionCommand : IRequest<VehiclePositionDto>
    {
        public Guid VehilceId { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; } 
    }
}
