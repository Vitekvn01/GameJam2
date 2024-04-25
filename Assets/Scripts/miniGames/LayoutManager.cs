using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutManager : MonoBehaviour
{
    public GameObject cardPrefab; // Префаб карты
    public Transform panel; // Панель, на которой будут располагаться карты

    public void LayoutCards(List<Card> cards, int rows, int columns, float cellWidth, float cellHeight, float spacingX, float spacingY, RectOffset padding)
    {
        // Удаляем все дочерние объекты перед размещением новых карт
        foreach (Transform child in panel)
        {
            Destroy(child.gameObject);
        }

        // Рассчитываем начальную позицию для первой карты
        float startX = -padding.left - cellWidth / 2;
        float startY = padding.top + cellHeight / 2;

        // Рассчитываем позиции для каждой карты и создаем их на панели
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                // Создаем новую карту из префаба
                GameObject newCard = Instantiate(cardPrefab, panel);

                // Получаем компонент cardLogic
                cardLogic cardScript = newCard.GetComponent<cardLogic>();

                // Рассчитываем позицию для текущей карты
                float posX = startX + j * (cellWidth + spacingX);
                float posY = startY - i * (cellHeight + spacingY);

                // Устанавливаем позицию карты
                newCard.transform.localPosition = new Vector3(posX, posY, 0f);



                // Пример установки параметров карты из списка cards
                if (cardScript != null && cards.Count > 0)
                {
                    // Получаем следующую карту из списка
                    Card nextCard = cards[0];

                    // Устанавливаем эту карту для компонента cardLogic
                    cardScript.card = nextCard;

                    // Удаляем эту карту из списка, чтобы она больше не использовалась
                    cards.RemoveAt(0);
                }
            }
        }
    }
}
