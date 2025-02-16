using AutoMapper;

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
        }
    }
}