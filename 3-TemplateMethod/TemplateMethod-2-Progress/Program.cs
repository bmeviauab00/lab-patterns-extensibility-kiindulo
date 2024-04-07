using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab_Extensibility;

static class Program
{
    static void Main(string[] args)
    {
        NameMaskingAnonymizer anonymizer = new("us-500.csv", "***");
        // AgeAnonymizer anonymizer = new("us-500.csv", 20);
        anonymizer.Run();
    }
}