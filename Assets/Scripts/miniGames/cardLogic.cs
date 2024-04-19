using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




public class Card
{
    public Sprite frontSprite; // ������ ������� ������� �����
    //public Color frontColor;
    public bool isMatched; // ����, �����������, ������� �� ����� � ������
    public int matchesCount; // ������� ���������� � ������� �������

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
    public Card card; // ������ �� ������ �����


    public Sprite backSprite; // ������ �������
    public SpriteRenderer spriteRenderer; // ������ �� ��������� SpriteRenderer
    //private Image cardImage;

    public Color backColor = Color.black; // ���� ��� ������� �����

    private bool isFlipped = false; // ����, �����������, ����������� �� �����
    private bool isClickable = true; // ����, �����������, ����� �� �������� �� �����

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        /*cardImage = GetComponent<Image>();
        if(cardImage == null)
        {
            Debug.LogError("Image component not found on the card!");
        }*/
    }

    private void OnMouseDown()
    {
        Debug.Log("Mouse down event detected on card.");


        // ���������, ����� �� �������� �� ����� � ����������� �
        if (!isClickable || !GameManager.Instance.CanFlipCard())
        {
            return;
        }

        // �������������� �����
        FlipCard();

        // ��������� ������ ����

        if (GameManager.Instance.CanFlipCard())
        {
             GameManager.Instance.AddFlippedCard(this);
        }
    }

    // ����� ��� ���������� �����
    public void FlipCard()
    {
        if (!isFlipped)
        {
            spriteRenderer.sprite = card.frontSprite; // ���������� ������� �������
            //cardImage.color = card.frontColor;
            Debug.Log("Card flipped to front.");
        }
        else
        {
            // ������� ������� �������, ���������� �������
            spriteRenderer.sprite = backSprite/*������ �������*/;
            //cardImage.color = backColor;
            Debug.Log("Card flipped to back.");
        }

        isFlipped = !isFlipped;
    }

    // ����� ��� ���������� ������ �� �����
    public void SetClickable(bool clickable)
    {
        isClickable = clickable;
        Debug.Log("Clickable set to: " + clickable);
    }

}
