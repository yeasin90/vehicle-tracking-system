using AutoMapper;
using VTS.Backend.Core.Application.Extensions;
using VTS.Backend.Core.Application.Features.Vehicle.Command.RegisterVehicle;
using VTS.Backend.Core.Domain.Entities;

namespace VTS.Backend.Core.Application.Profiles
{
    public class VehicleProfile : Profile
    {
        public VehicleProfile()
        {
            CreateMap<Vehicle, VehicleDto>()
                .ForMember(dest => dest.CreatedDateTime, src => src.MapFrom(x => x.CreatedDateTimeStampInSeconds.ToUtcDateTime()))
                .ReverseMap();

            CreateMap<Vehicle, RegisterVehicleCommand>().ReverseMap();
        }  
    }
}
