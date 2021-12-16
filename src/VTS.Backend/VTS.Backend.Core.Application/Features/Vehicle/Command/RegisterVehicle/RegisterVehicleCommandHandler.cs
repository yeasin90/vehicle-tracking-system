using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VTS.Backend.Core.Application.Contracts;
using VTS.Backend.Core.Application.Exceptions;
using VTS.Backend.Core.Application.Extensions;

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
            if (string.IsNullOrWhiteSpace(request.SerialNumber))
                throw new AppException($"{nameof(request.SerialNumber)} cannot be empty");

            var entity = new Domain.Entities.Vehicle()
            {
                SerialNumber = request.SerialNumber,
                CreatedDateTimeStampInSeconds = DateTime.UtcNow.ToUnixTimeStampInSeconds()
            };

            var savedEntity = await _vehicleRepository.AddAsync(entity);
            return _mapper.Map<VehicleDto>(savedEntity);
        }
    }
}
