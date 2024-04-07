using System;
using System.Collections.Generic;
using System.IO;

namespace Lab_Extensibility;

public abstract class AnonymizerBase
{
    // Some variables for statistics
    private int _personCount;
    private int _trimmedPersonCount;

    private readonly string _inputFileName;

    protected AnonymizerBase(string inputFileName)
    {
        _inputFileName = inputFileName;
    }
    public void Run()
    {
        Console.WriteLine("App started");
        List<Person> persons = ReadFromInput();
        persons = TrimCityNames(persons);

        List<Person> anonymizedPersons = new();
        for (var i = 0; i < persons.Count; i++)
        {
            var person = Anonymize(persons[i]);
            anonymizedPersons.Add(person);

            Console.WriteLine($"{i + 1}. person processed.");
        }

        WriteToOutput(anonymizedPersons);
        PrintSummary();
    }

    protected abstract Person Anonymize(Person person);

    protected virtual string GetAnonymizerDescription()
    {
        return GetType().Name;
    }

    private List<Person> ReadFromInput()
    {
        // We will add Person objects to this list
        List<Person> persons = new();

        // Open open input file and process (source: https://www.briandunning.com/sample-data)
        using (StreamReader reader = new(_inputFileName))
        {
            Console.WriteLine($"File has been opened ({_inputFileName})");

            // Process the file
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                ++_personCount;

                // Line look like the following sample:
                // "James","Rhymes","Benton, John B Jr","6649 N Blue Gum St","New Orleans","Orleans","LA",70116,"504-621-8927","504-845-1427","jrhymes@gmail.com","http://www.bentonjohnbjr.com"
                // Split rows into columns - no need to understand regex here
                System.Text.RegularExpressions.MatchCollection columns =
                    new System.Text.RegularExpressions.Regex("((?<=\")[^\"]*(?=\"(,|$)+)|(?<=,|^)[^,\"]*(?=,|$))").Matches(line);

                // Create a person from the line and add it
                persons.Add(new Person(firstName: columns[0].Value, lastName: columns[1].Value,
                    companyName: columns[2].Value, address: columns[3].Value, city: columns[4].Value, state: columns[6].Value,
                    age: columns[10].Value, weight: columns[11].Value, decease: columns[12].Value));

                // Log the line
                // Console.WriteLine($"{_personCount}. persons processed");
            }
        }

        return persons;
    }

    private List<Person> TrimCityNames(List<Person> persons)
    {
        // Cleanup data 1: trim whitespaces and other unneeded characters (_ and #) from beginning and end of city names
        // As Person objects are immutable, let's create new Person objects with trimmed city names and add to new list.
        List<Person> trimmedPersons = new();
        foreach (var person in persons)
        {
            var trimmedCity = person.City.Trim().Trim('_', '#');
            if (trimmedCity != person.City)
                ++_trimmedPersonCount;
            trimmedPersons.Add(new Person(person.FirstName, person.LastName, person.CompanyName,
                person.Address, trimmedCity, person.State, person.Age, person.Weight, person.Decease));
        }
        return trimmedPersons; // persons now points to the list of trimmed persons
    }


    private void WriteToOutput(List<Person> persons)
    {
        string outFileName = Path.ChangeExtension(_inputFileName, "processed.txt");
        // Generate output: a txt file, write only first name, last name and state
        using (StreamWriter writer = new StreamWriter(outFileName))
        {
            foreach (Person p in persons)
                writer.WriteLine($"{p.FirstName}; {p.LastName}; {p.State}; {p.City}; {p.Age}; {p.Weight}; {p.Decease}");
        }

        Console.WriteLine($"Output file generated ({outFileName})");
    }

    private void PrintSummary()
    {
        // Print summary/statistics
        Console.WriteLine($"Summary - Anonymizer ({GetAnonymizerDescription()}): Persons: {_personCount}, trimmed: {_trimmedPersonCount}");
    }
}