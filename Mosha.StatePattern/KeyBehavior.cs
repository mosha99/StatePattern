namespace Mosha.StatePattern;

public class KeyBehavior<TKey> where TKey : notnull
{
    public TKey? StateKey { get; internal set; }
}