using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableEvents/Events/Dialogue Event")]
public class DialogueEvent : ScriptableEvent
{

    [Tooltip("The dialogue to initiate.")]
    public Dialogue Dialogue;

    public override void Parse()
    {
        UIDialogue.Instance?.Show(Dialogue);
    }

}
