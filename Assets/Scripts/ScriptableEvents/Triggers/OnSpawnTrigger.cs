using UnityEngine;

public class OnSpawnTrigger : EventTrigger
{

    [Header("On Spawn")]
    public StartType StartType;

    private void Awake()
    {
        if (StartType == StartType.Awake)
            TriggerEvents();
    }

    private void OnEnable()
    {
        if (StartType == StartType.OnEnable)
            TriggerEvents();
    }

    private void Start()
    {
        if (StartType == StartType.Start)
            TriggerEvents();
    }

}
