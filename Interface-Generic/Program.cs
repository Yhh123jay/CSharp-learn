using System;
using System.Collections;

namespace Interface_Generic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ArrayList nums1 = new ArrayList { 1, 2, 3, 4, 3 };
           
            Console.WriteLine(Sum(nums1));
            
        }

        static int Sum(IEnumerable nums)
        {
            int sum = 0;
            foreach (var n in nums) sum += (int)n;
            return sum;
        }
        static double Avg(IEnumerable nums)
        {
            int sum = 0;
            int count = 0;
            foreach (var n in nums) {
                sum += (int)n;
                count++;
            }
           
            return sum/count;
        }
    }


}
