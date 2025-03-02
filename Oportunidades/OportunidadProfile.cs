using AutoMapper;
using firstback.Oportunidades;

namespace FIRSTBACK.Oportunidades
{
    public class OportunidadProfile : Profile
    {
        public OportunidadProfile()
        {
            // De DTO a Entidad
            CreateMap<OportunidadDTO, Oportunidad>();
            // De Entidad a DTO
            CreateMap<Oportunidad, OportunidadDTO>();

                       CreateMap<Oportunidad, OportunidadesInstitucionesDTO>()
                .ForMember(dest => dest.NombreInstitucion, opt => opt.MapFrom(src => src.Institucion != null ? src.Institucion.id : 0))
                .ForMember(dest => dest.NombreInstitucion, opt => opt.MapFrom(src => src.Institucion != null ? src.Institucion.nombre : null));
   
        }
    }
}