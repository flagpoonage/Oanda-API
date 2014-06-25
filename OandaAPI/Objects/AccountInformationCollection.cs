using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Oanda.Objects
{
    [DataContract]
    public class AccountInformationCollection
    {
        [DataMember(Name="accounts")]
        public AccountInformation[] Accounts { get; set; }
    }
}
