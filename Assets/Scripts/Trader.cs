using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trader : MonoBehaviour
{
    public List<Trade> trades = new List<Trade>();

    public GameObject tradeUI;
    public GameObject player;
    public GameObject gameController;
    public GameObject clock;
    public Sprite daySprite;
    public Sprite nightSprite;
    private bool inRange = false;
    [Space]
    public AudioSource itemBuy;
    
    public void Awake()
    {
        foreach (PlantInfo plant in gameController.GetComponent<GameController>().plantList)
        {
            if (plant.buyable)
            {
                trades.Add(new Trade(plant.seed, plant.cost));
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            inRange = true;
        }
    }

    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            inRange = false;
        }
    }

    public void TryExecuteTrade(Trade trade)
    {
        MainCharacter mc = player.GetComponent<MainCharacter>();
        if (mc.CanFit(trade.item))
        {
            mc.money -= trade.cost;
            mc.AddItem(new ItemStack(trade.item));
            itemBuy.Play();
        }
    }

    public void Update()
    {
        bool day = clock.GetComponent<Clock>().IsDay();
        var renderer = GetComponent<SpriteRenderer>();
        if (day)
        {
            renderer.sprite = daySprite;
        }
        else
        {
            renderer.sprite = nightSprite;
        }
        
        tradeUI.SetActive(day && inRange);
    }
}
