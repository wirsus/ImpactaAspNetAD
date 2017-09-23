using AdventureWorks.Repositorios.SqlServer.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AdventureWorks.Wcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IProdutos
    {

        [OperationContract]
        Product Get(int id);

        [OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);
        List<Product> GetByName(String name);

        // TODO: Add your service operations here
    }

}
