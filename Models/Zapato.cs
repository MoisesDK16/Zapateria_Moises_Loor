using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Zapateria.Models
{
    public class Zapato
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Marca { get; set; }

        [Required]
        public string Modelo { get; set; }

        [Required]
        public string Color { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un tipo.")]
        public int TipoId { get; set; }

        [ForeignKey("TipoId")]
        public Tipo? Tipo { get; set; }
    }

}
