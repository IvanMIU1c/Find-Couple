using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] private BoxCollider2D colliderCard;
    [SerializeField] private SpriteRenderer defaultSprite;
    [SerializeField] private SpriteRenderer cardSprite;

    [SerializeField] private CardCheck cardCheck;
    [SerializeField] private CardGenerator cardGenerator;
    [SerializeField] private Animator CloseCard;
    [SerializeField] private Animator OpenCard;

    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;



    }

    private void OnMouseDown()
    {

        cardCheck.SumAmountOpenCard();
        if (cardCheck.GetAmountOpenCard() > 2)
        {

            Debug.Log("Here");
            return;
        }

        if (cardCheck.GetAmountOpenCard() == 1)
        {
            PlayingClose();
            Invoke("enableStandartSprite", 0.15f);
            Invoke("disableDefaultSprite", 0.15f);
            Invoke("PlayingOpen", 0.15f);


            cardCheck.GetFirstSpriteRenderer(cardSprite);
        }

        if (cardCheck.GetAmountOpenCard() == 2)
        {
            PlayingClose();
            Invoke("enableStandartSprite", 0.15f);
            Invoke("disableDefaultSprite", 0.15f);
            Invoke("PlayingOpen", 0.15f);

            cardCheck.GetSecondSPriteRenderer(cardSprite);

            if (cardCheck.GetFirstCardSprite() == cardCheck.GetSecondCardSprite())
            {
                cardGenerator.winScorePlus();
                Debug.Log("good");
                cardCheck.ResetOpenCard();
            }

            if (cardCheck.GetFirstCardSprite() != cardCheck.GetSecondCardSprite())
            {
                Debug.Log("bad");
                cardGenerator.Invoke("ResetCards", 1);
                cardCheck.ResetOpenCard();
            }
        }
        Invoke("DisableOpen", 1f);
        Invoke("DisableClose", 1f);
    }

    private void PlayingClose()
    {
        CloseCard.enabled = true;
    }
    private void PlayingOpen()
    {
        OpenCard.enabled = true;
    }

    private void DisableClose()
    {
        CloseCard.enabled = false;
    }

    private void DisableOpen()
    {
        OpenCard.enabled = false;
    }

    private void disableDefaultSprite()
    {
        defaultSprite.enabled = false;
    }
    private void enableStandartSprite()
    {
        cardSprite.enabled = true;
    }

}
