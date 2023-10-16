using Microsoft.EntityFrameworkCore;
using Mosha.StatePatter.Test.Model.Deal.Enums;
using Mosha.StatePatter.Test.Model.Deal.States;
using Mosha.StatePatter.Test.Model.Deal.States.Interface;
using Mosha.StatePatter.Test.Model.Deal.States.Rule;
using Mosha.StatePattern;

namespace Mosha.StatePatter.Test.Model.Deal;

public class Deal
{
    public int Id { get; set; }
    public string DealerName { get; set; }
    public string StateString => State.StateKey.ToString();

    public StateBehavior<IDealState, DealStateEnum, DealStateRule> State = new(DealStateEnum.Added);

    public void Confirm()
    {
        if (State.state.CanConfirm(this) != true)
        {
            Console.WriteLine($"Deal With Id {Id} Can Not Confirmed");
            return;
        }

        //Do Some Things
        Console.WriteLine($"Deal With Id {Id} Confirmed");
        State = new(DealStateEnum.Confirmed);
    }

    public void Revoke()
    {
        if (State.state.CanRevoked(this))
        {
            Console.WriteLine($"Deal With Id {Id} Can Not Revoked");
            return;
        }

        //Do Some Things
        Console.WriteLine($"Deal With Id {Id} Revoked");
        State = new(new DealRevoked());

    }

}