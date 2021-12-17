using AutoMapper;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using VTS.Backend.Core.Application.Contracts;
using VTS.Backend.Core.Application.Exceptions;
using VTS.Backend.Core.Application.Extensions;
using VTS.Backend.Core.Application.Services;

namespace VTS.Backend.Core.Application.Features.Vehicle.Command.RegisterVehicle
{
    public class RegisterVehicleCommandHandler : IRequestHandler<RegisterVehicleCommand, VehicleDto>
    {
        private readonly IMapper _mapper;
        private readonly IVehicleRepository _vehicleRepository;
        private readonly IUserService _userService;

        public RegisterVehicleCommandHandler(IMapper mapper, IVehicleRepository vehicleRepository, IUserService userService)
        {
            _mapper = mapper;
            _vehicleRepository = vehicleRepository;
            _userService = userService;
        }

        public async Task<VehicleDto> Handle(RegisterVehicleCommand request, CancellationToken cancellationToken)
        {
            if (string.IsNullOrWhiteSpace(request.SerialNumber))
                throw new AppException($"{nameof(request.SerialNumber)} cannot be empty");
            if (await _vehicleRepository.GetBySerialNumberAsync(request.SerialNumber) != null)
                throw new AppException($"A vehicle with same serial:{request.SerialNumber} already exist");

            var currentUser = _userService.GetCurrentUser();

            var entity = new Domain.Entities.Vehicle()
            {
                SerialNumber = request.SerialNumber,
                UserId = currentUser.UserId,
                CreatedDateTimeStampInSeconds = DateTime.UtcNow.ToUnixTimeStampInSeconds()
            };

            var savedEntity = await _vehicleRepository.AddAsync(entity);
            return _mapper.Map<VehicleDto>(savedEntity);
        }
    }
}
