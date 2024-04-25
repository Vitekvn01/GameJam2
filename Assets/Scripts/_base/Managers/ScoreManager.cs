using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : SingletonBase<ScoreManager>
{
    [SerializeField] private int allBananas;

    private static int CurrentCountBananas; // кол-во бананов
    private static int AllBananas;

    /*    private static List<Banana> bananas = new List<Banana>();*/

    [SerializeField] private TextMeshProUGUI currentCountBananasText;
    [SerializeField] private TextMeshProUGUI allBananasText;

    [SerializeField] private GameObject BananasPanel;
    private bool CountBanananShow = false;

    [SerializeField] private GameObject notificationPanel;
    private bool notificationShow = false;

    private float timer = 0;
    [SerializeField] private float notificationPanelShowTime;
    [SerializeField] private float bananasPanelShowTime;

    private bool secretCustomOpen = false;
    public bool SecretCustomOpen => secretCustomOpen;

    private void Start()
    {
        AllBananas = allBananas;
        notificationPanel.SetActive(false);
        BananasPanel.SetActive(false);
        currentCountBananasText.text = CurrentCountBananas.ToString();
        allBananasText.text = AllBananas.ToString();
    }

    private void Update()
    {
        if (CurrentCountBananas >= AllBananas)
        {
            secretCustomOpen = true;
            if (!notificationShow)
            {
                notificationPanel.SetActive(true);
                timer += Time.deltaTime;
                if (timer >= notificationPanelShowTime)
                {
                    notificationShow = true;
                    notificationPanel.SetActive(false);
                    timer = 0;
                  
                }
            }

        }

        if (CountBanananShow)
        {
            timer += Time.deltaTime;
            BananasPanel.SetActive(true);
            if (timer >= bananasPanelShowTime)
            {
                CountBanananShow = false;
                BananasPanel.SetActive(false);
                timer = 0;
            }
        }



    }

    public void AddCurrentCountBananas()
    {
        CurrentCountBananas++;
        CountBanananShow = true;
        timer = 0;
        updateBananaScore();
    }

    private void updateBananaScore()
    {
        currentCountBananasText.text = CurrentCountBananas.ToString();
    }

/*    public void AddBananaInListAllBanans(Banana banana)
    {
        bananas.Add(banana);
    }*/

}
