namespace Mosha.StatePatter.Test.Model.Deal.States.Interface;

public interface IDealState
{
    public bool CanConfirem(Deal deal) => false;
    public bool CanRevoked(Deal deal) => false;
}