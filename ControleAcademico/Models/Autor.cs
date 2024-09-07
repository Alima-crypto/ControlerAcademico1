using System.ComponentModel.DataAnnotations;

namespace ControleAcademico1.Models
{
    public class Autor
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required]
        [StringLength(100)]
        public string Curso { get; set; }
    }
}
