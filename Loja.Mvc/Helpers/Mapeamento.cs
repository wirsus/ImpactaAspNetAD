using Loja.Dominio;
using Loja.Mvc.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using System;

namespace Loja.Mvc.Helpers
{
    public static class Mapeamento
    {
        public static List<ProdutoViewModel> Mapear(List<Produto> produtos)
        {
            var produtosViewModel = new List<ProdutoViewModel>();

            foreach (var produto in produtos)
            {
                produtosViewModel.Add(Mapear(produto));
            }

            return produtosViewModel;
        } 

        public static Produto Mapear(ProdutoViewModel viewModel, Categoria categoria)
        {
            var produto = new Produto();

            produto.Id = viewModel.Id;
            produto.Categoria = categoria;
            produto.Estoque = viewModel.Estoque.Value;
            produto.Nome = viewModel.Nome;
            produto.Preco = viewModel.Preco.Value;

            return produto;
        }

        public static ProdutoViewModel Mapear(Produto produto, List<Categoria> categorias = null)
        {
            var viewModel = new ProdutoViewModel();

            viewModel.CategoriaId = produto.Categoria?.ID;
            viewModel.CategoriaNome = produto.Categoria?.Nome;

            if (categorias != null)
            {
                foreach (var categoria in categorias)
                {
                    viewModel.Categorias.Add(new SelectListItem { Text = categoria.Nome, Value = categoria.ID.ToString() });
                }
            }

            viewModel.Estoque = produto.Estoque;
            viewModel.Id = produto.Id;
            viewModel.Nome = produto.Nome;
            viewModel.Preco = produto.Preco;

            return viewModel;
        }
    }
}