using UnityEngine;
using UnityEngine.Events;

public class TimedTrigger : EventTrigger
{

    // if both are greater than 0, whichever is earlier will trigger first.
    [Header("Timing")]
    [Tooltip("Amount of time needed to pass until the event is triggered.")]
    public float DelayToTrigger;
    [Tooltip("The Time.time to trigger the events, i.e. the time in seconds since the start of game.")]
    public float TimeToTrigger;

    // if the event is not repeated, the script will be destroyed.
    [Header("Repeating Triggers")]
    [Tooltip("Set true if you want this event to repeat every DelayToTrigger time AFTER the first trigger.")]
    public bool RepeatEvent;
    [Tooltip("(Only valid if RepeatEvent is true.) Amount of times to repeat the event, excluding the first time.")]
    public int TimesToRepeat = int.MaxValue;

    /// <summary>
    /// Time from when to start counting.
    /// </summary>
    private float _startTime;

    /// <summary>
    /// Amount of the times the event trigger has been repeated;
    /// </summary>
    private int _repeatCount = 0;

    private void Start()
    {
        _startTime = Time.time;
    }

    private void Update()
    {
        CheckDelayToTrigger();
        CheckTimeToTrigger();
    }

    void CheckTimeToTrigger()
    {
        // exit early if no valid time to trigger assigned
        if (TimeToTrigger <= 0f) return;

        if (Time.time > TimeToTrigger)
        {
            TriggerEvents();
            CheckRepeat();
        }
    }

    void CheckDelayToTrigger()
    {
        // exit early if no valid time assigned
        if (DelayToTrigger <= 0f) return;

        if (Time.time > _startTime + DelayToTrigger)
        {
            TriggerEvents();
            CheckRepeat();
        }
    }

    void CheckRepeat()
    {
        if (!RepeatEvent                        // don't repeat event
            || TimesToRepeat <= 0               // times to repeat invalid
            || _repeatCount >= TimesToRepeat)   // reached the times to repeat count
        {
            Destroy(this);
            return;
        }

        _repeatCount++;
        Reset();
    }

    private void Reset()
    {
        _startTime = Time.time;
    }

}
