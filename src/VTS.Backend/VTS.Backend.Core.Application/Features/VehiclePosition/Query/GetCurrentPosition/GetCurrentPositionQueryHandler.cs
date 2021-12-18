using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VTS.Backend.Core.Application.Contracts;
using VTS.Backend.Core.Application.Features.VehiclePosition.Command.RegisterPosition;
using VTS.Backend.Infrastructure.GoogleMapService;

namespace VTS.Backend.Core.Application.Features.VehiclePosition.Query.GetCurrentPosition
{
    public class GetCurrentPositionQueryHandler : IRequestHandler<GetCurrentPositionQuery, VehiclePositionDto>
    {
        private readonly IMapper _mapper;
        private readonly IVehiclePositionRepository _vehiclePositionRepository;
        private readonly IVtsGoogleMapService _vtsGmapService;

        public GetCurrentPositionQueryHandler(IMapper mapper, 
            IVehiclePositionRepository vehiclePositionRepository,
            IVtsGoogleMapService vtsGmapService)
        {
            _mapper = mapper;
            _vehiclePositionRepository = vehiclePositionRepository;
            _vtsGmapService = vtsGmapService;
        }

        public async Task<VehiclePositionDto> Handle(GetCurrentPositionQuery request, CancellationToken cancellationToken)
        {
            var positionEntity = await _vehiclePositionRepository.GetLatestPositionAsync(request.VehicleId);

            if (positionEntity == null)
                throw new KeyNotFoundException($"No position entry found for vehicle with id:{ request.VehicleId }");

            var result = _mapper.Map<VehiclePositionDto>(positionEntity);
            result.LocationName = await _vtsGmapService.GetLocationName(result.Latitude, result.Longitude);
            return result;
        }
    }
}
