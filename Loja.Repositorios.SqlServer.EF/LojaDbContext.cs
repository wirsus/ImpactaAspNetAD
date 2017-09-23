using Loja.Dominio;
using Loja.Repositorios.SqlServer.EF.ModelConfiguration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Loja.Repositorios.SqlServer.EF
{
    public class LojaDbContext : DbContext
    {
        public LojaDbContext():base("name=lojaConnectionString")
        {
            //pg 191 - estratégia de inicialização do banco de dados
            Database.SetInitializer(new LojaDbInitializer());

        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Configurations.Add(new ProdutoConfiguration());

            modelBuilder.Configurations.Add(new CategoriaConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
