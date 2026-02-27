namespace CopperDevs.Celesium.Observable;

internal interface IObserverAction
{
    public void Invoke(object? data);
}