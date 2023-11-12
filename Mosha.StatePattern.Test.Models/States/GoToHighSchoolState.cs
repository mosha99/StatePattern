using Mosha.StatePattern.Test.Models.Models;

namespace Mosha.StatePattern.Test.Models.States;

public class GoToHighSchoolState : IPersonState
{
    public bool CanEndHighSchool(Person person)
    {
        return person.Age >= 17;
    }

}