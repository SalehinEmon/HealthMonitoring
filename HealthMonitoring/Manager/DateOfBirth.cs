using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthMonitoring.Manager
{
    public static class DateOfBirth
    {
        public static DateTime GetAgeFromDateofBirth(DateTime dateOfBirth)
        {
            DateTime currentDate = DateTime.Now;
            DateTime age = new DateTime() + (currentDate - dateOfBirth);

            age = age.AddDays(-1);
            age = age.AddMonths(-1);
            age = age.AddYears(-1);

            return age;

        }
    }
}