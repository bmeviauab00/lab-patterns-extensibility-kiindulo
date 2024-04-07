namespace Lab_Extensibility.AnonymizerAlgorithms;

public class AgeAnonymizerAlgorithm: IAnonymizerAlgorithm
{
    private readonly int _rangeSize;

    public AgeAnonymizerAlgorithm(int rangeSize)
    {
        _rangeSize = rangeSize;
    }

    public Person Anonymize(Person person)
    {
        // This is whole number integer arithmetics, e.g for 55 / 20 we get 2
        int rangeIndex = int.Parse(person.Age) / _rangeSize;
        string newAge = $"{rangeIndex * _rangeSize}..{(rangeIndex + 1) * _rangeSize}";

        return new Person(person.FirstName, person.LastName, person.CompanyName,
            person.Address, person.City, person.State, newAge,
            person.Weight, person.Decease);
    }

    public string GetAnonymizerDescription()
    {
        return $"Age anonymizer with range size {_rangeSize}";
    }
}