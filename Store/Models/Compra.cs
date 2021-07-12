using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Compra
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MinLength(1, ErrorMessage = "Esse campo deve conter no mínimo 1 caractere")]
        public string DtEHrCompra { get; set; }


        public int ClienteId { get; set; }


        public int CondPagamento { get; set; }
    }
}
