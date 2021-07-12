using Microsoft.EntityFrameworkCore;
using Store.Models;
namespace Store.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<AcompanhamentoCompra> Acompanhamento { get; set; }
        public DbSet<Caracteristica> Caracteristica { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<CondPagamento> Condicao { get; set; }
        public DbSet<Departamento> Departamento { get; set; }
        public DbSet<Grupo> Grupo { get; set; }
        public DbSet<ItemCompra> ItemCompra { get; set; }
        public DbSet<PrazoCondPagamento> PrazoCondPagamento { get; set; }
        public DbSet<ProdutoCaracteristica> ProdCaracteristica { get; set; }
        public DbSet<Promocao> Promocao { get; set; }
        public DbSet<PromoProduto> PromoProduto { get; set; }
        public DbSet<SituacaoCompra> Situacaocompra { get; set; }
    }
}
