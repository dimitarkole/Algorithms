using System;
using System.Collections.Generic;
using System.Linq;

namespace SubsetSum
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new[] { 3, 5, 2 };
            var targetSum = 17;

            var sums = GetAllSums(nums);

            if (sums.ContainsKey(targetSum))
            {
                while (targetSum>0)
                {
                    var currentSum = sums[targetSum];
                    Console.WriteLine(currentSum);
                    targetSum -= currentSum;
                }
            }
            else
            {
                Console.WriteLine("False");
            }
           
            //Console.WriteLine("All sums: " + string.Join(" ", sums));
          //  Console.WriteLine(sums.Contains(targetSum));
        }

        private static Dictionary<int, int> GetAllSums(int[] nums)
        {
            var sums = new Dictionary<int,int>() { { 0, 0 } };
            foreach (var num in nums)
            {
                var currentSums = sums.Keys.ToArray();
                foreach (var sum in currentSums)
                {
                    var newSum = sum + num;
                    if(!sums.ContainsKey(newSum))
                    {
                        sums.Add(newSum, num);
                    }
                }
            }

            return sums;
        }
    }
}
