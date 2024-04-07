namespace Lab_Extensibility.AnonymizerAlgorithms;

public class NameMaskingAnonymizerAlgorithm: IAnonymizerAlgorithm
{
    private readonly string _mask;

    public NameMaskingAnonymizerAlgorithm(string mask)
    {
        _mask = mask;
    }

    public Person Anonymize(Person person)
    {
        return new Person(_mask, _mask, person.CompanyName,
            person.Address, person.City, person.State, person.Age, person.Weight, person.Decease);
    }

    public string GetAnonymizerDescription()
    {
        return $"NameMasking anonymizer with mask {_mask}";
    }
}