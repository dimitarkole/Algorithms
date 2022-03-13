using System;

namespace SubsetSumRepetition
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new[] { 3, 5, 2 };
            var targetSum = 20;

            var sums = new bool[targetSum + 1];
            sums[0] = true;
            for (int i = 0; i < sums.Length; i++)
            {
                if (sums[i])
                {
                    foreach (var num in nums)
                    {
                        if (num + i <= targetSum)
                        {
                            sums[num + i] = true;
                        }
                    }
                }
            }

            if(sums[targetSum])
            {
                //Console.WriteLine(sums[targetSum]);
                while(targetSum > 0)
                {
                    foreach (var num in nums)
                    {
                        var prev = targetSum - num;
                        if(prev >= 0 && sums[prev])
                        {
                            targetSum -= num;
                            Console.WriteLine(num);
                        }
                    }
                }
            }
            //Console.WriteLine("All sums: " + string.Join(" ", sums));
            //  Console.WriteLine(sums.Contains(targetSum));
        }
    }
}
