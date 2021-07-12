using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class ProdutoCaracteristica
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(100, ErrorMessage = "Este campo dve conter no máximo 100 caracteres")]
        [MinLength(1, ErrorMessage = "Este campo deve conter no mínimo 1 caractere")]
        public string ValorCaracteristica { get; set; }


        public int ProdutoId { get; set; }

        public int CaracteristicaId { get; set; }

    }
}
