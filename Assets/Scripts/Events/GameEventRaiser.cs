using UnityEngine;
using UnityEngine.Events;

public class GameEventRaiser : MonoBehaviour
{
    public UnityEvent OnCollectEvent;

    public void RaiseEvent()
    {
        OnCollectEvent.Invoke();
    }
}
