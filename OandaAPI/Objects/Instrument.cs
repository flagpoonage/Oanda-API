using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Oanda.Objects
{
    [DataContract]
    public class InstrumentDetails
    {
        [DataMember(Name = "instrument")]
        private string InstrumentValue { get; set; }

        public InstrumentType Instrument
        {
            get
            {
                return this.InstrumentValue.AsEnumOfType<InstrumentType>();
            }
            set
            {
                this.InstrumentValue = value.GetValue();
            }
        }

        [DataMember(Name = "displayName")]
        public string DisplayName { get; set; }

        [DataMember(Name = "pip")]
        public decimal PipValue { get; set; }

        [DataMember(Name = "maxTradeUnits")]
        public decimal MaxTradeUnits { get; set; }
    }
}
