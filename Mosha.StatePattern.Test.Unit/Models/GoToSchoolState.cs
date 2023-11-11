namespace Mosha.StatePattern.Test.Unit.Models;

public class GoToSchoolState : IPersonState
{
    public bool CanEndSchool(Person person)
    {
        return person.Age >= 13;
    }
}