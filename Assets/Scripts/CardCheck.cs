using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCheck : MonoBehaviour
{
    [SerializeField] private SpriteRenderer defaultSprite;
    [SerializeField] private SpriteRenderer cardSprite;


    [HideInInspector] public SpriteRenderer firstCard;
    [HideInInspector] public SpriteRenderer secondCard;
    private int amountOpenCard = 0;

    private float timer;
    private void Update()
    {
        timer += Time.deltaTime;
        if (timer % 2 == 0)
        {
            Debug.Log(timer);
        }
    }

    public void SumAmountOpenCard()
    {
        amountOpenCard += 1;
    }

    public int GetAmountOpenCard()
    {
        return amountOpenCard;
    }
    public void GetFirstSpriteRenderer(SpriteRenderer renderer)
    {
        firstCard = renderer;
    }

    public void GetSecondSPriteRenderer(SpriteRenderer renderer)
    {
        secondCard = renderer;
    }

    public Sprite GetFirstCardSprite()
    {
        return firstCard.sprite;
    }
    public Sprite GetSecondCardSprite()
    {
        return secondCard.sprite;
    }

    public void ResetOpenCard()
    {
        amountOpenCard = 0;
    }
    public void ResetTimer()
    {
        timer = 0;
    }
}
