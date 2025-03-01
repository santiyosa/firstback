using System.ComponentModel.DataAnnotations;

namespace firstback.roles
{
    public class Roles
    {
        [Key]
        public int id { get; set; }
        [Required]
        public string? rol { get; set; }
    }
}