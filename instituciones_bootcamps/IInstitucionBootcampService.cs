using FIRSTBACK.InstitucionesBootcamps;
using FIRSTBACK.Dtos;

namespace FIRSTBACK.Services
{
    public interface IInstitucionBootcampService
    {
        Task<IEnumerable<InstitucionBootcamp>> GetAllAsync();
        Task<InstitucionBootcamp?> GetByIdAsync(int idInstitucion, int idBootcamp);
        Task<InstitucionBootcamp> CreateAsync(InstitucionBootcampDto institucionBootcampDto);
        Task<bool> UpdateAsync(int idInstitucion, int idBootcamp, InstitucionBootcampDto institucionBootcampDto);
        Task<bool> DeleteAsync(int idInstitucion, int idBootcamp);
    }
}
