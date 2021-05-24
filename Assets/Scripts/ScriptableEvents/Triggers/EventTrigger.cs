using UnityEngine;
using UnityEngine.Events;

public class EventTrigger : MonoBehaviour
{

    [Header("Events")]
    [Tooltip("All of these custom events will be triggered based on the event trigger component.")]
    public ScriptableEvent[] EventsToTrigger;
    [Tooltip("All of these Unity events will be triggered based on the event trigger component.")]
    public UnityEvent UnityEventsToTrigger;

    /// <summary>
    /// Triggers both custom and Unity events.
    /// </summary>
    protected void TriggerEvents()
    {
        TriggerCustomEvents();
        TriggerUnityEvents();
    }

    /// <summary>
    /// Triggers all assigned custom events.
    /// </summary>
    void TriggerCustomEvents()
    {
        foreach (var item in EventsToTrigger)
        {
            if (item == null)
            {
                Debug.Log("Null event in EventTrigger of object: " + gameObject.name);
                continue;
            }

            item.Parse();
        }
    }

    /// <summary>
    /// Triggers all assigned Unity events.
    /// </summary>
    void TriggerUnityEvents()
    {
        UnityEventsToTrigger.Invoke();
    }

}
