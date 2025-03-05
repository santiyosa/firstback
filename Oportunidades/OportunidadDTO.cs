using System.ComponentModel.DataAnnotations.Schema;
using FIRSTBACK.Instituciones;

namespace FIRSTBACK.Oportunidades
{
    public class OportunidadDTO
    {
        public string nombre { get; set; } = null!;

        public string descripcion { get; set; } = null!;

        public string datos_adicionales { get; set; } = null!;

        public string canales_atencion { get; set; } = null!;

        [ForeignKey("id_institucion")]
        [InverseProperty("oportunidades")]
        public int? id_institucion { get; set; }

        [ForeignKey("id_institucion")]
        public virtual Institucion? Institucion { get; set; }
    }
}