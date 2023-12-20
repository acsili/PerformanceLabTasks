using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

internal class Program
{
    static string CircularArray(int n, int m)
    {
        var result = new StringBuilder();
        var array = Enumerable.Range(1, n).ToArray();
        int i = 0;

        while (true)
        {
            result.Append(array[i % array.Length]);

            for (int j = 0; j < m; j++)
                i++;

            i--;
            if (array[i % array.Length] == array[0])
                break;
        }


        return result.ToString();
    }

    static void Main(string[] args)
    {
        Console.WriteLine(CircularArray(int.Parse(args[0]), int.Parse(args[1])));
    }
}