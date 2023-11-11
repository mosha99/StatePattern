namespace Mosha.StatePattern.Test.Unit.Models;

public class GoToHighSchoolState : IPersonState
{
    public bool CanEndHighSchool(Person person)
    {
        return person.Age >= 17;
    }

}