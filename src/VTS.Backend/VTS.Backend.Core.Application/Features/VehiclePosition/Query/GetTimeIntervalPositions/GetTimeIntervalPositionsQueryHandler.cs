using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VTS.Backend.Core.Application.Contracts;
using VTS.Backend.Core.Application.Features.VehiclePosition.Command.RegisterPosition;

namespace VTS.Backend.Core.Application.Features.VehiclePosition.Query.GetTimeIntervalPositions
{
    public class GetTimeIntervalPositionsQueryHandler : IRequestHandler<GetTimeIntervalPositionsQuery, IEnumerable<VehiclePositionDto>>
    {
        private readonly IMapper _mapper;
        private readonly IVehiclePositionRepository _vehiclePositionRepository;
        private readonly IVehicleRepository _vehicleRepository;

        public GetTimeIntervalPositionsQueryHandler(IMapper mapper, 
            IVehiclePositionRepository vehiclePositionRepository,
            IVehicleRepository vehicleRepository)
        {
            _mapper = mapper;
            _vehiclePositionRepository = vehiclePositionRepository;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<IEnumerable<VehiclePositionDto>> Handle(GetTimeIntervalPositionsQuery request, CancellationToken cancellationToken)
        {
            var item = await _vehicleRepository.GetByIdAsync(request.VehicleId);

            if (item == null)
                throw new KeyNotFoundException($"Cannot find any vehicle with id:{ request.VehicleId }");

            var entities = await _vehiclePositionRepository.GetPositionsAsync(request.VehicleId, request.FromTimeStampInSeconds, request.ToTimeStampInSeconds);
            var results = _mapper.Map<IEnumerable<VehiclePositionDto>>(entities);
            return results;
        }
    }
}
