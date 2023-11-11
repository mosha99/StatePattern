namespace Mosha.StatePattern;

public abstract class StateRule<TKey> where TKey : notnull
{
    protected StateRule()
    {
        _keyVal = new Dictionary<TKey, Type>();
        _valKey = new Dictionary<Type, TKey>();
    }

    protected void AddRule<T>(TKey stateKey)
    {
        _keyVal.Add(stateKey, typeof(T));
        _valKey.Add(typeof(T), stateKey);
    }

    private readonly Dictionary<TKey, Type> _keyVal;
    private readonly Dictionary<Type, TKey> _valKey;

    public TResult? GetState<TResult>(TKey? state) where TResult : class
    {
        if (state == null) return null;
        return Activator.CreateInstance(_keyVal[state]) as TResult ?? throw new Exception("State Not Found Or Key Is Invalid");
    }

    public TKey GetKey(Type stateType)
    { 
        return (TKey)_valKey[stateType];
    }
}