using System;

namespace Loja.Dominio
{
    public class ProdutoImagem
    {
        public Int32 ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
        public byte[] Bytes { get; set; }
        public string ContentType { get; set; }
    }
}