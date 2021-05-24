using UnityEngine;

/// <summary>
/// Note: The object with the component or the other collider's object must have a rigidbody for
/// OnTriggerEnter events to actually trigger.
/// </summary>
public class OnTriggerEnterTrigger : ScriptableEventTrigger
{

    [Header("Properties")]
    [Tooltip("The tag associated with the other collider. If empty, any collider can trigger the events.")]
    [SerializeField] private string _otherTag = "";
    [Tooltip("Checks whether or not trigger or non-trigger colliders will trigger the events.")]
    [SerializeField] private bool _otherIsTrigger = false;

    private void OnTriggerEnter(Collider other)
    {
        if (CheckTag(other) && CheckIsTrigger(other))
        {
            TriggerEvents();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (CheckTag(other) && CheckIsTrigger(other))
        {
            TriggerEvents();
        }
    }

    #region Check Tag

    /// <summary>
    /// If no _otherTag assigned, anything can trigger this.
    /// Otherwise it checks the other collider's tag matches the _otherTag.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    bool CheckTag(Collider other)
    {
        if (string.IsNullOrEmpty(_otherTag))
            return true;

        return other.CompareTag(_otherTag);
    }

    /// <summary>
    /// If no _otherTag assigned, anything can trigger this.
    /// Otherwise it checks the other collider's tag matches the _otherTag.
    /// </summary>
    /// <param name="other"></param>
    /// <returns></returns>
    bool CheckTag(Collider2D other)
    {
        if (string.IsNullOrEmpty(_otherTag))
            return true;

        return other.CompareTag(_otherTag);
    }

    #endregion

    #region Check IsTrigger

    /// <summary>
    /// Checks if the the other collider's isTrigger property matches this script's _otherIsTrigger bool.
    /// </summary>
    /// <param name="other"></param>The other (entering) collider.
    /// <returns></returns>
    bool CheckIsTrigger(Collider other)
    {
        return other.isTrigger == _otherIsTrigger;
    }

    /// <summary>
    /// Checks if the the other collider's isTrigger property matches this script's _otherIsTrigger bool.
    /// </summary>
    /// <param name="other"></param>The other (entering) collider.
    /// <returns></returns>
    bool CheckIsTrigger(Collider2D other)
    {
        return other.isTrigger == _otherIsTrigger;
    }

    #endregion

}
