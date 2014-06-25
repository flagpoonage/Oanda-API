using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Oanda.Core
{
    internal class HttpClient
    {
        internal static HttpResponseWrapper<T> Post<T>(HttpRequestConfiguration requestData)
        {
            var querystring = string.Empty;

            if (requestData.Querystring != null)
            {
                querystring = HttpClient.StringifyCollection(requestData.Querystring);
            }

            if (!string.IsNullOrEmpty(querystring))
            {
                requestData.RequestAddress = string.Format("{0}?{1}", requestData.RequestAddress, querystring);
            }

            var request = HttpWebRequest.Create(requestData.RequestAddress);

            request.Method = "POST";

            if (requestData.RequestHeaders != null)
            {
                request.Headers.Add(requestData.RequestHeaders);
            }

            if (requestData.BodyData != null)
            {
                using (var sw = request.GetRequestStream())
                {
                    var bodystream = HttpClient.StringifyCollection(requestData.BodyData);

                    var buffer = Encoding.Default.GetBytes(bodystream);

                    sw.Write(buffer, 0, buffer.Length);
                }
            }

            WebResponse response = null;

            try
            {
                response = request.GetResponse();
            }
            catch (Exception ex)
            {
                return new HttpResponseWrapper<T>()
                {
                    ResponseError = ex
                };
            }

            try
            {
                using (var sr = response.GetResponseStream())
                {
                    var value = new HttpResponseWrapper<T>();
                    var dcs = new DataContractJsonSerializer(typeof(T));

                    value.ResponseValue = (T)dcs.ReadObject(sr);

                    return value;
                }
            }
            catch (Exception ex)
            {
                return new HttpResponseWrapper<T>()
                {
                    ResponseError = ex
                };
            }
        }

        private static string StringifyCollection(NameValueCollection collection)
        {
            var list = new List<string>();
            for (int i = 0; i < collection.Count; i++)
            {
                var key = collection.GetKey(i);

                list.Add(string.Format("{0}={1}", key, collection.GetValues(key).First()));
            }

            return list.Aggregate((a, b) => string.Format("{0}&{1}", a, b));
        }

        internal static HttpResponseWrapper<T> Get<T>(HttpRequestConfiguration requestData)
        {
            var querystring = string.Empty;

            if (requestData.Querystring != null)
            {
                querystring = HttpClient.StringifyCollection(requestData.Querystring);
            }

            if (!string.IsNullOrEmpty(querystring))
            {
                requestData.RequestAddress = string.Format("{0}?{1}", requestData.RequestAddress, querystring);
            }

            var request = HttpWebRequest.Create(requestData.RequestAddress);

            request.Method = "GET";

            if (requestData.RequestHeaders != null)
            {
                request.Headers.Add(requestData.RequestHeaders);
            }

            WebResponse response = null;

            try
            {
                response = request.GetResponse();
            }
            catch (Exception ex)
            {
                return new HttpResponseWrapper<T>()
                {
                    ResponseError = ex
                };
            }

            try
            {
                using (var sr = response.GetResponseStream())
                {
                    var value = new HttpResponseWrapper<T>();
                    var dcs = new DataContractJsonSerializer(typeof(T));

                    value.ResponseValue = (T)dcs.ReadObject(sr);

                    return value;
                }
            }
            catch (Exception ex)
            {
                return new HttpResponseWrapper<T>()
                {
                    ResponseError = ex
                };
            }
        }
    }
}
