namespace CopperDevs.Celesium;

// https://github.com/artimora/priestess/blob/master/Assets/Scripts/Yurei/Runtime/Data/Stack.cs
public class SimpleStack<T>
{
    private readonly Dictionary<Guid, T> backing = new();

    public Guid Push(T item)
    {
        var id = Guid.NewGuid();
        backing[id] = item;
        return id;
    }

    public T Get(Guid id) => backing[id];

    public T Pop(Guid id)
    {
        var value = backing[id];
        backing.Remove(id);
        return value;
    }
        
    public IEnumerable<T> Items() => backing.Values;
}