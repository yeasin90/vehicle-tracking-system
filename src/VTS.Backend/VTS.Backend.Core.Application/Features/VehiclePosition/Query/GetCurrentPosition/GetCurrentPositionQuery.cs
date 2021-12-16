using MediatR;
using System;
using VTS.Backend.Core.Application.Features.VehiclePosition.Command.RegisterPosition;

namespace VTS.Backend.Core.Application.Features.VehiclePosition.Query.GetCurrentPosition
{
    public class GetCurrentPositionQuery : IRequest<VehiclePositionDto>
    {
        public long VehicleId { get; set; }
    }
}
