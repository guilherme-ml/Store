using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class SituacaoCompra
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(1000, ErrorMessage = "Esse campo deve conter no maximo 1000 caracteres")]
        public string DescSituacaoCompra { get; set; }

        public int IdfAtivo { get; set; }
    }
}
