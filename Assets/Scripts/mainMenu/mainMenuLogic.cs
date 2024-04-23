using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class mainMenuLogic : MonoBehaviour
{
    public GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;

    private void Start()
    {
        settingsPanel.SetActive(false);
    }

    public void plauButton()
    {
        SceneManager.LoadScene(1);
    }

    public void settingsButton()
    {
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }
    public void creditsButton()
    {
        creditsPanel.SetActive(creditsPanel);
    }

    public void exitButton()
    {
        Application.Quit();
    }


}
