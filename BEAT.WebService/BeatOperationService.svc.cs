using System;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Runtime.Serialization;
using System.Collections.Generic;
using Contract = BEAT.Common.DataContracts;
using BEAT.WebService.MessageContracts;
using BEAT.BusinessLayer;

namespace BEAT.WebService
{
    /// <summary>
    /// BeatOperationService
    /// </summary>
    public class BeatOperationService : IBeatOperationService
    {
        #region MasterDataOperations

        /// <summary>
        /// GetMasterData
        /// </summary>
        /// <param name="composite"></param>
        /// <returns></returns>
        public MasterDataResponse GetProducts(MasterDataRequest request)
        {
            MasterDataResponse response = new MasterDataResponse();
            response.data = BusinessObjects.GetRSyncProducts();
            return response;
        }

        #endregion
    }
}
