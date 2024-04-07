using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Lab_Extensibility;

static class Program
{
    static void Main(string[] args)
    {
        Anonymizer anonymizer = new("us-500.csv", "***");
        anonymizer.Run();
    }
}