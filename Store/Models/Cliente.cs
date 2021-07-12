using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(100, ErrorMessage = "Este campo dve conter no máximo 100 caracteres")]
        [MinLength(1, ErrorMessage = "Este campo deve conter no mínimo 1 caractere")]
        public string NomeCliente  { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(255, ErrorMessage = "Este campo dve conter no máximo 255 caracteres")]
        [MinLength(1, ErrorMessage = "Este campo deve conter no mínimo 1 caractere")]
        public string EnderecoCliente { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(11, ErrorMessage = "Este campo dve conter no máximo 11 caracteres")]
        [MinLength(1, ErrorMessage = "Este campo deve conter no mínimo 1 caractere")]
        public string CpfCliente { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(8, ErrorMessage = "Este campo dve conter no máximo 8 caracteres")]
        [MinLength(1, ErrorMessage = "Este campo deve conter no mínimo 1 caractere")]
        public string CepCliente { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(45, ErrorMessage = "Este campo dve conter no máximo 45 caracteres")]
        [MinLength(1, ErrorMessage = "Este campo deve conter no mínimo 1 caractere")]
        public string BairroCliente { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(11, ErrorMessage = "Este campo dve conter no máximo 11 caracteres")]
        [MinLength(1, ErrorMessage = "Este campo deve conter no mínimo 1 caractere")]
        public string TelefoneFixCliente { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(100, ErrorMessage = "Este campo dve conter no máximo 100 caracteres")]
        [MinLength(1, ErrorMessage = "Este campo deve conter no mínimo 1 caractere")]
        public string CelularCliente { get; set; }
    }
}
