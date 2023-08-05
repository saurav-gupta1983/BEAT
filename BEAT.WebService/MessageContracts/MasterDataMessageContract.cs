using System;
using System.Data;
using System.Linq;
using System.Web;
using System.ServiceModel;
using System.Collections.Generic;
using Contract = BEAT.Common.DataContracts;

namespace BEAT.WebService.MessageContracts
{
    /// <summary>
    /// MasterDataRequest
    /// </summary>
    [MessageContract]
    public class MasterDataRequest
    {
        [MessageHeader]
        public Contract.Request.Header header;

        [MessageBodyMember]
        public string tableName;
    }

    /// <summary>
    /// MasterDataResponse
    /// </summary>
    [MessageContract]
    public class MasterDataResponse
    {
        [MessageHeader]
        public Contract.Response.Header header;

        [MessageBodyMember]
        public DataTable data;
    }
}