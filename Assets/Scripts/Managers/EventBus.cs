using System;

public class EventBus<T> where T : struct
{
    private static Action<T> _subscribed = (_) => { };

    public static void Invoke(T info) => _subscribed.Invoke(info);
    public static void Subscribe(Action<T> action) => _subscribed += action;
    public static void Unsubscribe(Action<T> action) => _subscribed -= action;
}
