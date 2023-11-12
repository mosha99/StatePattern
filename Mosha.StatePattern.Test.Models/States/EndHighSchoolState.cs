using Mosha.StatePattern.Test.Models.Models;

namespace Mosha.StatePattern.Test.Models.States;

public class EndHighSchoolState : IPersonState
{
    public bool CanGoToUniversity(Person person)
    {
        return person.Age >= 18;
    }
}