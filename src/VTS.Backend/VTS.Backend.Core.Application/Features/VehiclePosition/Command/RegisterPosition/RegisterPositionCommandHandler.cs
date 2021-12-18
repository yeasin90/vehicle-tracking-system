using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using VTS.Backend.Core.Application.Contracts;
using VTS.Backend.Core.Application.Exceptions;
using VTS.Backend.Core.Application.Extensions;
using VTS.Backend.Core.Application.Services;

namespace VTS.Backend.Core.Application.Features.VehiclePosition.Command.RegisterPosition
{
    public class RegisterPositionCommandHandler : IRequestHandler<RegisterPositionCommand, VehiclePositionDto>
    {
        private readonly IMapper _mapper;
        private readonly IVehiclePositionRepository _vehiclePositionRepository;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUserService _userService;

        public RegisterPositionCommandHandler(IMapper mapper, 
            IVehiclePositionRepository vehiclePositionRepository,
            IVehicleRepository vehicleRepository,
            IUserService userService)
        {
            _mapper = mapper;
            _vehiclePositionRepository = vehiclePositionRepository;
            _vehicleRepository = vehicleRepository;
            _userService = userService;
        }

        public async Task<VehiclePositionDto> Handle(RegisterPositionCommand request, CancellationToken cancellationToken)
        {
            var currentUser = _userService.GetCurrentUser();
            var existingVehicle = await _vehicleRepository.Find(x => x.UserId == currentUser.UserId && x.Id == request.VehicleId);

            if (request.Latitude == 0 || request.Longitude == 0)
                throw new AppException($"{nameof(request.Latitude)} or {nameof(request.Longitude)} cannot be zero");
            if(existingVehicle == null)
                throw new AppException($"VehicleId:{request.VehicleId} is not found or not registered for userId:{currentUser.UserId}");

            var entity = new Domain.Entities.VehiclePosition()
            {
                Latitude = request.Latitude,
                Longitude = request.Longitude,
                CreatedDateTimeStampInSeconds = DateTime.UtcNow.ToUnixTimeStampInSeconds(),
                VehicleId = request.VehicleId
            };

            var savedEntity = await _vehiclePositionRepository.Insert(entity);
            var result = _mapper.Map<VehiclePositionDto>(savedEntity);
            return result;
        }
    }
}
