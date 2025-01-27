using UnityEngine;
using TMPro;
using System.Collections;
using Unity.VisualScripting;

public class DialogueUI : MonoBehaviour
{
    [SerializeField] private GameObject dialogueBox;
    [SerializeField] private TMP_Text textLabel;
   
    public bool IsOpen{get; private set;}
  private TypingEffect typingEffect;

  private void Start()
  {
  typingEffect = GetComponent<TypingEffect>();
  CloseDialogueBox();
  }

  public void ShowDialogue(DialogueObject dialogueObject)
  {
    IsOpen = true;
    dialogueBox.SetActive(true);
    StartCoroutine(StepThroughDialogue(dialogueObject));
  }

  private IEnumerator StepThroughDialogue(DialogueObject dialogueObject)
  {
    foreach(string dialogue in dialogueObject.Dialogue)
    {
      yield return typingEffect.Run(dialogue, textLabel);
      yield return new WaitUntil(() => Input.GetButton("Submit"));
    }

    CloseDialogueBox();
  }

  private void CloseDialogueBox()
  {
    IsOpen = false;
    dialogueBox.SetActive(false);
    textLabel.text = string.Empty;
  }
}
