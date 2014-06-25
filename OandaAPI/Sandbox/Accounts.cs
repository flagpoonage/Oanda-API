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
    public static class Accounts
    {
        private static string BaseAddress = "http://api-sandbox.oanda.com/v1/accounts";

        public static HttpResponseWrapper<UserAccount> CreateTestAccount()
        {
            return HttpClient.Post<UserAccount>(new HttpRequestConfiguration()
            {
                RequestAddress = BaseAddress
            });
        }

        public static HttpResponseWrapper<AccountInformation> GetAccountInformation(int accountID)
        {
            return HttpClient.Get<AccountInformation>(new HttpRequestConfiguration()
            {
                RequestAddress = string.Format("{0}/{1}", BaseAddress, accountID)
            });
        }

        public static HttpResponseWrapper<AccountInformationCollection> GetUserAccounts(string username)
        {
            var qs = new NameValueCollection();

            qs.Add("username", username);

            return HttpClient.Get<AccountInformationCollection>(new HttpRequestConfiguration()
            {
                RequestAddress = BaseAddress,
                Querystring = qs
            });
        }
    }
}
