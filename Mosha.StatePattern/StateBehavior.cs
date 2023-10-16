using System.ComponentModel.DataAnnotations.Schema;

namespace Mosha.StatePattern;

public class StateBehavior<TBaseStateType, TKey, TRule>
    where TBaseStateType : class
    where TRule : StateRule<TKey>, new()
{
    public StateBehavior()
    {
        StateKey = default;
    }
    public StateBehavior(TBaseStateType state)
    {
        CreateRule();
        StateKey = rule.GetKey(state.GetType());
    }
    public TKey? StateKey { get; private set; }

    private TRule? rule = null;

    [NotMapped]
    public TBaseStateType state => GetState();

    public TBaseStateType GetState()
    {
        CreateRule();

        TBaseStateType state = rule.GetState<TBaseStateType>(StateKey);

        return state;
    }

    private void CreateRule()
    {
        if (rule is null)
            this.rule = Activator.CreateInstance<TRule>();

        if (rule is null)
            throw new Exception("Can not Create Rule For State");
    }
}