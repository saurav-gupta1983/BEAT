using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BEAT.Common.DataContracts.Request
{
    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Header
    {
        #region Variables

        private string team;
        private string location;
        private string identifier;
        private string ipAddress;
        private string machineName;

        #endregion

        #region Data Members

        [DataMember]
        public string Team
        {
            get { return team; }
            set { team = value; }
        }

        [DataMember]
        public string Location
        {
            get { return location; }
            set { location = value; }
        }

        [DataMember]
        public string Identifier
        {
            get { return identifier; }
            set { identifier = value; }
        }

        [DataMember]
        public string IPAddress
        {
            get { return ipAddress; }
            set { ipAddress = value; }
        }

        [DataMember]
        public string MachineName
        {
            get { return machineName; }
            set { machineName = value; }
        }

        #endregion
    }
}
