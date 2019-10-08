using System;
using System.Collections.Generic;

namespace Utilities
{
    public class TimeHelper
    {
        public string GetFormatDate(DateTime dt, char Separator)
        {
            if (dt != null && !dt.Equals(DBNull.Value))
            {
                string tem = string.Format("yyyy{0}MM{1}dd", Separator, Separator);
                return dt.ToString(tem);
            }
            else
            {
                return GetFormatDate(DateTime.Now, Separator);
            }
        }
        public string GetFormatTime(DateTime dt, char Separator) {
            if (dt != null && !dt.Equals(DBNull.Value))
            {
                string tem = string.Format("hh{0}mm{1}ss", Separator, Separator);
                return dt.ToString(tem);
            }
            else
            {
                return GetFormatDate(DateTime.Now, Separator);
            }
        }
        public static int SecondToMinute(int Second)
        {
            decimal mm = (decimal)((decimal)Second / (decimal)60);
            return Convert.ToInt32(Math.Ceiling(mm));
        }
        
        public static int GetMonthLastDate(int year, int month)
        {
            DateTime lastDay = new DateTime(year, month, new System.Globalization.GregorianCalendar().GetDaysInMonth(year, month));
            int Day = lastDay.Day;
            return Day;
        }
        public static string DateDiff(DateTime DateTime1, DateTime DateTime2)
        {
            string dateDiff = null;
            try
            {
                //TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
                //TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
                //TimeSpan ts = ts1.Subtract(ts2).Duration();
                TimeSpan ts = DateTime2 - DateTime1;
                if (ts.Days >= 1)
                {
                    dateDiff = DateTime1.Month.ToString() + "月" + DateTime1.Day.ToString() + "日";
                }
                else
                {
                    if (ts.Hours > 1)
                    {
                        dateDiff = ts.Hours.ToString() + "小时前";
                    }
                    else
                    {
                        dateDiff = ts.Minutes.ToString() + "分钟前";
                    }
                }
            }
            catch
            { }
            return dateDiff;
        }
        
        public static TimeSpan DateDiff2(DateTime DateTime1, DateTime DateTime2)
        {
            TimeSpan ts1 = new TimeSpan(DateTime1.Ticks);
            TimeSpan ts2 = new TimeSpan(DateTime2.Ticks);
            TimeSpan ts = ts1.Subtract(ts2).Duration();
            return ts;
        }
        
        public static string FormatDate(DateTime dateTime1, string dateMode)
        {
            switch (dateMode)
            {
                case "0":
                    return dateTime1.ToString("yyyy-MM-dd");
                case "1":
                    return dateTime1.ToString("yyyy-MM-dd HH:mm:ss");
                case "2":
                    return dateTime1.ToString("yyyy/MM/dd");
                case "3":
                    return dateTime1.ToString("yyyy年MM月dd日");
                case "4":
                    return dateTime1.ToString("MM-dd");
                case "5":
                    return dateTime1.ToString("MM/dd");
                case "6":
                    return dateTime1.ToString("MM月dd日");
                case "7":
                    return dateTime1.ToString("yyyy-MM");
                case "8":
                    return dateTime1.ToString("yyyy/MM");
                case "9":
                    return dateTime1.ToString("yyyy年MM月");
                default:
                    return dateTime1.ToString();
            }
        }
        public static DateTime GetRandomTime(DateTime time1, DateTime time2)
        {
            Random random = new Random();
            DateTime minTime = new DateTime();
            DateTime maxTime = new DateTime();

            System.TimeSpan ts = new System.TimeSpan(time1.Ticks - time2.Ticks);
            
            double dTotalSecontds = ts.TotalSeconds;
            int iTotalSecontds = 0;

            if (dTotalSecontds > System.Int32.MaxValue)
            {
                iTotalSecontds = System.Int32.MaxValue;
            }
            else if (dTotalSecontds < System.Int32.MinValue)
            {
                iTotalSecontds = System.Int32.MinValue;
            }
            else
            {
                iTotalSecontds = (int)dTotalSecontds;
            }


            if (iTotalSecontds > 0)
            {
                minTime = time2;
                maxTime = time1;
            }
            else if (iTotalSecontds < 0)
            {
                minTime = time1;
                maxTime = time2;
            }
            else
            {
                return time1;
            }

            int maxValue = iTotalSecontds;

            if (iTotalSecontds <= System.Int32.MinValue)
                maxValue = System.Int32.MinValue + 1;

            int i = random.Next(System.Math.Abs(maxValue));

            return minTime.AddSeconds(i);
        }
    }
   public static class DateTimeUtility
    {
        public static DateTime? ParseToDateValue(string dateString)
        {
            if (String.IsNullOrEmpty(dateString)) return null;
            DateTime dtValue;
            if (!DateTime.TryParse(dateString, out dtValue)) return null;
            return dtValue;
        }
        public static DateTime? ParseToDateValue(object dateObj)
        {
            if (dateObj == null) return null;
            DateTime dtValue;
            if (!DateTime.TryParse(dateObj.ToString(), out dtValue)) return null;
            return dtValue;
        }

        public static string FormatDate(string dateString)
        {
            var dt = ParseToDateValue(dateString);
            if (dt == null)
            {
                return string.Empty;
            }
            else
            {
                return string.Format("{0:yyyy-MM-dd}", dt);
            }
        }

        public static string FormatDate(DateTime? date)
        {
            if (date == null)
            {
                return string.Empty;
            }
            else
            {
                return string.Format("{0:yyyy-MM-dd}", date);
            }
        }

        public static string FormatDate(object date)
        {
            if (date == null)
            {
                return string.Empty;
            }
            else
            {
                return string.Format("{0:yyyy-MM-dd}", date);
            }
        }

        public static string FormatDateTime(object date)
        {
            if (date == null)
            {
                return string.Empty;
            }
            else
            {
                return string.Format("{0:yyyy-MM-dd HH:mm}", date);
            }
        }
        
        public static DateTime? ConvertObjectToNullableDate(object obj)
        {
            if (obj == null) return null;
            DateTime tmpDateTime;
            if (DateTime.TryParse(obj.ToString(), out tmpDateTime) == true)
                return tmpDateTime;
            else
                return null;

        }
        
        public static string FormatDateTime(DateTime dateValue, string dataFormat)
        {
            string result = null;
            try
            {
                result = dateValue.ToString(dataFormat);
            }
            catch
            {
            }
            return result;
        }

        
        public static double GetYearsOfTwoDate(DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null || endDate == null) return 0;
            int months = DateTimeUtility.GetMonthsOfTwoDate(startDate, endDate);


            double totalyears = months / 12d;
            return double.Parse(string.Format("{0:N2}", totalyears));
        }
        
        public static int GetMonthsOfTwoDate(DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null || endDate == null) return 0;
            int months = ((endDate.Value.Year - startDate.Value.Year) * 12) + (endDate.Value.Month - startDate.Value.Month);
            if (endDate.Value.Day < startDate.Value.Day)
            {
                months--;
            }
            return months;
        }
        
        public static string GetDaysOfTwoDate(DateTime? startDate, DateTime? endDate)
        {
            if (startDate == null || endDate == null) return string.Empty;
            TimeSpan TimSpan = endDate.Value.Subtract(startDate.Value);
            return TimSpan.Days.ToString();
        }
        public static DateTime? GetStartDateOfQuarter(int year, int quarter)
        {
            string strDt = year.ToString() + "-" + ((quarter - 1) * 3 + 1).ToString() + "-1";
            return ParseToDateValue(strDt);
        }
        public static DateTime? GetStartDateOfHalfYear(int year, int halfYear)
        {
            //halfYear=6 or 12
            string m = halfYear == 6 ? "1" : "7";
            string strDt = year.ToString() + "-" + m + "-1";
            return ParseToDateValue(strDt);
        }
        public static DateTime? GetEndDateOfQuarter(int year, int quarter)
        {
            var startDt = GetStartDateOfQuarter(year, quarter);
            if (startDt == null) return null;
            return startDt.Value.AddMonths(3).AddDays(-1);
        }
        public static int GetQuarter(this DateTime input)
        {
            if ((input.Month % 3) > 0)
                return (input.Month / 3 + 1);
            else
                return (input.Month / 3);
        }
        public static DateTime? GetStartDateOfMonth(int year, int month)
        {
            string strDt = year.ToString() + "-" + month.ToString() + "-1";
            return ParseToDateValue(strDt);
        }
        public static DateTime? GetEndDateOfMonth(int year, int month)
        {
            var startDt = GetStartDateOfMonth(year, month);
            if (startDt == null) return null;
            return startDt.Value.AddMonths(1).AddDays(-1);
        }
        public static DateTime GetWeekUpOfDate(DateTime dt, DayOfWeek weekday, int Number)
        {
            int wd1 = (int)weekday;
            int wd2 = (int)dt.DayOfWeek;
            return wd2 == wd1 ? dt.AddDays(7 * Number) : dt.AddDays(7 * Number - wd2 + wd1);
        }
        
        public static int WeekOfMonth(DateTime day, int WeekStart)
        {
            DateTime FirstofMonth;
            FirstofMonth = Convert.ToDateTime(day.Date.Year + "-" + day.Date.Month + "-" + 1);

            int i = (int)FirstofMonth.Date.DayOfWeek;
            if (i == 0)
            {
                i = 7;
            }

            if (WeekStart == 1)
            {
                return (day.Date.Day + i - 2) / 7 + 1;
            }
            if (WeekStart == 2)
            {
                return (day.Date.Day + i - 1) / 7;

            }
            return 0;
        }

        public static List<int> GetYearArray(int start)
        {
            List<int> lst = new List<int>();
            for (var i = start; i <= DateTime.Today.Year; i++)
            {
                lst.Add(i);
            }
            return lst;
        }

        public static DateTime? ParseYearMonthToDateTimeValue(string ymString)
        {
            if (String.IsNullOrEmpty(ymString)) return null;
            ymString = ymString.Replace("年", "-").Replace("月", "-1");
            string dateString = ymString;

            DateTime dtValue;
            if (!DateTime.TryParse(dateString, out dtValue)) return null;
            return dtValue;
        }
        public static string ParseDateToYearMonth(object dt)
        {
            var dtObj = ParseToDateValue(dt);
            if (dtObj == null) return string.Empty;
            return string.Format("{0}年{1}月", dtObj.Value.Year, dtObj.Value.Month);
        }
        public static string ParseDateToFullDate(object dt)
        {
            var dtObj = ParseToDateValue(dt);
            if (dtObj == null) return string.Empty;
            return string.Format("{0}年{1}月{2}日", dtObj.Value.Year, dtObj.Value.Month, dtObj.Value.Day);
        }
        
        public static bool CompareCurrentQuarter(string year, string quarter, string seq)
        {
            bool result = false;
            string currentYear = DateTime.Now.Year.ToString();
            int currentMonth = MonthConvertToQuarter(DateTime.Now.Month);
            int calculateYear = int.Parse(year) + int.Parse(seq) - 1;

            result = int.Parse(currentYear + currentMonth) >= int.Parse(calculateYear + quarter) ? false : true;
            return result;
        }
        
        public static int MonthConvertToQuarter(int month)
        {
            return month / 3 + (month % 3 > 0 ? 1 : 0);
        }
        public static bool IsBiggerCurrentDate(string className, string outSeq, string month)
        {
            bool result = false;

            //计算年份
            string caculateYearMonth = (int.Parse(className) + int.Parse(outSeq) - 1) + month;
            string currentYearMonth = DateTime.Now.ToString("yyyyMM");
            result = int.Parse(caculateYearMonth) > int.Parse(currentYearMonth) ? true : false;
            return result;
        }
        
        public static bool CompareCurrentYearMonth(string year, string month)
        {
            var date = DateTime.Now;
            return new DateTime(date.Year, date.Month, 2) <= new DateTime(Convert.ToInt32(year), Convert.ToInt32(month), 1);
        }
    }
}
