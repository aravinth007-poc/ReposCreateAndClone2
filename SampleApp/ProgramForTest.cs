using System;
using System.Collections.Generic;
using System.Linq;

namespace SampleApp
{
    public class ProgramForTest
    {
        public static void Main(string[] args)
        {
            string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

            int n = Convert.ToInt32(firstMultipleInput[0]);

            int k = Convert.ToInt32(firstMultipleInput[1]);

            List<int> bill = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(billTemp => Convert.ToInt32(billTemp)).ToList();

            int b = Convert.ToInt32(Console.ReadLine().Trim());

            new ProgramForTest().bonAppetit(bill, k, b);
        }

        public void bonAppetit(List<int> bill, int k, int b)
        {
            long individualTotal = (bill.Sum(x => x)) / 2;
            if ((individualTotal - (bill[k] / 2)) == b)
            {
                Console.WriteLine("Bon Appetit");
            }
            else
            {
                Console.WriteLine(bill[k] / 2);
            }
        }

    }
}
