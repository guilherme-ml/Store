using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(45, ErrorMessage = "Este campo deve ter 3 e 45 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve ter 3 e 45 caracteres")]
        public string NomeCategoria { get; set; }

        public int PosCategoria { get; set; }

        public int IdfAtivo { get; set; }


        public int DepartamentoId { get; set; }

    }
}