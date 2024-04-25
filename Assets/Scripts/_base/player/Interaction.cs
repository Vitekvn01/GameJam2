using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    [SerializeField] private float _length;

    [SerializeField] private GameObject _playerView;

    [SerializeField] private GameObject _panelInteraction;

    private bool _interaction = false;
    void Update()
    {
        if (_interaction == true)
        {
            _panelInteraction.SetActive(true);
        }
        else _panelInteraction.SetActive(false);

        if (Physics.Raycast(_playerView.transform.position, _playerView.transform.forward, out RaycastHit hit))
        {
            if (hit.collider != null && hit.collider.GetComponent<DialogueCharacter>() != null)
            {
                DialogueCharacter character = hit.collider.GetComponent<DialogueCharacter>();

                if (character.IsLockIisLockInteraction != true)
                {
                    _interaction = true;

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        Debug.Log("взаимодейсвие произошло с" + hit.collider.name);
                        character.StartDialogue();
                        _panelInteraction.SetActive(false);
                    }
                }
                
            }
            else _interaction = false;
        }
        else _interaction = false;
    }
}




