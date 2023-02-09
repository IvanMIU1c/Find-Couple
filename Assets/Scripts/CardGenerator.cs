using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CardGenerator : MonoBehaviour
{
    [SerializeField] protected Sprite[] sprite;
    [SerializeField] protected Transform[] spawnPoints;
    [SerializeField] protected Sprite defaultSprite;
    [SerializeField] protected SpriteRenderer[] cards;
    [SerializeField] protected SpriteRenderer[] cardDefault;

    private float timer;
    //private bool startShow=false;


    [SerializeField] private UnityEvent ResetLevel;
    private int openCards;
    private int lastIndex;
    private void Awake()
    {
        openCards = 0;
        int pointIndex = Random.Range(0, spawnPoints.Length);
        int index = Random.Range(0, sprite.Length);
        for (int i=0; i < cards.Length; i++)
        {
            lastIndex = index;
            if (i % 2 == 0)
            {
                index = Random.Range(0, cards.Length);
            }
            //проверка чтобы не было всех одинаковых карт
            if(i%2==0 && lastIndex == index)
            {
                index = Random.Range(0, cards.Length);
            }
            cards[i].sprite = sprite[index];
            cards[i].enabled = false;


            cardDefault[i].sprite = defaultSprite;
            cardDefault[i].enabled = true;
        }

        //проверка чтобы каждая карта спавнилась в своем квадрате
        for (int i = 0; i < cards.Length; i++)
        {
            pointIndex = Random.Range(0, spawnPoints.Length);
            for (int j=0; j < cards.Length; j++)
            {
                if (cards[j].transform.position == spawnPoints[pointIndex].transform.position)
                {
                    pointIndex = Random.Range(0, spawnPoints.Length);
                }
                for (int z = 0; z < cards.Length; z++)
                {
                    if (cards[z].transform.position == spawnPoints[pointIndex].transform.position)
                    {
                        pointIndex = Random.Range(0, spawnPoints.Length);
                    }
                    for(int w = 0; w < cards.Length; w++)
                    {
                        if (cards[w].transform.position == spawnPoints[pointIndex].transform.position)
                        {
                            pointIndex = Random.Range(0, spawnPoints.Length);
                        }
                    }
                }
            }
            cards[i].transform.position = spawnPoints[pointIndex].transform.position;
            cardDefault[i].transform.position = cards[i].transform.position;
        }

    }



    private void Update()
    {
        timer += Time.deltaTime;

       /* if (timer >= 3 && startShow==false)
        {
            for (int i = 0; i < cardDefault.Length; i++)
            {
                cardDefault[i].enabled = true;
            }

            for (int i = 0; i < cards.Length; i++)
            {
                cards[i].enabled = false;
            }
            startShow = true;
        }*/


        if (openCards == cards.Length) 
        {
            Invoke("ResetLevels", 2);
            Debug.Log("win");
        }
    }

    public void winScorePlus()
    {
        openCards += 2;
    }

    public void ResetCards()
    {
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].enabled = false;
            cardDefault[i].enabled = true;
        }
    }
    public void ResetLevels()
    {
        ResetLevel.Invoke();
    }
}
