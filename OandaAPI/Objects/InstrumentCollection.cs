using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Oanda.Objects
{
    [DataContract]
    internal class InstrumentCollection
    {
        [DataMember(Name="instruments")]
        public InstrumentDetails[] Instruments { get; set; }
    }
}
