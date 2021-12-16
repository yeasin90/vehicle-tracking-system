using MediatR;
using System;
using System.Collections.Generic;
using VTS.Backend.Core.Application.Features.VehiclePosition.Command.RegisterPosition;

namespace VTS.Backend.Core.Application.Features.VehiclePosition.Query.GetTimeIntervalPositions
{
    public class GetTimeIntervalPositionsQuery : IRequest<IEnumerable<VehiclePositionDto>>
    {
        public long VehicleId { get; set; }
        public double FromTimeStampInSeconds { get; set; }
        public double ToTimeStampInSeconds { get; set; }
    }
}
