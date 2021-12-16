using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using VTS.Backend.Core.Application.Contracts;
using VTS.Backend.Core.Application.Exceptions;
using VTS.Backend.Core.Application.Features.VehiclePosition.Command.RegisterPosition;

namespace VTS.Backend.Core.Application.Features.VehiclePosition.Query.GetTimeIntervalPositions
{
    public class GetTimeIntervalPositionsQueryHandler : IRequestHandler<GetTimeIntervalPositionsQuery, IEnumerable<VehiclePositionDto>>
    {
        private readonly IMapper _mapper;
        private readonly IVehiclePositionRepository _vehiclePositionRepository;

        public GetTimeIntervalPositionsQueryHandler(IMapper mapper, IVehiclePositionRepository vehiclePositionRepository)
        {
            _mapper = mapper;
            _vehiclePositionRepository = vehiclePositionRepository;
        }

        public async Task<IEnumerable<VehiclePositionDto>> Handle(GetTimeIntervalPositionsQuery request, CancellationToken cancellationToken)
        {
            var item = await _vehiclePositionRepository.GetLatestPositionAsync(request.VehicleId);

            if (item == null)
                throw new KeyNotFoundException($"Cannot find any vehicle with id:{ request.VehicleId }");

            var entities = await _vehiclePositionRepository.GetPositionsAsync(request.VehicleId, request.FromTimeStampInSeconds, request.ToTimeStampInSeconds);
            var results = _mapper.Map<IEnumerable<VehiclePositionDto>>(entities);
            return results;
        }
    }
}
