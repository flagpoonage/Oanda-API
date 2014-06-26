using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oanda.Objects
{
    public class InstrumentTypeList : List<InstrumentType>
    {
        public string AsQuery()
        {
            return Uri.EscapeUriString(
                this.Select(a => a.GetValue())
                    .Aggregate((a, b) => string.Format("{0},{1}", a, b)));
        }
    }
}
