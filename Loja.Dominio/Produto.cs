﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.Dominio
{
    public class Produto
    {
        public Int32 Id { get; set; }
        //virtual - ligar o LAZY LOAD
        public virtual Categoria Categoria { get; set; }
        public virtual ProdutoImagem Imagem { get; set; }
        public String Nome { get; set; }
        public Decimal Preco { get; set; }
        public Int32 Estoque { get; set; }
        public bool Ativo { get; set; }

    }
}
