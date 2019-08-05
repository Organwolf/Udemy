using System;

public class ObjectList
{
    public void Add(object value)
    {

    }
    public object this[int index]
    {
        get { throw new NotImplementedException(); }
    }
}

public class GenericDictionary<TKey, TValue>
{
    public void Add(TKey key, TValue value)
    {

    }

}

public class Nullable<T> where T : struct
{
    private object _value;

    public Nullable()
    {
    }

    public Nullable(T value)
    {
        _value = value;
    }

    public bool HasValue
    {
        get { return _value != null; }
    }

    public T GetValueOrDefault()
    {
        if(HasValue)
            return (T)_value;
        
        return default(T);
    }
}

public class GenericList<T>
{
    public void Add(T value)
    {

    }

    public T this[int index]
    {
        get { throw new NotImplementedException(); }
    }
}