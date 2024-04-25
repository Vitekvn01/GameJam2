using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardManager : MonoBehaviour
{
    private cardLogic[] flippedCards = new cardLogic[2]; // ������ ��� �������� ������������ ����

    public int remainingCards; // ���������� ���������� ����

    void Start()
    {
        //remainingCards = 6;
        if (SceneManager.GetActiveScene().buildIndex == 3)
        {
            remainingCards = 6;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 4)
        {
            remainingCards = 12;
        }
        else if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            remainingCards = 20;
        }
        //remainingCards = GameObject.FindGameObjectsWithTag("Card").Length;
        //Debug.Log("���-�� ���� " + remainingCards);
    }

    // ����� ��� ���������� ������������ ����� � ������
    public void AddFlippedCard(cardLogic card)
    {
        for (int i = 0; i < flippedCards.Length; i++)
        {
            if (flippedCards[i] == null)
            {
                flippedCards[i] = card;
                break;
            }
        }

        // ���������, ������� ���� ��� �����������, ���� 2, �� ��������� �������� ����������
        if (CountFlippedCards() == 2)
        {
            StartCoroutine(CheckMatch());
        }
    }

    // ����� ��� �������� ���������� ������������ ����
    public int CountFlippedCards()
    {
        int count = 0;
        foreach (cardLogic card in flippedCards)
        {
            if (card != null)
            {
                count++;
            }
        }
        return count;
    }

    // �������� ��� �������� ���������� ������������ ����
    private IEnumerator CheckMatch()
    {
        // ���� ���� ������� ����� ��������� ����������
        yield return new WaitForSeconds(1f);

        if (flippedCards[0].card.frontSprite == flippedCards[1].card.frontSprite)
        {
            // ���� ������� ������� ���������, ���������� �����
            Destroy(flippedCards[0].gameObject);
            Destroy(flippedCards[1].gameObject);

            // ��������� ���������� ���������� ����
            remainingCards -= 2;

            // ���������, �������� �� ��� �����
            if (remainingCards <= 0)
            {
                Debug.Log("���, �� ������!");
                if(SceneManager.GetActiveScene().buildIndex == 3)
                {
                    SceneManager.LoadScene(4);
                }
                else if(SceneManager.GetActiveScene().buildIndex == 4)
                {
                    SceneManager.LoadScene(5);
                }
                else if(SceneManager.GetActiveScene().buildIndex == 5)
                {
                    SceneManager.LoadScene(6);
                }

            }
        }
        else
        {
            // ���� ������� ������� �� ���������, �������������� ����� �������
            flippedCards[0].FlipCard();
            flippedCards[1].FlipCard();
        }

        // ������� ������ ������������ ����
        for (int i = 0; i < flippedCards.Length; i++)
        {
            flippedCards[i] = null;
        }


        
    }


    
}
