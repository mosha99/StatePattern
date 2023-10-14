namespace Mosha.StatePatter.Test.Model.Deal.States;

public class DealConfirmed : DealState
{
    public override bool CanRevoked(Deal deal) => true;
}