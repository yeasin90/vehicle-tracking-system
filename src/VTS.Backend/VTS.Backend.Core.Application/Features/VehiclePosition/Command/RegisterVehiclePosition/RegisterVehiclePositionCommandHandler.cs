using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VTS.Backend.Core.Application.Contracts;
using VTS.Backend.Core.Application.Exceptions;

namespace VTS.Backend.Core.Application.Features.VehiclePosition.Command.RegisterVehiclePosition
{
    public class RegisterVehiclePositionCommandHandler : IRequestHandler<RegisterVehiclePositionCommand, VehiclePositionDto>
    {
        private readonly IMapper _mapper;
        private readonly IVehiclePositionRepository _vehiclePositionRepository;

        public RegisterVehiclePositionCommandHandler(IMapper mapper, IVehiclePositionRepository vehiclePositionRepository)
        {
            _mapper = mapper;
            _vehiclePositionRepository = vehiclePositionRepository;
        }

        public async Task<VehiclePositionDto> Handle(RegisterVehiclePositionCommand request, CancellationToken cancellationToken)
        {
            if (request.Latitude == 0 || request.Longitude == 0)
                throw new AppException($"{nameof(request.Latitude)} or {nameof(request.Longitude)} cannot be zero");

            var entity = _mapper.Map<Domain.Entities.VehiclePosition>(request);
            var savedEntity = await _vehiclePositionRepository.AddAsync(entity);
            return _mapper.Map<VehiclePositionDto>(savedEntity);
        }
    }
}
