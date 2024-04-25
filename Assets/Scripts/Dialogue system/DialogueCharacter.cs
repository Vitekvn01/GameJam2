using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public struct Dialog
{
    [SerializeField] public string _textDialog;

    [SerializeField] public List<string> _answers;
}

public class DialogueCharacter : MonoBehaviour
{

    [SerializeField] private bool isLockInteraction;
    public bool IsLockIisLockInteraction => isLockInteraction;

    [SerializeField] private List<Dialog> dialogList = new List<Dialog>();
    [SerializeField] private UnityEvent startDialogue;
    [SerializeField] private UnityEvent endDialogue;
    [SerializeField] private UnityEvent exitDialogue;

    private Character _character;
    private void Start()
    {
        _character = gameObject.GetComponent<Character>();
    }


    public void StartDialogue()
    {
        SubscriptionStartDialogueEvent();
        SubscriptionEndDialogueEvent();
        DialogueManager.Instance.StartDialogue(dialogList, _character.Nickname);
        SubscriptionExitDialogueEvent();
    }

    public void isUnlockInteraction()
    {
        isLockInteraction = false;
    }

    public void islockInteraction()
    {
        isLockInteraction = true;
    }

    private void SubscriptionStartDialogueEvent()
    {
        DialogueManager.Instance.StartDialogueEvent.AddListener(startDialogue.Invoke);
        DialogueManager.Instance.EndDialogueEvent.AddListener(UnsubscriptionStartDialogueEvent);
        DialogueManager.Instance.ExitDialogueEvent.AddListener(UnsubscriptionStartDialogueEvent);
    }
    private void SubscriptionEndDialogueEvent()
    {
        DialogueManager.Instance.EndDialogueEvent.AddListener(endDialogue.Invoke);
        DialogueManager.Instance.StartDialogueEvent.RemoveListener(UnsubscriptionEndDialogueEvent);
        DialogueManager.Instance.ExitDialogueEvent.AddListener(UnsubscriptionEndDialogueEvent);
    }
    private void SubscriptionExitDialogueEvent()
    {
        DialogueManager.Instance.ExitDialogueEvent.AddListener(exitDialogue.Invoke);
        DialogueManager.Instance.StartDialogueEvent.AddListener(UnsubscriptionExitDialogueEvent);
    }


    private void UnsubscriptionStartDialogueEvent()
    {
        DialogueManager.Instance.StartDialogueEvent.RemoveListener(startDialogue.Invoke);
    }
    private void UnsubscriptionEndDialogueEvent()
    {
        DialogueManager.Instance.EndDialogueEvent.RemoveListener(endDialogue.Invoke);
    }
    private void UnsubscriptionExitDialogueEvent()
    {
        DialogueManager.Instance.ExitDialogueEvent.RemoveListener(exitDialogue.Invoke);
    }
}
