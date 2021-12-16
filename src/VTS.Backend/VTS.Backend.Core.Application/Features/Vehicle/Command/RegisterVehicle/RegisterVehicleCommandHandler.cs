using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using VTS.Backend.Core.Application.Contracts;

namespace VTS.Backend.Core.Application.Features.Vehicle.Command.RegisterVehicle
{
    public class RegisterVehicleCommandHandler : IRequestHandler<RegisterVehicleCommand, VehicleDto>
    {
        private readonly IMapper _mapper;
        private readonly IVehicleRepository _vehicleRepository;

        public RegisterVehicleCommandHandler(IMapper mapper, IVehicleRepository vehicleRepository)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<VehicleDto> Handle(RegisterVehicleCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Domain.Entities.Vehicle>(request);
            var savedEntity = await _vehicleRepository.AddAsync(entity);
            return _mapper.Map<VehicleDto>(savedEntity);
        }
    }
}
