using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VTS.Backend.Core.Application.Contracts;

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
            var entity = _mapper.Map<Domain.Entities.VehiclePosition>(request);
            var savedEntity = await _vehiclePositionRepository.AddAsync(entity);
            return _mapper.Map<VehiclePositionDto>(savedEntity);
        }
    }
}
