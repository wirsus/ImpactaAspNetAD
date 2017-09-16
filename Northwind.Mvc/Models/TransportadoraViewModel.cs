using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Northwind.Mvc.Models
{
    public class TransportadoraViewModel
    {
        public Int32 ID { get; set; }

        [Required(ErrorMessage = "Digite o nome!")]
        public String Nome { get; set; }

        public String Telefone { get; set; }
    }
}