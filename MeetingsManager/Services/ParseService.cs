using System;
using System.Collections.Generic;
using System.Text;

namespace MeetingsManager.Services
{
    public class ParseService
    {
        private const string DATE_FORMAT = "MM/dd/yyyy hh:mm tt";
        public DateTime ParseDate (string date)
        {
            DateTime theDate;
            bool result = DateTime.TryParseExact(
                date,
                DATE_FORMAT,
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.None,
                out theDate);

            if (!result)
            {
                return DateTime.MinValue;
            }
            else
            {
                return theDate;
            }
        }

        public int ParseInt (string number)
        {
            
            bool success = int.TryParse(number, out int result);
            if (success)
            {
                return result;
            }
            else
            {
                return -1;
            }
        }
    }
}
