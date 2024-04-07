using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab_Extensibility;

public class NameMaskingAnonymizer: AnonymizerBase
{
    private readonly string _mask;

    public NameMaskingAnonymizer(string inputFileName, string mask): base(inputFileName)
    {
        _mask = mask;
    }

    protected override Person Anonymize(Person person)
    {
        return new Person(_mask, _mask, person.CompanyName,
            person.Address, person.City, person.State, person.Age, person.Weight, person.Decease);
    }

    protected override string GetAnonymizerDescription()
    {
        return $"NameMasking anonymizer with mask {_mask}";
    }
}