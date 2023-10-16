using Mosha.StatePatter.Test.Model.Deal.Enums;
using Mosha.StatePattern;

namespace Mosha.StatePatter.Test.Model.Deal.States.Rule;

public class DealStateRule : StateRule<DealStateEnum>
{
    public DealStateRule()
    {
        AddRule<DealAdded>(DealStateEnum.Added);
        AddRule<DealConfirmed>(DealStateEnum.Confirmed);
        AddRule<DealRevoked>(DealStateEnum.Revoked);
    }
}