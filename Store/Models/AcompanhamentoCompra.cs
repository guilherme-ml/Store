using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Models
{
    public class AcompanhamentoCompra
    {
        public int Id { get; set; }

        public DateTime DtEHrSituacao { get; set; }

        public int SituacaoCompraId { get; set; }

        public int NumeroItemCompraId { get; set; }
    }
}