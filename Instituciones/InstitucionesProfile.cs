using AutoMapper;

namespace FIRSTBACK.Instituciones
{
    public class InstitucionProfile : Profile
    {
        public InstitucionProfile()
        {
            CreateMap<InstitucionDTO, Institucion>();
            CreateMap<Institucion, InstitucionDTO>();
        }
    }
}