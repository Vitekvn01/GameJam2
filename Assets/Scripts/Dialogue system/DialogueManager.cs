using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueManager : SingletonBase<DialogueManager>
{
    [SerializeField]
    private List<GameObject> _buttonsAnswer = new List<GameObject>();

    [SerializeField] private GameObject _dialoguePanel;

    [SerializeField] private Button _exitButton;

    private List<Dialog> _dialogCurrentList = new List<Dialog>();

    [SerializeField] private TextMeshProUGUI _text;

    [SerializeField] private TextMeshProUGUI _textName;

    public UnityEvent LoadPlayerStartDialogue;

    public UnityEvent EndDialogueEvent;

    public UnityEvent StartDialogueEvent;

    public UnityEvent ExitDialogueEvent;

    private int index = 0;

    private void Start()
    {
        foreach (GameObject button in _buttonsAnswer)
        {
            button.SetActive(false);
            Button buttonComponent = button.GetComponent<Button>();
            buttonComponent.onClick.AddListener(NextDialogue);
        }
        LoadPlayerStartDialogue.Invoke();
        _exitButton.onClick.AddListener(ExitDisableDialoguePanel);
    }

    private void Update()
    {
    }

    private void DrawAnswerButtons()
    {
        if (_dialogCurrentList[index]._answers.Count != 0)
        {
            for (int i = 0; i < _dialogCurrentList[index]._answers.Count; i++)
            {
                if (i <= _buttonsAnswer.Count)
                {
                    _buttonsAnswer[i].SetActive(true);
                    TextMeshProUGUI textButtons = _buttonsAnswer[i].GetComponentInChildren<TextMeshProUGUI>();
                    textButtons.text = _dialogCurrentList[index]._answers[i];
                }
            }
        }
        else
        {
            _buttonsAnswer[1].SetActive(true);
            TextMeshProUGUI textButtons = _buttonsAnswer[1].GetComponentInChildren<TextMeshProUGUI>();
            textButtons.text = "Продолжит";
        }
    }

    public void ExitDisableDialoguePanel()
    {
        ExitDialogueEvent.Invoke();
        _dialoguePanel.SetActive(false);
        index = 0;
    }

    public void StartDialogue(List<Dialog> currentDialogs, string NameCharacter)
    {
        StartDialogueEvent.Invoke();
        index = 0;
        _dialogCurrentList = currentDialogs;
        _textName.text = NameCharacter;
        foreach (GameObject button in _buttonsAnswer)
        {
            button.SetActive(false);
        }
        _dialoguePanel.SetActive(true);
        if (_dialogCurrentList.Count > 0)
        {
            _text.text = _dialogCurrentList[index]._textDialog;
            DrawAnswerButtons();
        }
    }

    public void NextDialogue()
    {
        foreach (GameObject button in _buttonsAnswer)
        {
            button.SetActive(false);
        }

        if (_dialogCurrentList.Count > 0)
        {
            if (index + 1 == _dialogCurrentList.Count)
            {
                EndDialogueEvent.Invoke();
                _dialoguePanel.SetActive(false);
                Debug.Log(index);

            }
            else
            {
                index += 1;
                _text.text = _dialogCurrentList[index]._textDialog;

                DrawAnswerButtons();
            }
        }
    }

/*    public void SubscriptionStartDialogueEvent(UnityAction action)
    {
        StartDialogueEvent.AddListener(action);
    }*/

}
