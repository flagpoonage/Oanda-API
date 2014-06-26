using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oanda.Objects
{
    public class InstrumentFields
    {
        public bool DisplayName {get;set;}

        public bool Pip {get;set;}

        public bool MaxTradeUnits {get;set;}

        public bool Precision {get;set;}

        public bool MaxTrailingStop {get;set;}

        public bool MinTrailingStop {get;set;}

        public bool MarginRate {get;set;}

        public string AsQuery()
        {
            var pList = new List<string>();
            if(DisplayName) pList.Add("displayName");
            if(Pip) pList.Add("pip");
            if(MaxTradeUnits) pList.Add("maxTradeUnits");
            if(Precision) pList.Add("precision");
            if(MaxTrailingStop) pList.Add("maxTrailingStop");
            if(MinTrailingStop) pList.Add("minTrailingStop");
            if(MarginRate) pList.Add("marginRate");

            return Uri.EscapeUriString(pList.Aggregate((a,b) => string.Format("{0},{1}", a, b)));
        }

        internal bool Any()
        {
            return DisplayName || Pip || MaxTradeUnits || Precision || MaxTrailingStop || MinTrailingStop || MarginRate;
        }
    }
}
