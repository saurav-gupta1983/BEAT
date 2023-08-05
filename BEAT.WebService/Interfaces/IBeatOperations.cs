using System;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
using System.Collections.Generic;
using BEAT.Common.DataContracts;
using BEAT.WebService.MessageContracts;

namespace BEAT.WebService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Name = "BeatOperationService")]
    public interface IBeatOperationService
    {
        [OperationContract]
        MasterDataResponse GetProducts(MasterDataRequest request);
        // TODO: Add your service operations here
    }
}
