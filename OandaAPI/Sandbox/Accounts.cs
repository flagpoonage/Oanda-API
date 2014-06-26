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

        public static UserAccount CreateTestAccount()
        {
            var result = HttpClient.Post<UserAccount>(new HttpRequestConfiguration()
            {
                RequestAddress = BaseAddress
            });

            return result.ResponseValue;
        }

        public static AccountInformation GetAccountInformation(int accountID)
        {
            var result = HttpClient.Get<AccountInformation>(new HttpRequestConfiguration()
            {
                RequestAddress = string.Format("{0}/{1}", BaseAddress, accountID)
            });

            return result.ResponseValue;
        }

        public static AccountInformation[] GetUserAccounts(string username)
        {
            var qs = new NameValueCollection();

            qs.Add("username", username);

            var result = HttpClient.Get<AccountInformationCollection>(new HttpRequestConfiguration()
            {
                RequestAddress = BaseAddress,
                Querystring = qs
            });

            return result.ResponseValue.Accounts;
        }
    }
}
