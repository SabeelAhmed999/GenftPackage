using System;
namespace Genft
{
public class Evt
{
    private event Action action =delegate{};
    public void Invoke()=>action.Invoke();
    public void Addlistener(Action listener)=>action+=listener;
    public void RemoveListener(Action listener)=>action-=listener;
}

public class Evt<T>
{
    private event Action<T> action=delegate{};
    public void Invoke(T param)=>action.Invoke(param);
    public void Addlistener(Action<T> listener)=>action+=listener;
    public void RemoveListener(Action<T> listener)=>action-=listener;
}
}
