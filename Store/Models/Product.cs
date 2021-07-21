using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(255, ErrorMessage = "Este campo deve ter 3 e 255 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve ter 3 e 60 caracteres")]
        public string NomeProduto { get; set; }


        [MaxLength(3000, ErrorMessage = "Este campo deve conter no máximo 3000 caracteres")]
        [MinLength(1, ErrorMessage = "Este campo deve conter no mínimo 1 caractere")]
        public string DescProduto { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O preço deve ser maior que zero")]
        public float PrecoProduto { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]

        public string CategoriaProduto { get; set; }

        public int IdfAtivo { get; set; }

        public int FabricanteId { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
