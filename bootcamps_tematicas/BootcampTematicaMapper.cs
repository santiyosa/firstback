using FIRSTBACK.Tematicas;
using FIRSTBACK.Dtos;

public static class BootcampTematicaMapper
{
    public static BootcampTematica MapToEntity(BootcampTematicaDto dto)
    {
        return new BootcampTematica
        {
            IdBootcamp = dto.IdBootcamp,
            IdTematica = dto.IdTematica
        };
    }
}
