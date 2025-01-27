using Unity.VisualScripting;
using UnityEngine;

public class DialogueActivator : MonoBehaviour, Interectable
{
    [SerializeField] private DialogueObject dialogueObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && other.TryGetComponent(out PlayerController player))
        {
            player.Interectable = this;
        }
    }       
      private void OnTriggerExit2D(Collider2D other)
    {
        if(other.CompareTag("Player") && other.TryGetComponent(out PlayerController player))
        {
            if(player.Interectable is DialogueActivator dialogueActivator && dialogueActivator == this)
            {
                 player.Interectable = null;
            }
        }
    }
    public void Interact(PlayerController player)
    {
        player.DialogueUI.ShowDialogue(dialogueObject);
    }
}
