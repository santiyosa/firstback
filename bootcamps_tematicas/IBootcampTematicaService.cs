namespace FIRSTBACK.BootcampsTematicas
{
    public interface IBootcampTematicaService
    {
        Task<IEnumerable<BootcampTematica>> GetAllAsync();
        Task<BootcampTematica?> GetByIdAsync(int idBootcamp, int idTematica);
        Task<BootcampTematica> CreateAsync(BootcampTematicaDto bootcampTematicaDto);
        Task<bool> UpdateAsync(int idBootcamp, int idTematica, BootcampTematicaDto bootcampTematicaDto);
        Task<bool> DeleteAsync(int idBootcamp, int idTematica);
    }
}