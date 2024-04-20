using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject pausePanel;
    public static GameManager Instance { get; private set; }

    private bool canFlipCard = true; // ����,����� �� �������������� �����
    private List<cardLogic> flippedCards = new List<cardLogic>(); // ������ ������������ ����

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); // ���������� ������������� ����������
        }
    }
    public bool CanFlipCard()
    {
        return canFlipCard;
    }

    public void SetCanFlipCard(bool value)
    {
        canFlipCard = value;
    }


    // ����� ��� ���������� ������������ ����� � ������
    public void AddFlippedCard(cardLogic card)
    {
        flippedCards.Add(card);
    }

    private void Update()
    {
        //  ���� ����� ESC �� ������������� ����
        if(Input.GetKey(KeyCode.Escape))
        {
            Time.timeScale = 0;
            pausePanel.SetActive(true);
        }
    }
}
