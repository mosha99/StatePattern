using Mosha.StatePattern.Test.Models.Models;

namespace Mosha.StatePattern.Test.Models.States;

public class EndOfSchoolState : IPersonState
{
    public bool CanGoToHighSchool(Person person)
    {
        return person.Age >= 14;
    }
}