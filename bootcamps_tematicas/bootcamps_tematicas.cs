using System.ComponentModel.DataAnnotations.Schema;
using BackendProject.Data;  // Espacio de nombres donde está Bootcamp
using FIRSTBACK.Tematicas;  // Espacio de nombres donde está Tematica

namespace FIRSTBACK.Tematicas
{
    public class BootcampTematica
    {
        [ForeignKey("Bootcamp")]
        public int IdBootcamp { get; set; }

        [ForeignKey("Tematica")]
        public int IdTematica { get; set; }

        public Bootcamp Bootcamp { get; set; } = null!;
        public Tematica Tematica { get; set; } = null!;
    }
}
