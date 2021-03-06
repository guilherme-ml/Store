using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class PromoProduto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        public float PrecoProduto { get; set; }

        public int CondicaoPagamentoID { get; set; }

        public int Promocao { get; set; }

        public int ProdutoId { get; set; }

    }
}
