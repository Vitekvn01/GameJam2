using UnityEngine;
using UnityEngine.Audio;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] private GameObject checkCustom;
    private bool checkDraw = false;

    [SerializeField] private GameObject checkFullScreen;

    [SerializeField] private AudioMixer am;

    private void Start()
    {
        gameObject.SetActive(false);

        if (!Screen.fullScreen)
        {
            checkFullScreen.SetActive(false);
        }
        else
        {
            checkFullScreen.SetActive(true);
        }

       
        
        if (ScoreManager.Instance != null && ScoreManager.Instance.SecretCustomOpen == true)
        {
            checkCustom.SetActive(true);
        }
        else
        {
            checkCustom.SetActive(false);
        }

    }
    private void Update()
    {
        if (!checkDraw)
        {
            if (ScoreManager.Instance != null && ScoreManager.Instance.SecretCustomOpen == true)
            {
                checkCustom.SetActive(true);
                checkDraw = true;
            }
        }
    }

    public void fullScreen()
    {
        if (!Screen.fullScreen)
        {
            Screen.fullScreen = true;
            checkFullScreen.SetActive(true);
        }
        if (Screen.fullScreen)
        {
            Screen.fullScreen = false;
            checkFullScreen.SetActive(false);
        }
    }
    public void AudioVolume(float sliderValue)
    {
        am.SetFloat("MasterVolume", sliderValue);
    }
    public void closePanel()
    {
        gameObject.SetActive(false);
    }
}
