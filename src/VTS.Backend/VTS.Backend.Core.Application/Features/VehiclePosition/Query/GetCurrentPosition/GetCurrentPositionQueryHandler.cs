using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VTS.Backend.Core.Application.Contracts;
using VTS.Backend.Core.Application.Exceptions;
using VTS.Backend.Core.Application.Features.VehiclePosition.Command.RegisterPosition;

namespace VTS.Backend.Core.Application.Features.VehiclePosition.Query.GetCurrentPosition
{
    public class GetCurrentPositionQueryHandler : IRequestHandler<GetCurrentPositionQuery, VehiclePositionDto>
    {
        private readonly IMapper _mapper;
        private readonly IVehiclePositionRepository _vehiclePositionRepository;

        public GetCurrentPositionQueryHandler(IMapper mapper, IVehiclePositionRepository vehiclePositionRepository)
        {
            _mapper = mapper;
            _vehiclePositionRepository = vehiclePositionRepository;
        }

        public async Task<VehiclePositionDto> Handle(GetCurrentPositionQuery request, CancellationToken cancellationToken)
        {
            if (request.VehicleId == Guid.Empty)
                throw new AppException($"Invalid input");

            var item = await _vehiclePositionRepository.GetLatestPosition(request.VehicleId);

            if(item == null)
                throw new KeyNotFoundException($"Invalid input");

            return _mapper.Map<VehiclePositionDto>(item);
        }
    }
}
