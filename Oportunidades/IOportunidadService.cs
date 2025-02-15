namespace FIRSTBACK.Oportunidades
{
    public interface IOportunidadService
    {
        Task<IEnumerable<Oportunidad>> GetAllAsync();
        Task<Oportunidad?> GetByIdAsync(int id);
        Task CreateAsync(Oportunidad oportunidad);
        Task UpdateAsync(int id, Oportunidad oportunidad);
        Task DeleteAsync(int id);
    }

}