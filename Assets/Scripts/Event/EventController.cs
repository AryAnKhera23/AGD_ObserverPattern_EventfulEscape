using System;


public class EventController
{
    public event Action baseEvent;
    
    public void SubscribeToEvents(Action listener) => baseEvent += listener;

    public void UnsubscribeToEvents(Action listener) => baseEvent -= listener;
    
    public void InvokeEvent() => baseEvent?.Invoke();
}
