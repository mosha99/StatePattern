using Mosha.StatePatter.Test.Model.Deal.States.Interface;

namespace Mosha.StatePatter.Test.Model.Deal.States;

public class DealAdded : IDealState
{
    public bool CanConfirm(Deal deal) => true;
}