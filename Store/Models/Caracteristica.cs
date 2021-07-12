using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class Caracteristica
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(45, ErrorMessage = "Este campo dve conter no máximo 45 caracteres")]
        [MinLength(1, ErrorMessage = "Este campo deve conter no mínimo 1 caractere")]
        public string NomeCaracteristica { get; set; }

        public int IdfAtivo { get; set; }
    }
}
