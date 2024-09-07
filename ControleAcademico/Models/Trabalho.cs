using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ControleAcademico1.Models
{
    public class Trabalho
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Titulo { get; set; }

        [Required]
        public TipoTrabalho Tipo { get; set; }

        // Relação com Autor
        [ForeignKey("Autor")]
        public int AutorId { get; set; }
        public Autor Autor { get; set; }

        // Relação com Orientador
        [ForeignKey("Orientador")]
        public int OrientadorId { get; set; }
        public Orientadores Orientador { get; set; }
    }
}
