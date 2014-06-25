using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Oanda.Objects
{
    [DataContract]
    public class AccountInformation
    {
        [DataMember(Name="accountId")]
        public int AccountID {get;set;}
        
        [DataMember(Name="accountName")]
        public string AccountName {get;set;}
        
        [DataMember(Name="balance")]
        public decimal Balance {get;set;}
        
        [DataMember(Name="unrealizedPl")]
        public decimal UnrealizedProfitLoss {get;set;}
        
        [DataMember(Name="realizedPl")]
        public decimal RealizedProfitLoss {get;set;}
        
        [DataMember(Name="marginUsed")]
        public decimal MarginsUsed {get;set;}
        
        [DataMember(Name="marginAvail")]
        public decimal MarginAvailable {get;set;}
        
        [DataMember(Name="openTrades")]
        public int OpenTrades {get;set;}
        
        [DataMember(Name="openOrders")]
        public int OpenOrders {get;set;}
        
        [DataMember(Name="marginRate")]
        public decimal MarginRate {get;set;}
        
        [DataMember(Name="accountCurrency")]
        private string CurrencyString {get;set;}

        public AccountCurrency Currency
        {
            get
            {
                return (AccountCurrency)Enum.Parse(typeof(AccountCurrency), this.CurrencyString);
            }
        }
    }
}
