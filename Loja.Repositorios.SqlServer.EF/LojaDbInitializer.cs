using System;
using System.Data.Entity;
using System.Linq;
using Loja.Dominio;
using System.Collections.Generic;

namespace Loja.Repositorios.SqlServer.EF
{
    internal class LojaDbInitializer : DropCreateDatabaseIfModelChanges<LojaDbContext>
    {
        protected override void Seed(LojaDbContext context)
        {
            if (!context.Categorias.Any())
            {
                context.Categorias.AddRange(ObterCategorias());
                context.SaveChanges();
            }

            if (!context.Produtos.Any())
            {
                context.Produtos.AddRange(ObterProdutos(context));
                context.SaveChanges();
            }

            base.Seed(context);
        }

        private IEnumerable<Produto> ObterProdutos(LojaDbContext context)
        {
            var grampeador = new Produto();
            grampeador.Nome = "Grampeador";
            grampeador.Preco = 17.27M;
            grampeador.Estoque = 27;
            grampeador.Descont = true;
            grampeador.Categoria = context.Categorias.Single(c => c.Nome == "Papelaria");


            var penDrive = new Produto();
            penDrive.Nome = "PenDrive";
            penDrive.Preco = 36.21M;
            penDrive.Estoque = 32;
            penDrive.Descont = true;
            penDrive.Categoria = context.Categorias.Single(c => c.Nome == "Informática");

            var perfume = new Produto();
            perfume.Nome = "Perfume";
            perfume.Preco = 89.44M;
            perfume.Estoque = 6;
            perfume.Descont = true;
            perfume.Categoria = context.Categorias.Single(c => c.Nome == "Perfumaria");

            //return new List<Produto> { grampeador, penDrive, perfume};

            var produtos = new List<Produto>();
            produtos.Add(grampeador);
            produtos.Add(penDrive);
            produtos.Add(perfume);

            return produtos;
        }

        private List<Categoria> ObterCategorias()
        {
            return new List<Categoria> {
                new Categoria {Nome = "Informática" },
                new Categoria {Nome = "Papelaria" },
                new Categoria {Nome = "Perfumaria" }
            };

            
        }
    }
}