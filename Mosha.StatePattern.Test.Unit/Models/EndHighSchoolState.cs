namespace Mosha.StatePattern.Test.Unit.Models;

public class EndHighSchoolState : IPersonState
{
    public bool CanGoToUniversity(Person person)
    {
        return person.Age >= 18;
    }
}