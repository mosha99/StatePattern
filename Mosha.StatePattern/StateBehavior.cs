using System.ComponentModel.DataAnnotations.Schema;

namespace Mosha.StatePattern;

public class StateBehavior<TBaseStateType, TKey, TRule>
    where TKey : notnull
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

        if (_rule is not null)
            StateKey = _rule.GetKey(state.GetType());
    }

    public StateBehavior(TKey key)
    {
        StateKey = key;
    }

    public TKey? StateKey { get; private set; }

    private TRule? _rule = null;

    [NotMapped]
    public TBaseStateType State => GetState();

    public TBaseStateType GetState()
    {
        CreateRule();

        var state = _rule?.GetState<TBaseStateType>(StateKey);

        if (state != null) return state;

        throw new Exception("Can not Create State");
    }

    private void CreateRule()
    {
        if (_rule is null)
            this._rule = Activator.CreateInstance<TRule>();

        if (_rule is null)
            throw new Exception("Can not Create Rule For State");
    }
}