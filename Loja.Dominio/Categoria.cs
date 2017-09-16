using System;
using System.Collections.Generic;

namespace Loja.Dominio
{
    public class Categoria
    {
        public Int32 ID { get; set; }
        //Ligar LAZY LOAD 
        public /*virtual*/ List<Produto> Produtos { get; set; }
        public String Nome { get; set; }
    }
}