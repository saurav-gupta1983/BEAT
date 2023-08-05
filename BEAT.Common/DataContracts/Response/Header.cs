using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BEAT.Common.DataContracts.Response
{
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Header
    {
        #region Variables

        private string guid;
        private string startTime;
        private string endTime;

        #endregion

        #region Data Members

        [DataMember]
        public string Guid
        {
            get { return guid; }
            set { guid = value; }
        }

        [DataMember]
        public string StartTime
        {
            get { return startTime; }
            set { startTime = value; }
        }

        [DataMember]
        public string EndTime
        {
            get { return endTime; }
            set { endTime = value; }
        }

        #endregion
    }
}
