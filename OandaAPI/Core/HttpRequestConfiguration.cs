using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oanda.Core
{
    internal class HttpRequestConfiguration
    {
        internal NameValueCollection BodyData { get; set; }

        internal NameValueCollection Querystring { get; set; }

        internal NameValueCollection RequestHeaders { get; set; }

        internal string RequestAddress { get; set; }
    }
}
