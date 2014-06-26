using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Oanda.Objects
{
    [DataContract]
    public enum InstrumentType
    {
        [EnumMember(Value="EUR_USD")]
        EURUSD,
        [EnumMember(Value = "EUR_GBP")]
        EURGBP,
        [EnumMember(Value = "AUD_CAD")]
        AUDCAD,
        [EnumMember(Value = "EUR_AUS")]
        EURAUS,
        [EnumMember(Value = "EUR_NZD")]
        EURNZD
    }

    public static class InstrumentTypeExtensions
    {
        public static string GetValue(this Enum enumValue)
        {
            var type = enumValue.GetType();
            var info = type.GetField(enumValue.ToString());
            var da = (EnumMemberAttribute[])(info.GetCustomAttributes(typeof(EnumMemberAttribute), false));

            if (da.Length > 0)
                return da[0].Value;
            else
                return string.Empty;
        }

        public static T AsEnumOfType<T>(this string value)
        {
            var type = typeof(T);

            var fields = type.GetFields();

            foreach (var f in fields)
            {
                var attributes = f.GetCustomAttributes(typeof(EnumMemberAttribute), false);

                if (attributes == null || attributes.Length == 0)
                {
                    continue;
                }

                var enumMembers = (EnumMemberAttribute[])attributes;

                if (enumMembers[0].Value == value)
                {
                    var o = (T)Activator.CreateInstance<T>();

                    foreach (T item in Enum.GetValues(typeof(T)))
                    {
                        return (T)f.GetRawConstantValue();
                    }
                }
            }

            return default(T);
        }
    }
}
