using UnityEngine;

[RequireComponent(typeof(Health))]
public class OnDeathTrigger : ScriptableEventTrigger
{

    private Health _health;

    private void Awake()
    {
        _health = GetComponent<Health>();
        if (_health == null) Destroy(this);

        _health.OnDeath += Health_OnDeath;
    }

    private void OnDestroy()
    {
        _health.OnDeath -= Health_OnDeath;
    }

    private void Health_OnDeath()
    {
        TriggerEvents();
    }

}
