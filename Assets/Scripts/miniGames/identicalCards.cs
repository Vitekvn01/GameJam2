using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*public class Card
{
    //public Sprite frontSprite; // ������ ������� ������� �����
    public Color frontColor;
    public bool isMatched; // ����, �����������, ������� �� ����� � ������
    public int matchesCount; // ������� ���������� � ������� �������

    *//*public Card(Sprite frontSprite)
    {
        
        this.frontColor = frontColor;
        this.isMatched = false;
        this.matchesCount = 0;
    }*//*
    public Card(Color frontColor)
    {
        //this.frontSprite = frontSprite;
        this.frontColor = frontColor;
        this.isMatched = false;
        this.matchesCount = 0;
    }


}*/



public class identicalCards : MonoBehaviour
{
    public GameObject mapPrefab; // ������ �����
    public RectTransform panel; // ������, �� ������� ����� ������������� �����

    public GameObject gridContainer; // ������ ������ � ����������� Grid Layout Group

    public List<Sprite> frontSprites; // ������ �������� ������� ������ ����
    //public List<Color> frontColors; // ������ ������ ������� ������ ����

    private int currentLevel; // ������� ������� ������

    void Start()
    {
        // �������� ������� ������� 
        currentLevel = SceneManager.GetActiveScene().buildIndex;

        Debug.Log("Current level: " + currentLevel); // ���������� �����

        // ��������� ���� �� ������ � ����������� �� ������
        GenerateMapForLevel(currentLevel);
    }

    

    // ��������� ���� �� ������ � ����������� �� ������
    private void GenerateMapForLevel(int level)
    {
        int rows = 0;
        int columns = 0;
        int totalCards = 0;

        //��������� �����
        float spacingX = 0f;
        float spacingY = 0f;
        RectOffset padding = new RectOffset();

        // ����������� ���������� ����� � �������� ���� � ����������� �� ������
        switch (level)
        {
            case 2:
                rows = 2;
                columns = 3;
                spacingX = 200f;
                spacingY = 118f;
                padding = new RectOffset(111, 0, 93, 0);
                break;
            case 3:
                rows = 3;
                columns = 4;
                spacingX = 96f;
                spacingY = 49f;
                padding = new RectOffset(103, 0, 51, 0);
                break;
            case 4:
                rows = 4;
                columns = 5;
                spacingX = 72.5f;
                spacingY = 19.3f;
                padding = new RectOffset(60, 0, 32, 0);
                break;
            default:
                Debug.LogError("Unknown level: " + level);
                return;
        }

        Debug.Log("Rows: " + rows + ", Columns: " + columns); // ���������� �����

        // ������������� ���������� ���� � ����������� �� ����� � ��������
        totalCards = rows * columns;
        Debug.Log("Total Cards: " + totalCards);

        // �������� ������� ������������ ���������� ��������
        if ( /*frontColors.Count*/frontSprites.Count < totalCards / 2)
        {
            Debug.LogError("Not enough front sprites for the level!");
            return;
        }

        // ������� ��� �������� ������� ����� ����� ���������� �����
        foreach (Transform child in gridContainer.transform)
        {
            Destroy(child.gameObject);
        }

        // �������� ��������� Grid Layout Group
        GridLayoutGroup gridLayoutGroup = gridContainer.GetComponent<GridLayoutGroup>();
        if (gridLayoutGroup == null)
        {
            Debug.LogError("Grid Layout Group component not found on gridContainer!");
            return;
        }

        // ������������� ��������� Grid Layout Group
        gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayoutGroup.constraintCount = columns;
        gridLayoutGroup.spacing = new Vector2(spacingX, spacingY);
        gridLayoutGroup.padding = padding;


        // �������� ������ ����
        List<Card> cards = new List<Card>();
        for (int i = 0; i < totalCards / 2; i++)
        {
            Sprite frontSprite = frontSprites[i];
            //Color frontColor = frontColors[i];
            Debug.Log("Front color for card " + i + ": " + frontSprite);

            cards.Add(new Card(/*frontColor*/frontSprite));
            cards.Add(new Card(/*frontColor*/frontSprite)); // ��������� ��� ����� � ���������� ������� ��������
        }

        // ������������� ������ ����
        Shuffle(cards);
        Debug.Log("Cards Shuffled");

        // �������� ���� � �����
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                // ������� ����� ����� �� �������
                GameObject newMap = Instantiate(mapPrefab, gridContainer.transform);

                // �������� ��������� cardLogic
                cardLogic cardScript = newMap.GetComponent<cardLogic>();

                // ���������, ��� ��������� cardLogic ��� ������ � � ��� ���� ����� ��� ��������
                if (cardScript != null && cards.Count > 0)
                {
                    // �������� ��������� ����� �� ������
                    Card nextCard = cards[0];

                    // ������������� ��� ����� ��� ���������� cardLogic
                    cardScript.card = nextCard;

                    // ������� ��� ����� �� ������, ����� ��� ������ �� ��������������
                    cards.RemoveAt(0);
                }

                Debug.Log("Card Created: " + newMap.name);
            }
        }
    }








    private void Shuffle<T>(List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = Random.Range(0, n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
