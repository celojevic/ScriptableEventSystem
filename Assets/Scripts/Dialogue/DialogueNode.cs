using UnityEngine;

[System.Serializable]
public struct DialogueNode
{
    [Tooltip("The event triggered when this node becomes active.")]
    public ScriptableEvent EventTrigger;

    [Tooltip("The main text to appear at the top of the dialogue box.")]
    public string MainText;

    [Tooltip("The array of choices available to choose from")]
    public DialogueChoice[] Choices;
}