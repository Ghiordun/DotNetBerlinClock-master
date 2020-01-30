using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    { 
        private const string newRow = "\r\n";
        private const string redColor = "R";
        private const string yellowColor = "Y";
        private const string blank = "O";

        /// <summary>
        /// This method is used to convert a given time to the Berlin Uhr.
        /// </summary>
        /// <param name="aTime"></param>
        /// <returns>The Berlin Uhr</returns>
        public StringBuilder ConvertTime(string aTime)
        {
            var items = aTime.Split(':');
            var hour = short.Parse(items[0]);
            var minutes = short.Parse(items[1]);
            var second = short.Parse(items[2]);           

            return (ConvertSeconds(second).Append(ConvertHours(hour)).Append(ConvertMinutes(minutes)));
        }

        /// <summary>
        /// This method is used to convert the seconds to the Berlin Uhr seconds.
        /// </summary>
        /// <param name="second"></param>
        /// <returns>The converted seconds.</returns>
        public StringBuilder ConvertSeconds(short seconds)
        {
            var result = new StringBuilder();
            if (seconds % 2 == 0)
                result.Append(yellowColor);
            else
                result.Append(blank);

            return result.Append(newRow);

        }

        /// <summary>
        /// This method is used to convert the hours to the Berlin Uhr hours.
        /// </summary>
        /// <param name="hour"></param>
        /// <returns>The converted hours.</returns>
        public StringBuilder ConvertHours(short hour)
        {        
            var result = new StringBuilder();
            var count = (hour / 5);
            var difference = (hour - (count * 5));
            for (int iteration = 0; iteration < count; iteration++)
            {
                result.Append(redColor);
            }

            for (int iteration = count; iteration < 4; iteration++)
            {
                result.Append(blank);
            }

            result.Append(newRow);
            for (int iteration = 0; iteration < difference; iteration++)
            {
                result.Append(redColor);
            }

            for (int iteration = difference; iteration < 4; iteration++)
            {
                result.Append(blank);
            }
            result.Append(newRow);
            return result;
        }

        /// <summary>
        /// This method is used to convert the minutes to the Berlin Uhr minutes.
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns>The converted minutes.</returns>
        public StringBuilder ConvertMinutes(short minutes)
        {
            var result = new StringBuilder();
            var count = (minutes / 5);
            var difference = (minutes - (count * 5));
            for (int iteration = 0; iteration < count; iteration++)
            {
                if (iteration == 2 || iteration == 5 || iteration == 8)
                    result.Append(redColor);
                else
                    result.Append(yellowColor);
            }

            for (int iteration = count; iteration < 11; iteration++)
            {
                result.Append(blank);
            }

            result.Append(newRow);
            for (int iteration = 0; iteration < difference; iteration++)
            {
                result.Append(yellowColor);
            }

            for (int iteration = difference; iteration < 4; iteration++)
            {
                result.Append(blank);
            }

            return result;
        }
    }
}
