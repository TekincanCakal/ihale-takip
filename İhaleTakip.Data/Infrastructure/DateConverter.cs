namespace İhaleTakip.Data.Infrastructure
{
    using System;

    public class DateConverter
    {
        public static (int, int, string) GetCurrentDate()
        {
            DateTime date = DateTime.Now;
            int year = date.Year;
            int month = date.Month;
            string dateText = GetDateText(year, month);
            return (year, month, dateText);
        }
        public static string GetDateText(int year, int month)
        {
            string dateText;
            if (month <= 9)
            {
                dateText = year + "-0" + month;
            }
            else
            {
                dateText = year + "-" + month;
            }
            return dateText;
        }
    }
}
