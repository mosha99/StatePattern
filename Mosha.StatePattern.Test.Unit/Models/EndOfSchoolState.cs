namespace Mosha.StatePattern.Test.Unit.Models;

public class EndOfSchoolState : IPersonState
{
    public bool CanGoToHighSchool(Person person)
    {
        return person.Age >= 14;
    }
}