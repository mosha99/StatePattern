using Mosha.StatePattern.Test.Models.Models;

namespace Mosha.StatePattern.Test.Models.States;

public class NotYetGoToSchoolState : IPersonState
{
    public bool CanGoToSchool(Person person)
    {
        return person.Age >= 7;
    }
}