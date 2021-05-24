using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    [SerializeField] private KeyCode _interactKey = KeyCode.F;
    [SerializeField] private string _npcTag = "NPC";

    private Collider2D _npc;

    private void Update()
    {
        if (Input.GetKeyDown(_interactKey) && _npc)
        {
            // start dialogue
            OnInteractTrigger trigger = _npc.GetComponent<OnInteractTrigger>();
            if (trigger && trigger.Contains<DialogueEvent>())
            {
                trigger.OnInteract();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(_npcTag) && other.isTrigger)
        {
            _npc = other;
        }    
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(_npcTag) && other.isTrigger)
        {
            _npc = null;
            UIDialogue.Instance?.Hide();
        }
    }

}
