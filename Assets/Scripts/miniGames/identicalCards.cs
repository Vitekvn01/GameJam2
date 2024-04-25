using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*public class Card
{
    //public Sprite frontSprite; // Спрайт лицевой стороны карты
    public Color frontColor;
    public bool isMatched; // Флаг, указывающий, совпала ли карта с другой
    public int matchesCount; // Счетчик совпадений с другими картами

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
    public LayoutManager layoutManager;


    public GameObject mapPrefab; // Префаб карты
    public RectTransform panel; // Панель, на которой будут располагаться карты

    public GameObject gridContainer; // Пустой объект с компонентом Grid Layout Group

    public List<Sprite> frontSprites; // Список спрайтов лицевых сторон карт
    //public List<Color> frontColors; // Список цветов лицевых сторон карт

    private int currentLevel; // Текущий уровень игрока

   



    void Start()
    {
        // Получаем текущий уровень 
        currentLevel = SceneManager.GetActiveScene().buildIndex - 1;

        Debug.Log("Current level: " + currentLevel); // Отладочный вывод

        // Генерация карт на панели в зависимости от уровня
        GenerateMapForLevel(currentLevel);

        layoutManager = GetComponent<LayoutManager>();
    }

    

    // Генерация карт на панели в зависимости от уровня
    private void GenerateMapForLevel(int level)
    {
        int rows = 0;
        int columns = 0;
        int totalCards = 0;

        //параметры сетки
        float spacingX = 0f;
        float spacingY = 0f;
        RectOffset padding = new RectOffset();

        // Определение количества строк и столбцов карт в зависимости от уровня
        switch (level)
        {
            case 2:
                rows = 2;
                columns = 3;
                spacingX = 250f;
                spacingY = 118f;
                padding = new RectOffset(240 , 0, 60, 0);
                break;
            case 3:
                rows = 3;
                columns = 4;
                spacingX = 150f;
                spacingY = 100f;
                padding = new RectOffset(240, 0, 120, 0);
                break;
            case 4:
                rows = 4;
                columns = 5;
                spacingX = 120f;
                spacingY = 70f;
                padding = new RectOffset(280, 0, 160, 0);
                break;
            default:
                Debug.LogError("Unknown level: " + level);
                return;
        }

        Debug.Log("Rows: " + rows + ", Columns: " + columns); // Отладочный вывод

        // Устанавливаем количество карт в зависимости от строк и столбцов
        totalCards = rows * columns;
        Debug.Log("Total Cards: " + totalCards);

        // Проверка наличия достаточного количества спрайтов
        if ( /*frontColors.Count*/frontSprites.Count < totalCards / 2)
        {
            Debug.LogError("Not enough front sprites for the level!");
            return;
        }

        // Удаляем все дочерние объекты сетки перед генерацией новых
        foreach (Transform child in gridContainer.transform)
        {
            Destroy(child.gameObject);
        }

        // Получаем компонент Grid Layout Group
        GridLayoutGroup gridLayoutGroup = gridContainer.GetComponent<GridLayoutGroup>();
        if (gridLayoutGroup == null)
        {
            Debug.LogError("Grid Layout Group component not found on gridContainer!");
            return;
        }

        // Устанавливаем параметры Grid Layout Group
        gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayoutGroup.constraintCount = columns;
        gridLayoutGroup.spacing = new Vector2(spacingX, spacingY);
        gridLayoutGroup.padding = padding;


        // Создание списка карт
        List<Card> cards = new List<Card>();
        for (int i = 0; i < totalCards / 2; i++)
        {
            Sprite frontSprite = frontSprites[i];
            //Color frontColor = frontColors[i];
            Debug.Log("Front color for card " + i + ": " + frontSprite);

            cards.Add(new Card(/*frontColor*/frontSprite));
            cards.Add(new Card(/*frontColor*/frontSprite)); // Добавляем две карты с одинаковой лицевой стороной
        }

        // Перемешивание списка карт
        Shuffle(cards);
        Debug.Log("Cards Shuffled");

        // Вызываем метод LayoutCards через объект layoutManager
        layoutManager.LayoutCards(cards, rows, columns,
            mapPrefab.GetComponent<RectTransform>().sizeDelta.x,
            mapPrefab.GetComponent<RectTransform>().sizeDelta.y,
            spacingX, spacingY, padding);

        // Создание карт в сетке
        /*for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                // Создаем новую карту из префаба
                GameObject newMap = Instantiate(mapPrefab, gridContainer.transform);

                // Получаем компонент cardLogic
                cardLogic cardScript = newMap.GetComponent<cardLogic>();

                // Проверяем, что компонент cardLogic был найден и у нас есть карты для создания
                if (cardScript != null && cards.Count > 0)
                {
                    // Получаем следующую карту из списка
                    Card nextCard = cards[0];

                    // Устанавливаем эту карту для компонента cardLogic
                    cardScript.card = nextCard;

                    // Удаляем эту карту из списка, чтобы она больше не использовалась
                    cards.RemoveAt(0);
                }

                Debug.Log("Card Created: " + newMap.name);
            }
        }*/
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
