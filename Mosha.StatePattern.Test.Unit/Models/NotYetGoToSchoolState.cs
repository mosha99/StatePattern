namespace Mosha.StatePattern.Test.Unit.Models;

public class NotYetGoToSchoolState : IPersonState
{
    public bool CanGoToSchool(Person person)
    {
        return person.Age >= 7;
    }
}