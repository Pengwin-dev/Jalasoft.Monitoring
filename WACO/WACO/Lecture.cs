using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WACO
{
    public class Lecture
    {
        public int UserCi { get; set; }
        public double AmountLectured { get; set; }
        public string? MonthPeriod { get; set; }
        public DateTime time;

        public Lecture (int userCi,double amountLectured)
        {
            this.UserCi = userCi;
            this.AmountLectured = amountLectured;
        }
        public Lecture(int userCi, double amountLectured,string monthPeriod,int year,int month,int day,int hour,int min)
        {
            UserCi = userCi;
            AmountLectured = (int)Math.Truncate(amountLectured); ;
            MonthPeriod = monthPeriod;
            time = new DateTime(year, month, day, hour,min,0);
        }
    }
}
