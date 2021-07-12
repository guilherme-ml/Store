using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class Departamento
    {
        [Key]
        public int Id { get; set; }


        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(45, ErrorMessage = "Este campo deve ter 2 e 45 caracteres")]
        [MinLength(2, ErrorMessage = "Este campo deve ter 2 e 45 caracteres")]
        public string NomeDepartamento { get; set; }

        public int IdfAtivo { get; set; }

        public int GrupoId { get; set; }
    }
}
