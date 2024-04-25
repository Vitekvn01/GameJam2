using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayoutManager : MonoBehaviour
{
    public GameObject cardPrefab; // ������ �����
    public Transform panel; // ������, �� ������� ����� ������������� �����

    public void LayoutCards(List<Card> cards, int rows, int columns, float cellWidth, float cellHeight, float spacingX, float spacingY, RectOffset padding)
    {
        // ������� ��� �������� ������� ����� ����������� ����� ����
        foreach (Transform child in panel)
        {
            Destroy(child.gameObject);
        }

        // ������������ ��������� ������� ��� ������ �����
        float startX = -padding.left - cellWidth / 2;
        float startY = padding.top + cellHeight / 2;

        // ������������ ������� ��� ������ ����� � ������� �� �� ������
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                // ������� ����� ����� �� �������
                GameObject newCard = Instantiate(cardPrefab, panel);

                // �������� ��������� cardLogic
                cardLogic cardScript = newCard.GetComponent<cardLogic>();

                // ������������ ������� ��� ������� �����
                float posX = startX + j * (cellWidth + spacingX);
                float posY = startY - i * (cellHeight + spacingY);

                // ������������� ������� �����
                newCard.transform.localPosition = new Vector3(posX, posY, 0f);



                // ������ ��������� ���������� ����� �� ������ cards
                if (cardScript != null && cards.Count > 0)
                {
                    // �������� ��������� ����� �� ������
                    Card nextCard = cards[0];

                    // ������������� ��� ����� ��� ���������� cardLogic
                    cardScript.card = nextCard;

                    // ������� ��� ����� �� ������, ����� ��� ������ �� ��������������
                    cards.RemoveAt(0);
                }
            }
        }
    }
}
