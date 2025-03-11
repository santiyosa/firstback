using AutoMapper;

namespace firstback.Oportunidades
{
    public class OportunidadProfile : Profile
    {
        public OportunidadProfile()
        {
            CreateMap<OportunidadDTO, Oportunidad>();
            CreateMap<Oportunidad, OportunidadDTO>();

            CreateMap<Oportunidad, OportunidadesInstitucionesDTO>()
                .ForMember(dest => dest.NombreInstitucion, opt => opt.MapFrom(src => src.Institucion != null ? src.Institucion.id : 0))
                .ForMember(dest => dest.NombreInstitucion, opt => opt.MapFrom(src => src.Institucion != null ? src.Institucion.nombre : null));
        }
    }
}