using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


internal class Program
{
    static int MinimumNumberOfMoves(int[] nums)
    {

        var midNum = nums.OrderBy(x => x).ToArray()[nums.Length / 2];

        int result = 0;
        int num;

        for (int i = 0; i < nums.Length; i++)
        {
            num = nums[i];
            if (num > midNum)
            {
                while (num != midNum)
                {
                    num--;
                    result++;
                }
            }
            else if (num < midNum)
            {
                while (num != midNum)
                {
                    num++;
                    result++;
                }
            }
        }

        return result;
    }

    static void Main(string[] args)
    {
        var array = File.ReadAllText(args[0]).Split().Where(x => !string.IsNullOrWhiteSpace(x)).Select(int.Parse).ToArray();
        Console.WriteLine(MinimumNumberOfMoves(array));
    }
}