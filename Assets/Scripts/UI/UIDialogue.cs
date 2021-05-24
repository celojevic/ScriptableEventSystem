using UnityEngine;
using TMPro;
using System;

public class UIDialogue : MonoBehaviour
{

    #region Singleton

    public static UIDialogue Instance;


    private void Awake()
    {
        Instance = this;
    }

    #endregion

    [SerializeField] private TMP_Text _text = null;

    public event Action<Dialogue, int> OnDialogueStarted;
    public event Action OnDialogueEnded;

    private void Start()
    {
        Hide();
    }

    public void Show(Dialogue dialogue, int index = 0)
    {
        if (index < 0)
        {
            Hide();
            return;
        }

        OnDialogueStarted?.Invoke(dialogue, index);
        _text.gameObject.SetActive(true);
        _text.text = dialogue.BuildString(index);
        if (string.IsNullOrEmpty(_text.text))
        {
            Hide();
            return;
        }
        dialogue.InvokeEvent(index);
    }

    public void Hide()
    {
        OnDialogueEnded?.Invoke();
        _text.gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        OnDialogueEnded?.Invoke();
    }

}
