using UnityEngine;

public class PlayerInteract : MonoBehaviour
{

    [SerializeField] private string _npcTag = "NPC";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(_npcTag) && other.isTrigger)
        {
        }    
    }


}
