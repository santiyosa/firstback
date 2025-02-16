using System.Collections.Generic;
using System.Threading.Tasks;
using FIRSTBACK.Tematicas;
using FIRSTBACK.Dtos;

public interface IBootcampTematicaService
{
    Task<IEnumerable<BootcampTematica>> GetAllAsync();
    Task<BootcampTematica?> GetByIdAsync(int idBootcamp, int idTematica);
    Task<BootcampTematica> CreateAsync(BootcampTematicaDto bootcampTematicaDto);
    Task<bool> UpdateAsync(int idBootcamp, int idTematica, BootcampTematicaDto bootcampTematicaDto);
    Task<bool> DeleteAsync(int idBootcamp, int idTematica);
}
