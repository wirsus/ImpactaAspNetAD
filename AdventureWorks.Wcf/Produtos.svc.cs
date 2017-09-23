using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using AdventureWorks.Repositorios.SqlServer.EF;

namespace AdventureWorks.Wcf
{
    public class Produtos : IProdutos
    {
        public Product Get(int id)
        {
            //var produto = new AdventureWorks2012Entities:base("name=AdventureWorks2012Entities");
            using (var dbContext = new AdventureWorks2012Entities())
            {
                return dbContext.Products.Find(id);
            }
        }

        public List<Product> GetByName(string name)
        {
            using (var dbContext = new AdventureWorks2012Entities())
            {
                return dbContext.Products.Where(c => c.Name.Contains(name)).ToList() ;
            }
        }
    }
}
