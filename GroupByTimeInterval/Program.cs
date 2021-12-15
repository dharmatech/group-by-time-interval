using System;
using System.Collections.Generic;
using System.Linq;

namespace GroupByTimeInterval
{
    public class Program
    {


        public static void Main(string[] args)
        {
            // 3 years of data
            //var values = Enumerable.Range(0, 100000000).Select(i => new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(i));

            var values = Enumerable.Range(0, 10000000).Select(i => new DateTime(2020, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMinutes(i));

            var interval = 13;

            var result = values
                .GroupBy(trade =>
                    (long)
                    Math.Round(
                        (trade.Year * 12 + trade.Month) / ((double)interval),
                        0,
                        MidpointRounding.AwayFromZero))
                .Select(group => group.Min());

            foreach (var elt in result.Take(100))
            {
                Console.WriteLine("{0:yyyy-MM-dd HH mm ss}", elt);
            }

            //foreach (var elt in result.Take(10))
            //{
            //    Console.WriteLine("{0:yyyy-MM-dd HH mm ss}", elt);
            //}
        }
    }
}