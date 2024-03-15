using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatetimeExp
{
    internal static class DateTImeOffSetExtension
    {
        public static DateTime ToDateTime(this DateTimeOffset date)
        {
            date = date - date.Offset;
            return (new DateTime(date.Year, date.Month, date.Day, date.Hour, date.Minute, date.Second, date.Millisecond, date.Microsecond));
        }
    }
}
