using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace dotNetAcademy.BLL.Rules
{
    public class DurationDotNetAcademy:ValidationAttribute
    {
        private const int _shortTerm = 3;

        public static bool IsLongEnough(DateTime start, DateTime end)
        {
            var predictedEndDate = start.AddMonths(_shortTerm);
            return end >= predictedEndDate;
        }

    }
}
