using System.ComponentModel.DataAnnotations;

namespace Store.Models
{
    public class PrazoCondPagamento
    {
        [Key]
        public int Id { get; set; }

        public int NumeroParcelas { get; set; }

        public int CondPagamentoId { get; set; }
    }
}
