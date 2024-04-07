namespace Lab_Extensibility.Progresses;

public interface IProgress
{
    void Report(int count, int index);
}