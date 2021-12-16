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
            var item = await _vehiclePositionRepository.GetLatestPositionAsync(request.VehicleId);

            if(item == null)
                throw new KeyNotFoundException($"Cannot find any vehicle with id:{ request.VehicleId }");

            var result = _mapper.Map<VehiclePositionDto>(item);
            return result;
        }
    }
}
