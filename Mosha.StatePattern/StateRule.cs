namespace Mosha.StatePattern;

public abstract class StateRule<TKey>
{
    protected StateRule()
    {
        _Key_val = new Dictionary<TKey, Type>();
        _Val_Key = new Dictionary<Type, TKey>();
    }

    protected void AddRule<T>(TKey stateKey)
    {
        _Key_val.Add(stateKey, typeof(T));
        _Val_Key.Add(typeof(T), stateKey);
    }

    private Dictionary<TKey, Type> _Key_val;
    private Dictionary<Type, TKey> _Val_Key;

    public TResult? GetState<TResult>(TKey? state) where TResult : class
    {
        if (state == null) return null;
        return Activator.CreateInstance(_Key_val[state]) as TResult ?? throw new Exception("State Not Found Or Key Is Invalid");
    }

    public TKey GetKey(Type stateType)
    { 
        return (TKey)_Val_Key[stateType];
    }
}