using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Lab_Extensibility;

public class AgeAnonymizerWithSimpleProgress: AgeAnonymizer
{
    public AgeAnonymizerWithSimpleProgress(string inputFileName, int rangeSize): base(inputFileName, rangeSize)
    {
    }
    protected override void PrintProgress(int count, int index)
    {
        Console.WriteLine($"{index + 1}. person processed");
    }
}