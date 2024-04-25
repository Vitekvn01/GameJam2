using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CardManager : MonoBehaviour
{
    private cardLogic[] flippedCards = new cardLogic[2]; // Массив для хранения перевернутых карт

    public int remainingCards; // Количество оставшихся карт

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
        //Debug.Log("кол-во карт " + remainingCards);
    }

    // Метод для добавления перевернутой карты в массив
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

        // Проверяем, сколько карт уже перевернуто, если 2, то запускаем проверку совпадения
        if (CountFlippedCards() == 2)
        {
            StartCoroutine(CheckMatch());
        }
    }

    // Метод для подсчета количества перевернутых карт
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

    // Корутина для проверки совпадения перевернутых карт
    private IEnumerator CheckMatch()
    {
        // Ждем одну секунду перед проверкой совпадения
        yield return new WaitForSeconds(1f);

        if (flippedCards[0].card.frontSprite == flippedCards[1].card.frontSprite)
        {
            // Если лицевые стороны совпадают, уничтожаем карты
            Destroy(flippedCards[0].gameObject);
            Destroy(flippedCards[1].gameObject);

            // Уменьшаем количество оставшихся карт
            remainingCards -= 2;

            // Проверяем, остались ли еще карты
            if (remainingCards <= 0)
            {
                Debug.Log("УРА, ты прошел!");
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
            // Если лицевые стороны не совпадают, переворачиваем карты обратно
            flippedCards[0].FlipCard();
            flippedCards[1].FlipCard();
        }

        // Очищаем массив перевернутых карт
        for (int i = 0; i < flippedCards.Length; i++)
        {
            flippedCards[i] = null;
        }


        
    }


    
}
