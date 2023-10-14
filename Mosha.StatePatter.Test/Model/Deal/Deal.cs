using Mosha.StatePatter.Test.Model.Deal.Enums;
using Mosha.StatePatter.Test.Model.Deal.States.Interface;
using Mosha.StatePatter.Test.Model.Deal.States.Rule;
using Mosha.StatePattern;

namespace Mosha.StatePatter.Test.Model.Deal;

public class Deal
{
    public int Id { get; set; }
    public string DealerName { get; set; }

    private StateBehavior<IDealState, DealStateEnum, DealStateRule> State =
        new StateBehavior<IDealState, DealStateEnum, DealStateRule>();
}