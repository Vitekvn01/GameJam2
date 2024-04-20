using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    private cardLogic[] flippedCards = new cardLogic[2]; // ������ ��� �������� ������������ ����


    private int remainingCards; // ���������� ���������� ����

    void Start()
    {
        remainingCards = GameObject.FindGameObjectsWithTag("Card").Length;
        Debug.Log("���-�� ���� " + remainingCards);
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
