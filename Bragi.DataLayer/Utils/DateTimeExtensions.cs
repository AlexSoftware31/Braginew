using System;

namespace Bragi.DataLayer.Utils
{
    public static class DateTimeExtensions
    {
        public static int GetAge(this DateTime birthDate)
        {
            // Save today's date.
            var today = DateTime.Today;
            // Calculate the age.
            var age = today.Year - birthDate.Year;
            // Go back to the year the person was born in case of a leap year
            if (birthDate.Date > today.AddYears(-age)) age--;
            return age;
        }
    }
}
