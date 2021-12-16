using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VTS.Backend.Core.Application.Contracts;
using VTS.Backend.Core.Application.Exceptions;
using VTS.Backend.Core.Application.Extensions;

namespace VTS.Backend.Core.Application.Features.VehiclePosition.Command.RegisterPosition
{
    public class RegisterPositionCommandHandler : IRequestHandler<RegisterPositionCommand, VehiclePositionDto>
    {
        private readonly IMapper _mapper;
        private readonly IVehiclePositionRepository _vehiclePositionRepository;
        private readonly IVehicleRepository _vehicleRepository;

        public RegisterPositionCommandHandler(IMapper mapper, 
            IVehiclePositionRepository vehiclePositionRepository,
            IVehicleRepository vehicleRepository)
        {
            _mapper = mapper;
            _vehiclePositionRepository = vehiclePositionRepository;
            _vehicleRepository = vehicleRepository;
        }

        public async Task<VehiclePositionDto> Handle(RegisterPositionCommand request, CancellationToken cancellationToken)
        {
            if (request.Latitude == 0 || request.Longitude == 0)
                throw new AppException($"{nameof(request.Latitude)} or {nameof(request.Longitude)} cannot be zero");

            var existingVehicle = await _vehicleRepository.GetByIdAsync(request.VehilceId);

            if (existingVehicle == null)
                throw new AppException($"Cannot find any vehilce with id:{request.VehilceId}");

            var entity = new Domain.Entities.VehiclePosition()
            {
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                CreatedDateTimeStampInSeconds = DateTime.UtcNow.ToUnixTimeStampInSeconds(),
                Vehilce = existingVehicle
            };

            var savedEntity = await _vehiclePositionRepository.AddAsync(entity);
            return _mapper.Map<VehiclePositionDto>(savedEntity);
        }
    }
}
