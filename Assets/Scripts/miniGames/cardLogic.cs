using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Card
{
    

    public Sprite frontSprite; // Спрайт лицевой стороны карты
    //public Color frontColor;
    public bool isMatched; // Флаг, указывающий, совпала ли карта с другой
    public int matchesCount; // Счетчик совпадений с другими картами

    /*public Card(Sprite frontSprite)
    {
        
        this.frontColor = frontColor;
        this.isMatched = false;
        this.matchesCount = 0;
    }*/
    /*public Card(Color frontColor)
    {
        //this.frontSprite = frontSprite;
        this.frontColor = frontColor;
        this.isMatched = false;
        this.matchesCount = 0;
    }*/
    public Card(Sprite frontSprite)
    {
        
        this.frontSprite = frontSprite;
        this.isMatched = false;
        this.matchesCount = 0;
    }


}




public class cardLogic : MonoBehaviour
{


    public SpriteRenderer childSpriteRenderer; // Ссылка на компонент SpriteRenderer дочернего объекта
    public Sprite backSprite; // Спрайт рубашки
    public Card card; // Ссылка на объект карты

    private bool isFlipped = false; // Флаг, указывающий, перевернута ли карта
    private bool isClickable = true; // Флаг, указывающий, можно ли кликнуть на карту
    private CardManager cardManager;

    private void Awake()
    {
        cardManager = FindObjectOfType<CardManager>();

        // Получаем компонент SpriteRenderer дочернего объекта
        childSpriteRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    private void OnMouseDown()
    {
        // Проверяем, можно ли кликнуть на карту и перевернуть её
        if (!isClickable || cardManager.CountFlippedCards() >= 2 || isFlipped)
        {
            return;
        }

        FlipCard();
        cardManager.AddFlippedCard(this);
    }

    // Метод для переворота карты
    public void FlipCard()
    {
        if (!isFlipped)
        {
            // Показываем лицевую сторону путем установки спрайта дочернего объекта
            childSpriteRenderer.sprite = card.frontSprite;
        }
        else
        {
            // Удаляем спрайт дочернего объекта, чтобы вернуться к рубашке
            childSpriteRenderer.sprite = null;
        }

        isFlipped = !isFlipped;
    }

    // Метод для блокировки кликов на карту
    public void SetClickable(bool clickable)
    {
        isClickable = clickable;
    }

}
