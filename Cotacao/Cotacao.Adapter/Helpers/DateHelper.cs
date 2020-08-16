using System;
using System.Globalization;

namespace Cotacao.Adapter.Helpers
{
    public static class DateHelper
    {
        public const string DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
        public const string DateFormat = "yyyy-MM-dd";

        public static DateTime ParseDateTime(string date)
        {
            return DateTime.ParseExact(date, new[] { DateFormat, DateTimeFormat }, CultureInfo.InvariantCulture, DateTimeStyles.None);
        }
    }
}
