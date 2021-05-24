using UnityEngine;

public class PlayerDialogue : MonoBehaviour
{

    [SerializeField] private KeyCode _exitKey = KeyCode.Escape;

    private Dialogue _curDialogue;
    private int _curDialogueNodeIndex = -1;

    private void Start()
    {
        UIDialogue.Instance.OnDialogueStarted += UIDialogue_OnDialogueStarted;
        UIDialogue.Instance.OnDialogueEnded += UIDialogue_OnDialogueEnded;
    }

    private void OnDestroy()
    {
        UIDialogue.Instance.OnDialogueStarted -= UIDialogue_OnDialogueStarted;
        UIDialogue.Instance.OnDialogueEnded -= UIDialogue_OnDialogueEnded;
    }

    private void UIDialogue_OnDialogueEnded()
    {
        _curDialogue = null;
        _curDialogueNodeIndex = -1;
    }

    private void UIDialogue_OnDialogueStarted(Dialogue dialogue, int nodeIndex)
    {
        _curDialogue = dialogue;
        _curDialogueNodeIndex = nodeIndex;
    }

    private void Update()
    {
        if (_curDialogue)
            CheckKeyPresses();
    }

    void CheckKeyPresses()
    {
        if (Input.GetKeyDown(_exitKey))
        {
            UIDialogue.Instance?.Hide();
        }
        // TODO is there a more elegant way to do this?
        else if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UIDialogue.Instance?.Show(_curDialogue, GetGoToIndex(0));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UIDialogue.Instance?.Show(_curDialogue, GetGoToIndex(1));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UIDialogue.Instance?.Show(_curDialogue, GetGoToIndex(2));
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            UIDialogue.Instance?.Show(_curDialogue, GetGoToIndex(3));
        }
    }

    int GetGoToIndex(int choiceIndex)
    {
        // checks both if node and choice exists
        if (_curDialogue.DoesChoiceExist(_curDialogueNodeIndex, choiceIndex))
        {
            return _curDialogue.Nodes[_curDialogueNodeIndex].Choices[choiceIndex].GoToIndex;
        }

        return -1;
    }

}
