using UnityEngine;

/// <summary>
/// Spawns the assigned prefab when triggered.
/// </summary>
[CreateAssetMenu(menuName = "ScriptableEvents/Spawn Event")]
public class SpawnEvent : ScriptableEvent
{

    [Tooltip("Prefab to instantiate when triggered.")]
    public GameObject Prefab;

    [Tooltip("Position to spawn the prefab. Leave it at negative infinity if you don't want to designate a spawn position.")]
    public Vector3 Position = Vector3.negativeInfinity;

    [Tooltip("Rotation of the spawned prefab. Default is Quaternion.identity.")]
    public Quaternion Rotation = Quaternion.identity;

    [Tooltip("Transform to parent the spawned prefab to. If null, it will spawn in the scene with no parent.")]
    public Transform Parent;

    public override void Parse()
    {
        if (CheckStackOverflow()) return;

        if (Position != Vector3.negativeInfinity)
        {
            if (Parent != null)
            {
                Instantiate(Prefab, Position, Rotation, Parent);
            }
            else
            {
                Instantiate(Prefab, Position, Rotation);
            }
        }
        else
        {
            Instantiate(Prefab);
        }
    }

    /// <summary>
    /// Checks the prefab for spawn trigger with the same spawn event as this.
    /// If it exists, it will cause a stack overflow (which Unity catches),
    /// but we will just not spawn anything and log it.
    /// </summary>
    /// <returns></returns>Returns true if a stack overflow is detected.
    bool CheckStackOverflow()
    {
        var spawn = Prefab.GetComponent<OnSpawnTrigger>();
        if (spawn)
        {
            foreach (var item in spawn.EventsToTrigger)
            {
                if (item == this)
                {
                    Debug.LogError($"Spawn Event '{name}' would cause a stack overflow. " +
                        $"Check the prefab assigned for similar spawn events and consider removing them.");
                    return true;
                }
            }
        }

        return false;
    }

}
