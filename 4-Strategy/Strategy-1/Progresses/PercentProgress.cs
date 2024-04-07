using System;

namespace Lab_Extensibility.Progresses;

public class PercentProgress: IProgress
{
    public void Report(int count, int index)
    {
        int percentage = (int)((double)(index+1) / count * 100);

        var pos = Console.GetCursorPosition();
        Console.SetCursorPosition(0, pos.Top);

        Console.Write($"Processing: {percentage} %");

        if (index == count - 1)
            Console.WriteLine();
    }
}