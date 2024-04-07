namespace Lab_Extensibility.AnonymizerAlgorithms;

public interface IAnonymizerAlgorithm
{
    Person Anonymize(Person person);
    string GetAnonymizerDescription() => GetType().Name;
}