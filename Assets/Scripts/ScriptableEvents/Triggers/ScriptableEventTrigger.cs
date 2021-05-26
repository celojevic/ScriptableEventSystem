using UnityEngine;
using UnityEngine.Events;

public class ScriptableEventTrigger : MonoBehaviour
{

    [Header("Events")]
    [Tooltip("All of these custom events will be triggered based on the event trigger component.")]
    public ScriptableEvent[] EventsToTrigger;
    [Tooltip("All of these Unity events will be triggered based on the event trigger component.")]
    public UnityEvent UnityEventsToTrigger;

    [Header("Conditions")]
    [Tooltip("Conditions needed to be met in order to trigger events.")]
    public Condition[] Conditions;

    /// <summary>
    /// Triggers both custom and Unity events.
    /// </summary>
    protected void TriggerEvents()
    {
        if (!MeetsConditions()) return;

        TriggerCustomEvents();
        TriggerUnityEvents();
    }

    bool MeetsConditions()
    {
        // no conditions
        if (Conditions == null || Conditions.Length == 0)
            return true;

        // check all the conditions for a non-matching one
        foreach (var item in Conditions)
        {
            if (item is Condition<int> intCnd)
            {
                if (!intCnd.Compare())
                    return false;
            }
            else if (item is Condition<bool> boolCnd)
            {
                if (!boolCnd.Compare())
                    return false;
            }
            else if (item is Condition<string> stringCnd)
            {
                if (!stringCnd.Compare())
                    return false;
            }
        }

        // if we get here, all the conditions were met
        return true;
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

    /// <summary>
    /// Returns true if this trigger's events contains the indicated type of ScriptableEvent.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="scriptableEvent"></param>
    /// <returns></returns>
    public bool Contains<T>() where T : ScriptableEvent
    {
        foreach (var item in EventsToTrigger)
            if (item is T)
                return true;

        // if we get here, there are no ScriptableEvents assigned
        // to this trigger of the indicated type
        return false;
    }

}
