namespace FIRSTBACK.BootcampsTematicas
{
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
}