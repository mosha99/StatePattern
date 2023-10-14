using System.ComponentModel.DataAnnotations.Schema;

namespace Mosha.StatePattern;

public class StateBehavior<TBaseStateType, TKey, TRule> 
    where TBaseStateType : class
    where TRule : StateRule<TKey>, new()
{
    public StateBehavior()
    {
        this.rule = Activator.CreateInstance<TRule>();
        StateKey = default;
    }

    public TKey StateKey { get; private set; }

    private TRule rule;

    [NotMapped]
    public TBaseStateType state => GetState();

    public TBaseStateType GetState()
    {
        TBaseStateType state = rule.GetState<TBaseStateType>(StateKey);
        return state;
    }

    public void SetKey(TBaseStateType state)
    {
        StateKey = rule.GetKey(state.GetType());
    }
}