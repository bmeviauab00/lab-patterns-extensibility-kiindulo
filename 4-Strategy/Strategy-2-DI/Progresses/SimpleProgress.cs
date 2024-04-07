using System;

namespace Lab_Extensibility.Progresses;

public class SimpleProgress: IProgress
{
    public void Report(int count, int index)
    {
        Console.WriteLine($"{index + 1}. person processed");
    }
}