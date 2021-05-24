using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue")]
public class Dialogue : ScriptableObject
{

    public DialogueNode[] Nodes;

    const string LINE_BREAK = "\n";

    public string BuildString(int index = 0)
    {
        // exit early if invalid index
        if (index < 0 || index >= Nodes.Length) return "";

        string text = "";

        // add main text
        text += Nodes[index].MainText + LINE_BREAK + LINE_BREAK;

        // then add choices
        if (Nodes[index].Choices.Length > 0)
        {
            for (int i = 0; i < Nodes[index].Choices.Length; i++)
            {
                text += $"{i + 1}. {Nodes[index].Choices[i].ChoiceText}{LINE_BREAK}";
            }
        }

        return text;
    }

    public void InvokeEvent(int index = 0)
    {
        // exit early if invalid index
        if (index < 0 || index >= Nodes.Length) return;

        if (Nodes[index].EventTrigger)
            Nodes[index].EventTrigger.Parse();
    }

    /// <summary>
    /// Checks if both node and choice exist. Returns false if either one doesn't.
    /// </summary>
    /// <param name="nodeIndex"></param>
    /// <param name="choiceIndex"></param>
    /// <returns></returns>
    public bool DoesChoiceExist(int nodeIndex, int choiceIndex)
    {
        if (DoesNodeExist(nodeIndex))
        {
            return Nodes[nodeIndex].Choices.Length > choiceIndex;
        }

        // if we get here, the node doesn't even exist, therefore a choice couldn't exist
        return false;
    }

    bool DoesNodeExist(int nodeIndex)
    {
        return Nodes.Length > nodeIndex;
    }

}
