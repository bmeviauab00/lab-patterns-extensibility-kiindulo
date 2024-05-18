using System;

namespace Lab_Extensibility.Progresses;

public class PercentProgress: IProgress
{
    public void Report(int count, int index)
    {
        int percentage = (int)((double)(index+1) / count * 100);

        Console.Write($"\rProcessing: {percentage} %");

        if (index == count - 1)
            Console.WriteLine();
    }
}