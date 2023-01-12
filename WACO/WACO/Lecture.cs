using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WACO
{
    public class Lecture
    {
        public double AmountLectured { get; set; }
        public string  ?MonthPeriod { get; set; }
        private DateTime DateTime;

        public Lecture(double amountLectured) {
            AmountLectured= amountLectured;
        }
        public Lecture(double amountLectured, string month, DateTime dateTime)
        {
            AmountLectured = amountLectured;
            MonthPeriod= month;
            DateTime = dateTime;
        }
    }
}
