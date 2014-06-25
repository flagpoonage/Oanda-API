using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oanda.Core
{
    public class HttpResponseWrapper<T>
    {
        public T ResponseValue { get; set; }

        public Exception ResponseError { get; set; }

        internal HttpResponseWrapper()
        {
        }
    }
}
