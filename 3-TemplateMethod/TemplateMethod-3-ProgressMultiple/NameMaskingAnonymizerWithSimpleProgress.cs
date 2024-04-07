using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_Extensibility;

public class NameMaskingAnonymizerWithSimpleProgress: NameMaskingAnonymizer
{
    public NameMaskingAnonymizerWithSimpleProgress(string inputFileName, string mask): base(inputFileName, mask)
    {
    }

    protected override void PrintProgress(int count, int index)
    {
        Console.WriteLine($"{index + 1}. person processed");
    }
}