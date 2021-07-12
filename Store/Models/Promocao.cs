using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Promocao
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(45, ErrorMessage = "Este campo deve conter no máximo 45 caracteres")]
        [MinLength(1, ErrorMessage = "Este campo deve conter no mínimo 1 caractere")]
        public string NomePromo { get; set; }

        public DateTime DtInicioPromo { get; set; }

        public DateTime DtFimPromo { get; set; }
    }
}
