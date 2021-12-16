using AutoMapper;
using VTS.Backend.Core.Application.Extensions;
using VTS.Backend.Core.Application.Features.VehiclePosition.Command.RegisterPosition;
using VTS.Backend.Core.Domain.Entities;

namespace VTS.Backend.Core.Application.Profiles
{
    public class VehiclePositionProfile : Profile
    {
        public VehiclePositionProfile()
        {
            CreateMap<VehiclePosition, VehiclePositionDto>()
                .ForMember(dest => dest.CreatedDateTime, src => src.MapFrom(x => x.CreatedDateTimeStampInSeconds.ToUtcDateTime()))
                .ReverseMap();

            CreateMap<VehiclePosition, RegisterPositionCommand>().ReverseMap();
        }
    }
}
