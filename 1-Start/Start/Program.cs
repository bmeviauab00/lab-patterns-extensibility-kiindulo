using System;
using System.Collections.Generic;
using System.IO;

namespace Lab_Extensibility;

static class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("App started");

        // We will add Person objects to this list
        List<Person> persons = new();

        // Some variables for statistics
        int personCount = 0;
        int trimmedPersonCount = 0;

        string inputFileName = "us-500.csv";

        // Open open input file and process (source: https://www.briandunning.com/sample-data)
        using (StreamReader reader = new(inputFileName))
        {
            Console.WriteLine($"File has been opened ({inputFileName})");

            // Process the file
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                ++personCount;

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
                Console.WriteLine($"{personCount}. persons processed");
            }
        }

        // Cleanup data: trim whitespaces and other unneeded characters (_ and #) from beginning and end of city names
        // As Person objects are immutable, let's create new Person objects with trimmed city names and add to new list.
        List<Person> trimmedPersons = new();
        foreach (var person in persons)
        {
            var trimmedCity = person.City.Trim().Trim('_', '#');
            if (trimmedCity != person.City)
                ++trimmedPersonCount;
            trimmedPersons.Add(new Person(person.FirstName, person.LastName, person.CompanyName,
                person.Address, trimmedCity, person.State, person.Age, person.Weight, person.Decease));
        }
        persons = trimmedPersons; // persons now points to the list of trimmed persons

        // Anonymize (remove identifying information)
        List<Person> anonymizedPersons = new();
        const string anonymizedFieldContent = "***";
        foreach (var person in persons)
        {
            anonymizedPersons.Add(new Person(anonymizedFieldContent, anonymizedFieldContent, person.CompanyName,
                person.Address, person.City, person.State, person.Age, person.Weight, person.Decease));
        }
        persons = anonymizedPersons; // persons now points to the list of anonymized persons

        // Generate output: a txt file, write only first name, last name, state, age, weight and decease
        string outFileName = Path.ChangeExtension(inputFileName, "processed.txt");
        using (StreamWriter writer = new StreamWriter(outFileName))
        {
            foreach (Person p in persons)
                writer.WriteLine($"{p.FirstName}; {p.LastName}; {p.State}; {p.City}; {p.Age}; {p.Weight}; {p.Decease}");
        }
        Console.WriteLine($"Output file generated ({outFileName})");

        // Print summary/statistics
        Console.WriteLine($"Summary - Persons: {personCount}, trimmed: {trimmedPersonCount}");
    }


}