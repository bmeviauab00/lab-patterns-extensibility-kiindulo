using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Lab_Extensibility;

public class AgeAnonymizerWithPercentProgress: AgeAnonymizer
{
    public AgeAnonymizerWithPercentProgress(string inputFileName, int rangeSize): base(inputFileName, rangeSize)
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