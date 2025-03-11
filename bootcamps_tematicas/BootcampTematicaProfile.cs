using AutoMapper;
using firstback.BootcampsTematicas;

namespace firstback.Mappings
{
    public class BootcampTematicaProfile : Profile
    {
        public BootcampTematicaProfile()
        {
            CreateMap<BootcampTematicaDto, BootcampTematica>();

            CreateMap<BootcampTematica, BootcampTematicaGetDto>()
                .ForMember(dest => dest.NombreBootcamp, opt => opt.MapFrom(src => src.Bootcamp != null ? src.Bootcamp.Nombre : null))
                .ForMember(dest => dest.NombreTematica, opt => opt.MapFrom(src => src.Tematica != null ? src.Tematica.Nombre : null));
        }
    }
}