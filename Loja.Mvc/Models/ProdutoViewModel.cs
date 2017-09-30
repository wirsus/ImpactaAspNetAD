using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Mvc;

namespace Loja.Mvc.Models
{
    public class ProdutoViewModel
    {
        public ProdutoViewModel()
        {
            Categorias = new List<SelectListItem>();
        }
        public Int32 Id { get; set; }
        
        [Required(ErrorMessage = "Digite o nome!")]
        public String Nome { get; set; }

        [Required(ErrorMessage = "Digite o preço!")]
        [Display(Name = "Preço")]
        public Decimal? Preco { get; set; }

        [Required(ErrorMessage = "Digite o valor do estoque!")]
        public Nullable<Int32> Estoque { get; set; }

        [Display(Name = "Categoria")]
        public String CategoriaNome { get; set; }

        [Required]
        [Display(Name = "Categoria")]
        public Nullable<Int32> CategoriaId { get; set; }

        public List<SelectListItem> Categorias { get; set; }

        public HttpPostedFileBase Imagem { get; set; }
    }
}