using Mosha.StatePatter.Test.Model.Deal.States.Interface;

namespace Mosha.StatePatter.Test.Model.Deal.States;

public abstract class DealState : IDealState
{
    public virtual bool CanConfirem(Deal deal) => false;

    public virtual bool CanRevoked(Deal deal) => false;
}