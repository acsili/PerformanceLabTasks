using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

internal class Program
{
    static int PointPosition(float[] array1, float[] array2)
    {
        for (int i = 0; i < array2.Length - 1; i += 2)
        {
            return Math.Pow(array2[i] + array1[0], 2) + Math.Pow(array2[i + 1] + array1[1], 2) == array1[2] * array1[2] ? 0 :
                 Math.Pow(array2[i] + array1[0], 2) + Math.Pow(array2[i + 1] + array1[1], 2) < array1[2] * array1[2] ? 1 : 2;
        }

        return 3;
    }


    static void Main(string[] args)
    {
        var array1 = File.ReadAllText(args[0]).Split().Where(x => !string.IsNullOrWhiteSpace(x)).Select(float.Parse).ToArray();
        var array2 = File.ReadAllText(args[1]).Split().Where(x => !string.IsNullOrWhiteSpace(x)).Select(float.Parse).ToArray();

        Console.WriteLine(PointPosition(array1, array2));
    }
}
