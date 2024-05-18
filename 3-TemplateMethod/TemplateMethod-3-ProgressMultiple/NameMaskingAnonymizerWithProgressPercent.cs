using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_Extensibility;

public class NameMaskingAnonymizerWithProgressPercent: NameMaskingAnonymizer
{
    public NameMaskingAnonymizerWithProgressPercent(string inputFileName, string mask): base(inputFileName, mask)
    {
    }

    protected override void PrintProgress(int count, int index)
    {
        int percentage = (int)((double)(index+1) / count * 100);

        Console.Write($"\rProcessing: {percentage} %");

        if (index == count - 1)
            Console.WriteLine();

    }
}