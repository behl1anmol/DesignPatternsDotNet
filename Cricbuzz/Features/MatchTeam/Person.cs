using Cricbuzz.Interfaces;

namespace Cricbuzz.Features.MatchTeam;

public class Person : IPerson
{
    public string Name { get; set; }
    public int Age { get; set; }
    
    public Person(string name, int age)
    {
        Name = name;
        Age = age;
    }
}