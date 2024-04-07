using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Lab_Extensibility.AnonymizerAlgorithms;
using Lab_Extensibility.Progresses;

namespace Lab_Extensibility;

static class Program
{
    static void Main(string[] args)
    {
        // We can use the same Anonymizer with any combination of strategies

        Anonymizer p1 = new("us-500.csv",
            new NameMaskingAnonymizerAlgorithm("***"),
            new SimpleProgress());
        p1.Run();

        Console.WriteLine("--------------------");

        Anonymizer p2 = new("us-500.csv",
            new NameMaskingAnonymizerAlgorithm("***"),
            new PercentProgress());
        p2.Run();

        Console.WriteLine("--------------------");

        Anonymizer p3 = new("us-500.csv",
            new AgeAnonymizerAlgorithm(20),
            new SimpleProgress());
        p3.Run();
    }
}