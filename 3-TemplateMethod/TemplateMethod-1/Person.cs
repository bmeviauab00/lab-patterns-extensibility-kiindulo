namespace Lab_Extensibility;

public class Person
{
    public string FirstName { get; }
    public string LastName { get; }
    public string CompanyName { get; }
    public string Address { get; }
    public string City { get; }
    public string State { get; }
    public string Age { get; }
    public string Weight { get; }
    public string Decease { get; }

    public Person(string firstName, string lastName, string companyName, string address, string city, string state,
        string age, string weight, string decease)
    {
        FirstName = firstName;
        LastName = lastName;
        CompanyName = companyName;
        Address = address;
        City = city;
        State = state;
        Age = age;
        Weight = weight;
        Decease = decease;
    }
}