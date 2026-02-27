namespace CopperDevs.Celesium;

// https://github.com/artimora/priestess/blob/master/Assets/Scripts/Yurei/Runtime/Data/ArbitraryContents.cs
public class ArbitraryContents<T>
{
    public static ArbitraryContents<T> Default => new();

    public static ArbitraryContents<T> With(string id, T value)
    {
        var contents = new ArbitraryContents<T>
        {
            [id] = value
        };
        return contents;
    }

    private readonly Dictionary<string, T> contents = new();

    public T this[string id]
    {
        get => contents[id];
        set => contents[id] = value;
    }
}