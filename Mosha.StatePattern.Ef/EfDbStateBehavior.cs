using Microsoft.EntityFrameworkCore;

namespace Mosha.StatePattern.Ef;

[Owned]
public class EfDbStateBehavior<TBaseStateType, TKey, TRule> :BaseStateBehavior<TBaseStateType, TKey, TRule>
    where TKey : notnull
    where TBaseStateType : class
    where TRule : StateRule<TKey>, new()

{
    public EfDbStateBehavior() : base()
    {
    }

    public EfDbStateBehavior(TBaseStateType state): base(state)
    {

    }

    public EfDbStateBehavior(TKey key): base(key)
    {
    }
}