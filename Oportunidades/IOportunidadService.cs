namespace firstback.Oportunidades
{
    public interface IOportunidadService
    {
        Task<IEnumerable<OportunidadesInstitucionesDTO>> GetAllAsync();
        Task<OportunidadesInstitucionesDTO?> GetByIdAsync(int id);
        Task CreateAsync(Oportunidad oportunidad);
        Task UpdateAsync(int id, Oportunidad oportunidad);
        Task DeleteAsync(int id);
    }
}