using UnityEngine;

/// <summary>
/// Event that logs something to the console when triggered.
/// </summary>
[CreateAssetMenu(menuName = "ScriptableEvents/Events/Log Event")]
public class LogEvent : ScriptableEvent
{

    public string Log = "Test";

    public override void Parse()
    {
        Debug.Log(Log);
    }

}
