using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class Fabricante
    {
        [Key]

        public int Id { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(100, ErrorMessage = "Este campo deve ter 3 e 100 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve ter 3 e 100 caracteres")]
        public string NomeFabricante { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(255, ErrorMessage = "Este campo deve ter no máximo 255 caracteres")]
        public string SiteFabricante { get; set; }

        public int IdfAtivo { get; set; }

    }
}
