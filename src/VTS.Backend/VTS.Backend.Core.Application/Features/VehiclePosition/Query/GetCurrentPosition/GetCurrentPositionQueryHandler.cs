using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VTS.Backend.Core.Application.Contracts;
using VTS.Backend.Core.Application.Features.VehiclePosition.Command.RegisterPosition;

namespace VTS.Backend.Core.Application.Features.VehiclePosition.Query.GetCurrentPosition
{
    public class GetCurrentPositionQueryHandler : IRequestHandler<GetCurrentPositionQuery, VehiclePositionDto>
    {
        private readonly IMapper _mapper;
        private readonly IVehiclePositionRepository _vehiclePositionRepository;

        public GetCurrentPositionQueryHandler(IMapper mapper, 
            IVehiclePositionRepository vehiclePositionRepository)
        {
            _mapper = mapper;
            _vehiclePositionRepository = vehiclePositionRepository;
        }

        public async Task<VehiclePositionDto> Handle(GetCurrentPositionQuery request, CancellationToken cancellationToken)
        {
            var positionEntity = await _vehiclePositionRepository.GetLatestPositionAsync(request.VehicleId);

            if (positionEntity == null)
                throw new KeyNotFoundException($"No position entry found for vehicle with id:{ request.VehicleId }");

            var result = _mapper.Map<VehiclePositionDto>(positionEntity);
            return result;
        }
    }
}
