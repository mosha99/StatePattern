namespace Mosha.StatePattern.Test.Unit.Models;

public interface IPersonState
{
    public bool CanGoToSchool(Person person) => false;
    public bool CanEndSchool(Person person) => false;
    public bool CanGoToHighSchool(Person person) => false;
    public bool CanEndHighSchool(Person person) => false;
    public bool CanGoToUniversity(Person person) => false;
}