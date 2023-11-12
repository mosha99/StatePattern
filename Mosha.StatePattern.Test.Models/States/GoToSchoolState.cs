using Mosha.StatePattern.Test.Models.Models;

namespace Mosha.StatePattern.Test.Models.States;

public class GoToSchoolState : IPersonState
{
    public bool CanEndSchool(Person person)
    {
        return person.Age >= 13;
    }
}