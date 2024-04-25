using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;

    private void Start()
    {
        gameObject.SetActive(false);
    }
    public void continueButton()
    {
        // продолжаем игру
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }

    public void settingsButton()
    {
        settingsPanel.SetActive(true);
    }

    public void exitButton()
    {
        // выход в главное меню
        SceneManager.LoadScene(0);
    }
}
