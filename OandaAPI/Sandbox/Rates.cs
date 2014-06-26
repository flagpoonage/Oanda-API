using Oanda.Core;
using Oanda.Objects;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oanda.Sandbox
{
    public class Rates
    {
        private static string BaseAddress = "http://api-sandbox.oanda.com/v1/instruments";
        
        private static InstrumentDetails[] CallAPI(NameValueCollection querystring)
        {
            return HttpClient.Get<InstrumentCollection>(new HttpRequestConfiguration()
            {
                RequestAddress = BaseAddress,
                Querystring = querystring
            }).ResponseValue.Instruments;
        }

        public static InstrumentDetails[] GetInstrumentList(int accountID)
        {
            var qs = new NameValueCollection();

            qs.Add("accountId", accountID.ToString());

            return CallAPI(qs);
        }

        public static InstrumentDetails[] GetInstrumentList(int accountID, InstrumentFields fields)
        {
            var qs = new NameValueCollection();

            qs.Add("accountId", accountID.ToString());

            if (fields != null && fields.Any())
            {
                qs.Add("fields", fields.AsQuery());
            }

            return CallAPI(qs);
        }

        public static InstrumentDetails[] GetInstrumentList(int accountID, InstrumentTypeList instruments)
        {
            var qs = new NameValueCollection();

            qs.Add("accountId", accountID.ToString());

            if (instruments != null && instruments.Any())
            {
                qs.Add("instruments", instruments.AsQuery());
            }
            return CallAPI(qs);
        }

        public static InstrumentDetails[] GetInstrumentList(int accountID, InstrumentFields fields, InstrumentTypeList instruments)
        {
            var qs = new NameValueCollection();

            qs.Add("accountId", accountID.ToString());

            if (fields != null && fields.Any())
            {
                qs.Add("fields", fields.AsQuery());
            }

            if (instruments != null && instruments.Any())
            {
                qs.Add("instruments", instruments.AsQuery());
            }

            return CallAPI(qs);
        }
    }
}
