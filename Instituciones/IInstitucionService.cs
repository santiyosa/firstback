
namespace FIRSTBACK.Instituciones
{
    public interface IInstitucionService
    {
        Task<IEnumerable<Institucion>> GetAllAsync();
        Task<Institucion?> GetByIdAsync(int id);
        Task CreateAsync(Institucion institucion);
        Task UpdateAsync(int id, Institucion institucion);
        Task DeleteAsync(int id);

    }
    
}