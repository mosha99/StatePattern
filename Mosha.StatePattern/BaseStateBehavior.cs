using System.ComponentModel.DataAnnotations.Schema;

namespace Mosha.StatePattern;


public class BaseStateBehavior<TBaseStateType, TKey, TRule> : KeyBehavior<TKey>
    where TKey : notnull
    where TBaseStateType : class
    where TRule : StateRule<TKey>, new()
{
    public BaseStateBehavior()
    {
        StateKey = default;
    }

    public BaseStateBehavior(TBaseStateType state)
    {
        CreateRule();

        if (_rule is not null)
            StateKey = _rule.GetKey(state.GetType());
    }

    public BaseStateBehavior(TKey key)
    {
        StateKey = key;
    }


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