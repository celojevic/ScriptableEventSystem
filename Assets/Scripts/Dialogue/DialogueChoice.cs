using UnityEngine;

[System.Serializable]
public struct DialogueChoice
{
    [Tooltip("The text shown for this choice.")]
    public string ChoiceText;

    [Tooltip("The index of the NODE to show next.")]
    public int GoToIndex;
}