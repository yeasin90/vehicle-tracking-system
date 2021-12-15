using AutoMapper;
using VTS.Backend.Core.Application.Features.VehiclePosition.Command.RegisterVehiclePosition;
using VTS.Backend.Core.Domain.Entities;

namespace VTS.Backend.Core.Application.Profiles
{
    public class VehiclePositionProfile : Profile
    {
        public VehiclePositionProfile()
        {
            CreateMap<VehiclePosition, RegisterVehiclePositionDto>().ReverseMap();
            CreateMap<VehiclePosition, RegisterVehiclePositionCommand>().ReverseMap();
        }
    }
}
